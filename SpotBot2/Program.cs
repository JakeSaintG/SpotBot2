public class Program
{
	private DiscordSocketClient _client;

	public static Task Main(string[] args) => new Program().MainAsync();

	public async Task MainAsync()
	{
        var _config = new DiscordSocketConfig { MessageCacheSize = 100 };
        _client = new DiscordSocketClient(_config);
        var token = File.ReadAllText("./token.txt");

        await _client.LoginAsync(TokenType.Bot, token);
        await _client.StartAsync();

        _client.MessageUpdated += MessageUpdated;
        _client.Ready += () =>
        {
            Console.WriteLine("SpotBot is connected!");
            return Task.CompletedTask;
        };

        // Block this task until the program is closed.
        await Task.Delay(-1);
    }

    private async Task MessageUpdated(Cacheable<IMessage, ulong> before, SocketMessage after, ISocketMessageChannel channel)
    {
        // If the message was not in the cache, downloading it will result in getting a copy of `after`.
        var message = await before.GetOrDownloadAsync();
        Console.WriteLine($"{message} -> {after}");
    }
}