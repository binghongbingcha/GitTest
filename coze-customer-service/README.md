# Coze客服智能体

一个基于Coze AI的智能客服系统，提供美观的聊天界面和强大的对话能力。

## 功能特性

- 🤖 **智能对话**: 集成Coze AI，提供智能的客服对话体验
- 💻 **现代化界面**: 响应式设计，支持桌面和移动设备
- 🚀 **双重连接**: 支持HTTP和WebSocket两种连接模式
- 🎨 **美观设计**: 渐变色彩、平滑动画、现代化UI
- ⚙️ **可配置**: 灵活的设置选项，支持个性化配置
- 📱 **响应式**: 自适应不同屏幕尺寸
- 🔊 **消息提示**: 可选的声音提示和视觉反馈
- 💾 **会话保持**: 自动保存对话历史

## 技术栈

### 后端
- **FastAPI**: 现代、快速的Python Web框架
- **Uvicorn**: ASGI服务器
- **httpx**: 异步HTTP客户端
- **pydantic**: 数据验证和设置管理

### 前端
- **原生JavaScript**: 无框架依赖，纯净高效
- **CSS3**: 现代化样式和动画
- **Font Awesome**: 图标库
- **WebSocket**: 实时通信支持

## 快速开始

### 1. 环境要求

- Python 3.8+
- pip package manager

### 2. 安装依赖

```bash
cd coze-customer-service
pip install -r requirements.txt
```

### 3. 配置环境变量

复制环境变量模板：
```bash
cp .env.example .env
```

编辑 `.env` 文件，填入你的Coze API配置：
```env
# Coze API配置
COZE_API_KEY=your_coze_api_key_here
COZE_BOT_ID=your_bot_id_here
COZE_API_BASE_URL=https://www.coze.com/api/v1

# 服务器配置
HOST=0.0.0.0
PORT=8000
DEBUG=True

# CORS配置
ALLOWED_ORIGINS=http://localhost:3000,http://127.0.0.1:3000
```

### 4. 获取Coze API密钥

1. 访问 [Coze官网](https://www.coze.com)
2. 注册/登录账号
3. 创建你的AI助手
4. 获取API密钥和Bot ID
5. 将配置信息填入 `.env` 文件

### 5. 启动服务

```bash
python app.py
```

服务启动后，访问 `http://localhost:8000` 即可使用聊天界面。

## API文档

启动服务后，可以访问以下地址查看API文档：

- **Swagger UI**: `http://localhost:8000/docs`
- **ReDoc**: `http://localhost:8000/redoc`

### 主要API端点

#### 发送消息
```http
POST /api/chat
Content-Type: application/json

{
    "message": "你好",
    "conversation_id": "optional_conversation_id"
}
```

#### 健康检查
```http
GET /api/health
```

#### 配置信息
```http
GET /api/config
```

#### WebSocket连接
```
ws://localhost:8000/ws/{client_id}
```

## 使用说明

### 基本功能

1. **发送消息**: 在输入框中输入问题，按Enter键或点击发送按钮
2. **快捷回复**: 点击预设的快捷回复按钮快速发送常用问题
3. **清空对话**: 点击顶部的垃圾桶图标清空所有对话记录
4. **设置面板**: 点击齿轮图标打开设置面板

### 设置选项

- **连接模式**: 选择HTTP或WebSocket连接方式
- **消息提示音**: 开启/关闭新消息提示音
- **自动滚动**: 开启/关闭消息自动滚动到底部

### 界面说明

- **顶部栏**: 显示机器人信息和连接状态
- **消息区域**: 显示对话历史，支持滚动查看
- **输入区域**: 文本输入框和发送按钮
- **快捷回复**: 常用问题的快速入口
- **状态指示**: 
  - 🟢 在线: 服务器连接正常
  - 🔴 离线: 服务器连接失败
  - 🟡 连接中: 正在尝试连接

## 部署指南

### Docker部署

1. 创建Dockerfile：
```dockerfile
FROM python:3.9-slim

WORKDIR /app
COPY requirements.txt .
RUN pip install -r requirements.txt

COPY . .
EXPOSE 8000

CMD ["python", "app.py"]
```

2. 构建和运行：
```bash
docker build -t coze-customer-service .
docker run -p 8000:8000 --env-file .env coze-customer-service
```

### 生产环境部署

使用Gunicorn作为WSGI服务器：

```bash
pip install gunicorn
gunicorn -w 4 -k uvicorn.workers.UvicornWorker app:app --bind 0.0.0.0:8000
```

### Nginx反向代理

Nginx配置示例：
```nginx
server {
    listen 80;
    server_name your-domain.com;

    location / {
        proxy_pass http://127.0.0.1:8000;
        proxy_set_header Host $host;
        proxy_set_header X-Real-IP $remote_addr;
        proxy_set_header X-Forwarded-For $proxy_add_x_forwarded_for;
    }

    location /ws/ {
        proxy_pass http://127.0.0.1:8000;
        proxy_http_version 1.1;
        proxy_set_header Upgrade $http_upgrade;
        proxy_set_header Connection "upgrade";
        proxy_set_header Host $host;
    }
}
```

## 自定义配置

### 修改界面样式

编辑 `static/style.css` 文件可以自定义界面样式：

- 颜色主题
- 字体样式
- 布局尺寸
- 动画效果

### 添加快捷回复

在 `static/index.html` 中的快捷回复区域添加新按钮：

```html
<button class="quick-reply-btn" onclick="sendQuickReply('你的问题')">
    按钮文本
</button>
```

### 自定义API集成

如果需要集成其他AI服务，修改 `app.py` 中的 `CozeClient` 类。

## 故障排除

### 常见问题

1. **服务启动失败**
   - 检查Python版本是否正确
   - 确认所有依赖已正确安装
   - 检查端口是否被占用

2. **API连接失败**
   - 验证Coze API密钥是否正确
   - 检查网络连接
   - 确认API服务器地址

3. **界面显示异常**
   - 检查浏览器控制台错误信息
   - 确认静态文件路径正确
   - 尝试刷新页面

### 日志查看

应用日志会显示在控制台中，包含：
- API请求详情
- 错误信息
- 连接状态变化

### 性能优化

1. **启用生产模式**: 设置 `DEBUG=False`
2. **使用CDN**: 将静态资源部署到CDN
3. **启用缓存**: 配置Redis缓存会话数据
4. **负载均衡**: 使用多个应用实例

## 贡献指南

欢迎提交Issue和Pull Request来改进项目。

### 开发环境设置

1. Fork项目
2. 创建功能分支
3. 提交更改
4. 发起Pull Request

### 代码规范

- 使用Python PEP 8编码规范
- 添加适当的注释和文档
- 遵循现有的代码结构

## 许可证

MIT License

## 联系方式

如有问题或建议，请通过以下方式联系：

- GitHub Issues
- Email: your-email@example.com

---

**享受智能客服带来的便利体验！** 🚀