namespace OS.Tuto.DeepSeekChatBot.Services;

public class ChatHistoryService
{
    private readonly List<ChatMessage> _conversationHistory = new();

    public void AddMessage(ChatMessage message)
    {
        _conversationHistory.Add(message);
    }

    public List<ChatMessage> GetConversationHistory()
    {
        return _conversationHistory;
    }

    public void ClearHistory()
    {
        _conversationHistory.Clear();
    }
}
