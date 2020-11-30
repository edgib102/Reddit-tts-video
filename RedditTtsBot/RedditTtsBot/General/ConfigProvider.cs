using System;
using System.IO;
using Newtonsoft.Json;
using RedditTtsBot.General.General_classes.Config;
using System.Collections.Generic;
using System.Text;


namespace RedditTtsBot.General
{
    public static class ConfigProvider
    {
        

        private static FileInfo generalConfigFile = new FileInfo("generalconfig.json");
        private static FileInfo redditConfigFile = new FileInfo("redditconfig.json");

        public static IGeneralConfig GetGeneralConfig()
        {
            Uri DefaultUri = new Uri("https://www.thespruceeats.com/can-i-freeze-cheese-1327672"); //dummy uri
            //default file path as well

            IGeneralConfig GConfig = new GeneralConfig(generalConfigFile.FullName, DefaultUri);

            try
            {
                GConfig = JsonConvert.DeserializeObject<GeneralConfig>(File.ReadAllText(generalConfigFile.FullName));
            }
            catch
            {
                GenerateNewGeneralConfig(GConfig);
                
            }

            return GConfig;
        }

        public static IRedditConfig GetRedditConfig()
        {
            IRedditConfig RConfig = new RedditConfig("App id goes here", "Refresh token goes here", "Client secret goes here");

            try
            {
                RConfig = JsonConvert.DeserializeObject<RedditConfig>(File.ReadAllText(redditConfigFile.FullName));
                
            }
            catch (Exception e)
            {
                Console.WriteLine($"the class had an Exception: {e}");
                GenerateNewRedditConfig(RConfig);
            }

            return RConfig;
        }

        private static void GenerateNewGeneralConfig(IGeneralConfig GConfig)
        {
            var configJson = JsonConvert.SerializeObject(GConfig);
            Console.WriteLine("Creating config.json");
            generalConfigFile.Delete();
            File.WriteAllText(generalConfigFile.FullName, configJson);
            generalConfigFile = new FileInfo(generalConfigFile.FullName);
        }

        private static void GenerateNewRedditConfig(IRedditConfig RConfig)
        {
            var configJson = JsonConvert.SerializeObject(RConfig);
            Console.WriteLine("Creating redditconfig.json");
            redditConfigFile.Delete();
            File.WriteAllText(redditConfigFile.FullName, configJson);
            redditConfigFile = new FileInfo(redditConfigFile.FullName);
        }
    }
}
