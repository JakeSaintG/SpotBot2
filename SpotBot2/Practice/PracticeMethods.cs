

namespace SpotBot2.Practice
{
    internal class PracticeMethods
    {
        public string GetChannelTopic(ulong id, DiscordSocketClient client)
        {
            var channel = client.GetChannel(81384956881809408) as SocketTextChannel;
            return channel?.Topic;
        }

        public SocketGuildUser GetGuildOwner(SocketChannel channel)
        {
            var guild = (channel as SocketGuildChannel)?.Guild;
            return guild?.Owner;
        }
    }

    public static class PracticeStaticMethods
    {
        public static async Task<EmbedBuilder> WithUserColorAsync(this EmbedBuilder builder, IUser user, DiscordSocketClient client)
        {
            var restUser = await client.Rest.GetUserAsync(user.Id);
            return builder.WithColor(restUser.AccentColor ?? Color.Blue);
            // The accent color can still be null, so a check for this needs to be done to prevent an exception to be thrown.
        }
    }
}
