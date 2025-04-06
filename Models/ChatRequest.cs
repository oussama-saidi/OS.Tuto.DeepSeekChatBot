namespace OS.Tuto.DeepSeekChatBot.Models;

public class ChatRequest
{
    [JsonProperty("model")]
    public string Model { get; set; } = "deepseek-chat";

    [JsonProperty("messages")]
    public List<ChatMessage> Messages { get; set; } = new();

    [JsonProperty("temperature")]
    public double Temperature { get; set; } = 0.7;

    [JsonProperty("max_tokens")]
    public int MaxTokens { get; set; } = 2000;

    [JsonProperty("stream")]
    public bool Stream { get; set; } = false;
}
