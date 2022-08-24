namespace DiscordBot.Configuration
{
    internal interface IConfigurationReader
    {
        public IConfiguration ReadConfigurationFromFile(string fileName);
    }
}