using DiscordBot.Commands;
using DiscordBot.Configuration;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using Microsoft.Extensions.Logging;

namespace DiscordBot
{
    internal class Bot
    {
        public async Task RunAsync(IConfiguration configuration)
        {
            var discordConfiguration = new DiscordConfiguration
            {
                Token = configuration.Token,
                TokenType = TokenType.Bot,
                AutoReconnect = true,
                MinimumLogLevel = LogLevel.Debug,
            };

            var discordClient = new DiscordClient(discordConfiguration);

            var commandsNextConfiguration = new CommandsNextConfiguration
            {
                StringPrefixes = configuration.Prefixes,
                EnableDms = false,
                DmHelp = false,
            };

            var commandsNextExtension = discordClient.UseCommandsNext(commandsNextConfiguration);

            commandsNextExtension.RegisterCommands<DeveloperCommands>();

            await discordClient.ConnectAsync();

            await Task.Delay(-1);
        }
    }
}