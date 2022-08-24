using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity.Extensions;

namespace DiscordBot.Commands
{
    internal class DeveloperCommands : BaseCommandModule
    {
        [Command("ping")]
        public async Task Ping(CommandContext context)
        {
            var ping = context.Client.Ping + "ms";

            await context.Channel.SendMessageAsync(ping).ConfigureAwait(false);
        }

        [Command("clean")]
        [Description("Clean current chat")]
        [RequirePermissions(Permissions.Administrator)]
        public async Task Clean(CommandContext context)
        {
            var warningInfo = "All messages will be deleted from this channel after 10...";

            var warningInfoMessage = await context.Channel.SendMessageAsync(warningInfo).ConfigureAwait(false);

            for (var i = 10; i > 0; --i)
            {
                await warningInfoMessage.ModifyAsync($"All messages will be deleted from this channel after {i}...").ConfigureAwait(false);

                //await warningInfoMessage.DeleteAllReactionsAsync().ConfigureAwait(false);
                
                //var emojiName = GetEmojiNumberNameByNumber(i);

                //var emoji = DiscordEmoji.FromName(context.Client, emojiName, false);

                //await warningInfoMessage.CreateReactionAsync(emoji).ConfigureAwait(false);

                await Task.Delay(TimeSpan.FromSeconds(0.2)).ConfigureAwait(false);
            }

            var messages = await context.Channel.GetMessagesAsync().ConfigureAwait(false);

            await context.Channel.DeleteMessagesAsync(messages).ConfigureAwait(false);

            var info = "Was been deleted " + messages.Count + " messages.";

            var infoMessage = await context.Channel.SendMessageAsync(info).ConfigureAwait(false);

            for (var i = 10; i > 0; --i)
            {
                await infoMessage.DeleteAllReactionsAsync().ConfigureAwait(false);

                var emojiName = GetEmojiNumberNameByNumber(i);

                var emoji = DiscordEmoji.FromName(context.Client, emojiName, false);

                await infoMessage.CreateReactionAsync(emoji).ConfigureAwait(false);

                await Task.Delay(TimeSpan.FromSeconds(0.5)).ConfigureAwait(false);
            }

            await infoMessage.DeleteAsync().ConfigureAwait(false);
        }

        private string GetEmojiNumberNameByNumber(int number)
        {
            var emojiName = string.Empty;

            switch (number)
            {
                case 1:
                    emojiName = ":one:";
                    break;

                case 2:
                    emojiName = ":two:";
                    break;

                case 3:
                    emojiName = ":three:";
                    break;

                case 4:
                    emojiName = ":four:";
                    break;

                case 5:
                    emojiName = ":five:";
                    break;

                case 6:
                    emojiName = ":six:";
                    break;

                case 7:
                    emojiName = ":seven:";
                    break;

                case 8:
                    emojiName = ":eight:";
                    break;

                case 9:
                    emojiName = ":nine:";
                    break;

                case 10:
                    emojiName = ":keycap_ten:";
                    break;

                default:
                    emojiName = ":zero:";
                    break;
            }

            return emojiName;
        }
    }
}