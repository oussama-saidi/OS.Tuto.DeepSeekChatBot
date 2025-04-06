namespace OS.Tuto.DeepSeekChatBot.Models;

public class ChatChoice
{
    [JsonProperty("index")]
    public int Index { get; set; }

    [JsonProperty("message")]
    public ChatMessage Message { get; set; } = new();

    [JsonProperty("finish_reason")]
    public string FinishReason { get; set; } = string.Empty;
}
