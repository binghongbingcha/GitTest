// 全局变量
let currentConversationId = null;
let websocket = null;
let isConnected = false;
let messageHistory = [];
let settings = {
    connectionMode: 'http',
    soundEnabled: true,
    autoScroll: true
};

// DOM元素
const chatMessages = document.getElementById('chatMessages');
const messageInput = document.getElementById('messageInput');
const sendButton = document.getElementById('sendButton');
const typingIndicator = document.getElementById('typingIndicator');
const charCount = document.getElementById('charCount');
const status = document.getElementById('status');
const loadingOverlay = document.getElementById('loadingOverlay');
const settingsPanel = document.getElementById('settingsPanel');
const quickReplies = document.getElementById('quickReplies');

// 初始化
document.addEventListener('DOMContentLoaded', function() {
    initializeApp();
    loadSettings();
    setupEventListeners();
    checkServerStatus();
});

// 初始化应用
function initializeApp() {
    // 设置输入框事件
    messageInput.addEventListener('keypress', function(e) {
        if (e.key === 'Enter' && !e.shiftKey) {
            e.preventDefault();
            sendMessage();
        }
    });

    // 字符计数
    messageInput.addEventListener('input', function() {
        const count = this.value.length;
        charCount.textContent = `${count}/500`;
        
        if (count > 450) {
            charCount.style.color = '#dc3545';
        } else if (count > 400) {
            charCount.style.color = '#ffc107';
        } else {
            charCount.style.color = '#6c757d';
        }
    });

    // 自动调整消息区域高度
    adjustChatHeight();
}

// 设置事件监听器
function setupEventListeners() {
    // 设置面板事件
    document.getElementById('connectionMode').addEventListener('change', function(e) {
        settings.connectionMode = e.target.value;
        saveSettings();
        reconnectIfNeeded();
    });

    document.getElementById('soundEnabled').addEventListener('change', function(e) {
        settings.soundEnabled = e.target.checked;
        saveSettings();
    });

    document.getElementById('autoScroll').addEventListener('change', function(e) {
        settings.autoScroll = e.target.checked;
        saveSettings();
    });

    // 窗口大小变化
    window.addEventListener('resize', adjustChatHeight);
}

// 检查服务器状态
async function checkServerStatus() {
    try {
        const response = await fetch('/api/health');
        if (response.ok) {
            updateConnectionStatus('online');
        } else {
            updateConnectionStatus('offline');
        }
    } catch (error) {
        console.error('服务器连接失败:', error);
        updateConnectionStatus('offline');
    }
}

// 更新连接状态
function updateConnectionStatus(statusType) {
    const statusElement = document.getElementById('status');
    statusElement.className = `status ${statusType}`;
    
    switch (statusType) {
        case 'online':
            statusElement.textContent = '在线';
            isConnected = true;
            break;
        case 'offline':
            statusElement.textContent = '离线';
            isConnected = false;
            break;
        case 'connecting':
            statusElement.textContent = '连接中...';
            isConnected = false;
            break;
    }
}

// 发送消息
async function sendMessage() {
    const message = messageInput.value.trim();
    if (!message) return;

    // 禁用输入
    messageInput.disabled = true;
    sendButton.disabled = true;

    // 添加用户消息到界面
    addUserMessage(message);
    
    // 清空输入框
    messageInput.value = '';
    charCount.textContent = '0/500';
    charCount.style.color = '#6c757d';

    // 显示输入指示器
    showTypingIndicator();

    try {
        if (settings.connectionMode === 'websocket' && websocket && websocket.readyState === WebSocket.OPEN) {
            // WebSocket发送
            const messageData = {
                message: message,
                conversation_id: currentConversationId,
                timestamp: new Date().toISOString()
            };
            websocket.send(JSON.stringify(messageData));
        } else {
            // HTTP发送
            await sendHttpMessage(message);
        }
    } catch (error) {
        console.error('发送消息失败:', error);
        addBotMessage('抱歉，发送消息时出现错误，请稍后再试。');
    } finally {
        // 恢复输入
        messageInput.disabled = false;
        sendButton.disabled = false;
        messageInput.focus();
        hideTypingIndicator();
    }
}

