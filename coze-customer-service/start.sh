#!/bin/bash

# Coze客服智能体启动脚本

echo "🚀 启动Coze客服智能体..."

# 检查Python版本
python_version=$(python3 --version 2>&1)
echo "📍 Python版本: $python_version"

# 检查依赖
if [ ! -f "requirements.txt" ]; then
    echo "❌ 找不到requirements.txt文件"
    exit 1
fi

# 安装依赖
echo "📦 检查并安装依赖..."
pip install -r requirements.txt

# 检查环境变量文件
if [ ! -f ".env" ]; then
    echo "⚠️  找不到.env文件，使用默认配置"
    if [ -f ".env.example" ]; then
        echo "📋 复制.env.example到.env"
        cp .env.example .env
        echo "⚙️  请编辑.env文件配置您的Coze API密钥"
    fi
fi

# 检查静态文件目录
if [ ! -d "static" ]; then
    echo "❌ 找不到static目录"
    exit 1
fi

# 启动服务
echo "🎯 启动服务..."
echo "🌐 访问地址: http://localhost:8000"
echo "📚 API文档: http://localhost:8000/docs"
echo "🛑 按Ctrl+C停止服务"
echo ""

python app.py