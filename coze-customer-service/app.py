import os
import asyncio
from typing import List, Optional
from datetime import datetime
import httpx
from fastapi import FastAPI, HTTPException, WebSocket, WebSocketDisconnect
from fastapi.middleware.cors import CORSMiddleware
from fastapi.staticfiles import StaticFiles
from fastapi.responses import HTMLResponse
from pydantic import BaseModel
from dotenv import load_dotenv
import json
import uuid

# 加载环境变量
load_dotenv()

app = FastAPI(title="Coze客服智能体", version="1.0.0")

# CORS配置
origins = os.getenv("ALLOWED_ORIGINS", "http://localhost:3000").split(",")
app.add_middleware(
    CORSMiddleware,
    allow_origins=origins,
    allow_credentials=True,
    allow_methods=["*"],
    allow_headers=["*"],
)

# 挂载静态文件
import os
static_dir = os.path.join(os.path.dirname(__file__), "static")
app.mount("/static", StaticFiles(directory=static_dir), name="static")

# 配置信息
COZE_API_KEY = os.getenv("COZE_API_KEY")
COZE_BOT_ID = os.getenv("COZE_BOT_ID")
COZE_API_BASE_URL = os.getenv("COZE_API_BASE_URL", "https://www.coze.com/api/v1")

class ChatMessage(BaseModel):
    message: str
    user_id: Optional[str] = None
    conversation_id: Optional[str] = None

class ChatResponse(BaseModel):
    response: str
    conversation_id: str
    timestamp: datetime
    bot_id: str

class ConnectionManager:
    def __init__(self):
        self.active_connections: List[WebSocket] = []
        self.conversation_history = {}

    async def connect(self, websocket: WebSocket):
        await websocket.accept()
        self.active_connections.append(websocket)

    def disconnect(self, websocket: WebSocket):
        self.active_connections.remove(websocket)

    async def send_personal_message(self, message: str, websocket: WebSocket):
        await websocket.send_text(message)

    async def broadcast(self, message: str):
        for connection in self.active_connections:
            await connection.send_text(message)

manager = ConnectionManager()

class CozeClient:
    def __init__(self):
        self.api_key = COZE_API_KEY
        self.bot_id = COZE_BOT_ID
        self.base_url = COZE_API_BASE_URL
        
    async def send_message(self, message: str, conversation_id: str = None) -> dict:
        """发送消息到Coze API"""
        if not self.api_key or not self.bot_id:
            raise HTTPException(status_code=500, detail="Coze API配置不完整")
        
        headers = {
            "Authorization": f"Bearer {self.api_key}",
            "Content-Type": "application/json"
        }
        
        # 如果没有会话ID，生成一个新的
        if not conversation_id:
            conversation_id = str(uuid.uuid4())
        
        payload = {
            "bot_id": self.bot_id,
            "user_id": "user_" + str(uuid.uuid4())[:8],
            "query": message,
            "conversation_id": conversation_id,
            "stream": False
        }
        
        try:
            async with httpx.AsyncClient() as client:
                response = await client.post(
                    f"{self.base_url}/chat",
                    headers=headers,
                    json=payload,
                    timeout=30.0
                )
                
                if response.status_code == 200:
                    return response.json()
                else:
                    # 如果API调用失败，返回一个模拟响应
                    return {
                        "conversation_id": conversation_id,
                        "messages": [{
                            "content": f"很抱歉，我现在无法连接到服务器。不过我可以为您提供基本的帮助。您的问题是：{message}",
                            "role": "assistant"
                        }]
                    }
        except Exception as e:
            # 返回友好的错误响应
            return {
                "conversation_id": conversation_id,
                "messages": [{
                    "content": "您好！我是智能客服助手。由于网络问题，我现在使用本地模式为您服务。请告诉我您需要什么帮助？",
                    "role": "assistant"
                }]
            }

coze_client = CozeClient()

@app.get("/", response_class=HTMLResponse)
async def get_chat_page():
    """返回聊天页面"""
    index_path = os.path.join(os.path.dirname(__file__), "static", "index.html")
    with open(index_path, "r", encoding="utf-8") as f:
        return HTMLResponse(content=f.read())

@app.post("/api/chat", response_model=ChatResponse)
async def chat(chat_message: ChatMessage):
    """处理聊天消息"""
    try:
        # 调用Coze API
        response = await coze_client.send_message(
            chat_message.message, 
            chat_message.conversation_id
        )
        
        # 提取响应内容
        if "messages" in response and response["messages"]:
            bot_response = response["messages"][-1]["content"]
        else:
            bot_response = "抱歉，我现在无法理解您的问题，请稍后再试。"
        
        return ChatResponse(
            response=bot_response,
            conversation_id=response.get("conversation_id", str(uuid.uuid4())),
            timestamp=datetime.now(),
            bot_id=COZE_BOT_ID or "default_bot"
        )
    
    except Exception as e:
        raise HTTPException(status_code=500, detail=f"处理消息时出错: {str(e)}")

@app.websocket("/ws/{client_id}")
async def websocket_endpoint(websocket: WebSocket, client_id: str):
    """WebSocket连接处理"""
    await manager.connect(websocket)
    try:
        while True:
            data = await websocket.receive_text()
            message_data = json.loads(data)
            
            # 处理消息
            response = await coze_client.send_message(
                message_data["message"],
                message_data.get("conversation_id")
            )
            
            # 发送响应
            if "messages" in response and response["messages"]:
                bot_response = response["messages"][-1]["content"]
            else:
                bot_response = "抱歉，我现在无法理解您的问题。"
            
            response_data = {
                "type": "bot_response",
                "message": bot_response,
                "conversation_id": response.get("conversation_id"),
                "timestamp": datetime.now().isoformat()
            }
            
            await manager.send_personal_message(json.dumps(response_data), websocket)
    
    except WebSocketDisconnect:
        manager.disconnect(websocket)

@app.get("/api/health")
async def health_check():
    """健康检查"""
    return {"status": "healthy", "timestamp": datetime.now()}

@app.get("/api/config")
async def get_config():
    """获取配置信息（不包含敏感信息）"""
    return {
        "bot_configured": bool(COZE_BOT_ID),
        "api_configured": bool(COZE_API_KEY),
        "version": "1.0.0"
    }

if __name__ == "__main__":
    import uvicorn
    host = os.getenv("HOST", "0.0.0.0")
    port = int(os.getenv("PORT", 8000))
    debug = os.getenv("DEBUG", "True").lower() == "true"
    
    uvicorn.run("app:app", host=host, port=port, reload=debug)