using System;
using RedditTtsBot.General;
using RedditTtsBot.Gui;

namespace RedditTtsBot
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("------------------------Program Start------------------------\n");

            ConfigProvider.GetGeneralConfig(); // checks and creates confing on startup
            ConfigProvider.GetRedditConfig(); // checks and creates confing on startup
            Console.WriteLine(string.Empty);
            var Options = BaseUi.ui();
            RedditUi.GetPost();
            




        }
    }
}