// HTTP方式发送消息
async function sendHttpMessage(message) {
    showLoading();
    
    try {
        const response = await fetch('/api/chat', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({
                message: message,
                conversation_id: currentConversationId
            })
        });

        if (!response.ok) {
            throw new Error(`HTTP ${response.status}: ${response.statusText}`);
        }

        const data = await response.json();
        currentConversationId = data.conversation_id;
        addBotMessage(data.response);
        
        // 保存到历史记录
        messageHistory.push({
            type: 'user',
            content: message,
            timestamp: new Date().toISOString()
        });
        messageHistory.push({
            type: 'bot',
            content: data.response,
            timestamp: data.timestamp
        });

    } catch (error) {
        console.error('HTTP发送失败:', error);
        addBotMessage('连接服务器失败，请检查网络连接后重试。');
    } finally {
        hideLoading();
    }
}

// WebSocket连接
function connectWebSocket() {
    if (websocket && websocket.readyState === WebSocket.OPEN) {
        return;
    }

    updateConnectionStatus('connecting');
    
    const clientId = 'client_' + Math.random().toString(36).substr(2, 9);
    const protocol = window.location.protocol === 'https:' ? 'wss:' : 'ws:';
    const wsUrl = `${protocol}//${window.location.host}/ws/${clientId}`;

    websocket = new WebSocket(wsUrl);

    websocket.onopen = function(event) {
        console.log('WebSocket连接已建立');
        updateConnectionStatus('online');
    };

    websocket.onmessage = function(event) {
        const data = JSON.parse(event.data);
        if (data.type === 'bot_response') {
            currentConversationId = data.conversation_id;
            addBotMessage(data.message);
        }
    };

    websocket.onclose = function(event) {
        console.log('WebSocket连接已关闭');
        updateConnectionStatus('offline');
        
        // 自动重连
        if (settings.connectionMode === 'websocket') {
            setTimeout(() => {
                connectWebSocket();
            }, 3000);
        }
    };

    websocket.onerror = function(error) {
        console.error('WebSocket错误:', error);
        updateConnectionStatus('offline');
    };
}

// 根据设置重新连接
function reconnectIfNeeded() {
    if (settings.connectionMode === 'websocket') {
        connectWebSocket();
    } else if (websocket) {
        websocket.close();
        websocket = null;
    }
}

// 添加用户消息
function addUserMessage(message) {
    const messageDiv = document.createElement('div');
    messageDiv.className = 'user-message';
    
    const timestamp = new Date().toLocaleTimeString('zh-CN', { 
        hour: '2-digit', 
        minute: '2-digit' 
    });
    
    messageDiv.innerHTML = `
        <div class="message-content">
            <p>${escapeHtml(message)}</p>
            <div class="message-timestamp">${timestamp}</div>
        </div>
    `;
    
    chatMessages.appendChild(messageDiv);
    
    if (settings.autoScroll) {
        scrollToBottom();
    }
}

// 添加机器人消息
function addBotMessage(message) {
    const messageDiv = document.createElement('div');
    messageDiv.className = 'bot-message';
    
    const timestamp = new Date().toLocaleTimeString('zh-CN', { 
        hour: '2-digit', 
        minute: '2-digit' 
    });
    
    messageDiv.innerHTML = `
        <div class="bot-avatar">
            <i class="fas fa-robot"></i>
        </div>
        <div class="message-content">
            <p>${escapeHtml(message)}</p>
            <div class="message-timestamp">${timestamp}</div>
        </div>
    `;
    
    chatMessages.appendChild(messageDiv);
    
    // 播放提示音
    if (settings.soundEnabled) {
        playNotificationSound();
    }
    
    if (settings.autoScroll) {
        scrollToBottom();
    }
}

// 快捷回复
function sendQuickReply(message) {
    messageInput.value = message;
    sendMessage();
    
    // 隐藏快捷回复按钮
    quickReplies.style.display = 'none';
    setTimeout(() => {
        quickReplies.style.display = 'flex';
    }, 2000);
}

