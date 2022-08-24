using DiscordBot.Configuration;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using Microsoft.Extensions.Logging;

namespace DiscordBot
{
    internal class Bot
    {
        public DiscordClient DiscordClient { get; private set; }

        public CommandsNextExtension CommandsNextExtension { get; private set; }

        public async Task RunAsync(IConfiguration configuration)
        {
            var discordConfiguration = new DiscordConfiguration
            {
                Token = configuration.Token,
                TokenType = TokenType.Bot,
                AutoReconnect = true,
                MinimumLogLevel = LogLevel.Debug,
            };

            DiscordClient = new DiscordClient(discordConfiguration);

            var commandsNextConfiguration = new CommandsNextConfiguration
            {
                StringPrefixes = configuration.Prefixes,
                EnableDms = false,
                DmHelp = true,
            };

            CommandsNextExtension = DiscordClient.UseCommandsNext(commandsNextConfiguration);

            await DiscordClient.ConnectAsync();

            await Task.Delay(-1);
        }
    }
}