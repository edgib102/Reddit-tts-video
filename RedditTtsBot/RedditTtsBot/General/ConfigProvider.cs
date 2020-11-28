using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;


namespace RedditTtsBot.General
{
    public static class ConfigProvider
    {
        private static FileInfo configFile = new FileInfo("config.json");

        public static IConfig GetConfig()
        {
            Uri DefaultUri = new Uri("https://www.thespruceeats.com/can-i-freeze-cheese-1327672");
            //default file path as well

            IConfig config = new Config(configFile.FullName, DefaultUri);

            try
            {
                config = JsonConvert.DeserializeObject<Config>(File.ReadAllText(configFile.FullName));
            }
            catch
            {
                GenerateNewConfig(config);
                
            }

            return config;
        }

        private static void GenerateNewConfig(IConfig config)
        {
            var configJson = JsonConvert.SerializeObject(config);
            Console.WriteLine("Creating config.json");
            configFile.Delete();
            File.WriteAllText(configFile.FullName, configJson);
            configFile = new FileInfo(configFile.FullName);
        }

    }
}
