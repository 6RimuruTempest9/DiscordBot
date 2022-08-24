using Newtonsoft.Json;

namespace DiscordBot.Configuration.Json
{
    internal struct JsonConfiguration : IConfiguration
    {
        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("prefixes")]
        public string[] Prefixes { get; set; }
    }
}