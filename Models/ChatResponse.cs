namespace OS.Tuto.DeepSeekChatBot.Models;
public class ChatResponse
{
    [JsonProperty("id")]
    public string Id { get; set; } = string.Empty;

    [JsonProperty("object")]
    public string Object { get; set; } = string.Empty;

    [JsonProperty("created")]
    public long Created { get; set; }

    [JsonProperty("choices")]
    public List<ChatChoice> Choices { get; set; } = new();

    [JsonProperty("usage")]
    public TokenUsage Usage { get; set; } = new();
}

