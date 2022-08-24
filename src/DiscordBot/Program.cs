using DiscordBot.Configuration.Json;

namespace DiscordBot
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var configurationReader = new JsonConfigurationReader();

            var configuration = configurationReader.ReadConfigurationFromFile("config.json");

            var bot = new Bot();

            bot.RunAsync(configuration).GetAwaiter().GetResult();
        }
    }
}