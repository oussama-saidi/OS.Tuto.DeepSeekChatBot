namespace OS.Tuto.DeepSeekChatBot.Services;

// Services/DeepSeekService.cs
public class DeepSeekService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;

    public DeepSeekService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;

        // Configure the HttpClient
        _httpClient.BaseAddress = new Uri("https://api.deepseek.com/v1/");
        _httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", _configuration["DeepSeek:ApiKey"]);
        _httpClient.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
    }

    public async Task<ChatResponse> GetChatResponseAsync(List<ChatMessage> messages)
    {
        var request = new ChatRequest
        {
            Messages = messages,
            Model = "deepseek-chat",
            Temperature = 0.7,
            MaxTokens = 2000
        };

        var response = await _httpClient.PostAsJsonAsync("chat/completions", request);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<ChatResponse>();
    }
    public async IAsyncEnumerable<string> GetStreamingChatResponseAsync(List<ChatMessage> messages)
    {
        var request = new ChatRequest
        {
            Messages = messages,
            Model = "deepseek-chat",
            Temperature = 0.7,
            MaxTokens = 2000,
            Stream = true
        };

        var response = await _httpClient.PostAsJsonAsync("chat/completions", request);
        response.EnsureSuccessStatusCode();

        using var stream = await response.Content.ReadAsStreamAsync();
        using var reader = new StreamReader(stream);

        while (!reader.EndOfStream)
        {
            var line = await reader.ReadLineAsync();
            if (line.StartsWith("data: "))
            {
                var data = line["data: ".Length..];
                if (data == "[DONE]") yield break;

                var partialResponse = JsonConvert.DeserializeObject<ChatResponse>(data);
                if (partialResponse?.Choices?.Count > 0)
                {
                    yield return partialResponse.Choices[0].Message.Content;
                }
            }
        }
    }
}
