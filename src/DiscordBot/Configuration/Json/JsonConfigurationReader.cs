using Newtonsoft.Json;
using System.Text;

namespace DiscordBot.Configuration.Json
{
    internal class JsonConfigurationReader : IConfigurationReader
    {
        public IConfiguration ReadConfigurationFromFile(string fileName)
        {
            var pathToFile = Path.Combine(Directory.GetCurrentDirectory(), fileName);

            if (!File.Exists(pathToFile))
            {
                throw new FileNotFoundException("Configuration file not found.");
            }

            var json = string.Empty;

            using (var fileStream = File.OpenRead(pathToFile))
            using (var streamReader = new StreamReader(fileStream, new UTF8Encoding(false)))
            {
                json = streamReader.ReadToEnd();
            }

            var configuration = JsonConvert.DeserializeObject<JsonConfiguration>(json);

            return JsonConvert.DeserializeObject<JsonConfiguration>(json);
        }
    }
}