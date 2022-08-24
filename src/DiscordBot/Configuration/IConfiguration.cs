namespace DiscordBot.Configuration
{
    internal interface IConfiguration
    {
        public string Token { get; set; }

        public string[] Prefixes { get; set; }
    }
}