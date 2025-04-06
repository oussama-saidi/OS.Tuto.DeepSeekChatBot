namespace OS.Tuto.DeepSeekChatBot.Pages;

public class ChatModel : PageModel
{
    private readonly DeepSeekService _deepSeekService;

    [BindProperty]
    public string UserMessage { get; set; } = string.Empty;

    public List<ChatMessage> Messages { get; set; } = new();

    public ChatModel(DeepSeekService deepSeekService)
    {
        _deepSeekService = deepSeekService;
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!string.IsNullOrWhiteSpace(UserMessage))
        {
            // Add user message to conversation
            Messages.Add(new ChatMessage { Role = "user", Content = UserMessage });

            // Get response from DeepSeek
            var response = await _deepSeekService.GetChatResponseAsync(Messages);

            // Add assistant response to conversation
            if (response?.Choices?.Count > 0)
            {
                Messages.Add(response.Choices[0].Message);
            }
        }

        return Page();
    }
}
