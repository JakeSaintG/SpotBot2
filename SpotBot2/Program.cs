public class Program
{
	private DiscordSocketClient _client;

	public static Task Main(string[] args) => new Program().MainAsync();

	public async Task MainAsync()
	{
        _client = new DiscordSocketClient();

        var token = File.ReadAllText("./token.txt");

        await _client.LoginAsync(TokenType.Bot, token);
        await _client.StartAsync();

        // Block this task until the program is closed.
        await Task.Delay(-1);
    }
}