// 清空聊天
function clearChat() {
    if (confirm('确定要清空所有对话记录吗？')) {
        chatMessages.innerHTML = `
            <div class="welcome-message">
                <div class="bot-avatar">
                    <i class="fas fa-robot"></i>
                </div>
                <div class="message-content">
                    <p>您好！我是智能客服助手，很高兴为您服务！</p>
                    <p>请告诉我您需要什么帮助？</p>
                </div>
            </div>
        `;
        currentConversationId = null;
        messageHistory = [];
    }
}

// 切换设置面板
function toggleSettings() {
    const panel = document.getElementById('settingsPanel');
    if (panel.style.display === 'none') {
        panel.style.display = 'block';
        loadCurrentSettings();
    } else {
        panel.style.display = 'none';
    }
}

// 加载当前设置到面板
function loadCurrentSettings() {
    document.getElementById('connectionMode').value = settings.connectionMode;
    document.getElementById('soundEnabled').checked = settings.soundEnabled;
    document.getElementById('autoScroll').checked = settings.autoScroll;
}

// 显示/隐藏输入指示器
function showTypingIndicator() {
    typingIndicator.style.display = 'inline';
}

function hideTypingIndicator() {
    typingIndicator.style.display = 'none';
}

// 显示/隐藏加载提示
function showLoading() {
    loadingOverlay.style.display = 'flex';
}

function hideLoading() {
    loadingOverlay.style.display = 'none';
}

// 滚动到底部
function scrollToBottom() {
    setTimeout(() => {
        chatMessages.scrollTop = chatMessages.scrollHeight;
    }, 100);
}

// 调整聊天高度
function adjustChatHeight() {
    const container = document.querySelector('.chat-container');
    const windowHeight = window.innerHeight;
    const maxHeight = Math.min(600, windowHeight - 40);
    container.style.height = maxHeight + 'px';
}

// HTML转义
function escapeHtml(text) {
    const div = document.createElement('div');
    div.textContent = text;
    return div.innerHTML;
}

// 播放提示音
function playNotificationSound() {
    try {
        // 创建音频上下文
        const audioContext = new (window.AudioContext || window.webkitAudioContext)();
        const oscillator = audioContext.createOscillator();
        const gainNode = audioContext.createGain();
        
        oscillator.connect(gainNode);
        gainNode.connect(audioContext.destination);
        
        oscillator.frequency.value = 800;
        oscillator.type = 'sine';
        
        gainNode.gain.setValueAtTime(0.1, audioContext.currentTime);
        gainNode.gain.exponentialRampToValueAtTime(0.01, audioContext.currentTime + 0.3);
        
        oscillator.start(audioContext.currentTime);
        oscillator.stop(audioContext.currentTime + 0.3);
    } catch (error) {
        console.log('无法播放提示音:', error);
    }
}

// 保存设置到本地存储
function saveSettings() {
    localStorage.setItem('coze-chat-settings', JSON.stringify(settings));
}

// 从本地存储加载设置
function loadSettings() {
    try {
        const saved = localStorage.getItem('coze-chat-settings');
        if (saved) {
            settings = { ...settings, ...JSON.parse(saved) };
        }
    } catch (error) {
        console.log('加载设置失败:', error);
    }
}

// 点击外部关闭设置面板
document.addEventListener('click', function(e) {
    const panel = document.getElementById('settingsPanel');
    const settingsContent = document.querySelector('.settings-content');
    
    if (panel.style.display === 'block' && 
        !settingsContent.contains(e.target) && 
        !e.target.closest('.action-btn')) {
        panel.style.display = 'none';
    }
});

// 防止表单提交
document.addEventListener('submit', function(e) {
    e.preventDefault();
});

// 页面可见性变化处理
document.addEventListener('visibilitychange', function() {
    if (document.visibilityState === 'visible') {
        checkServerStatus();
    }
});

// 网络状态监测
window.addEventListener('online', function() {
    updateConnectionStatus('online');
    checkServerStatus();
});

window.addEventListener('offline', function() {
    updateConnectionStatus('offline');
});

// 页面卸载清理
window.addEventListener('beforeunload', function() {
    if (websocket) {
        websocket.close();
    }
});