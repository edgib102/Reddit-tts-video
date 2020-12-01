using System;
using System.Collections.Generic;
using System.Text;

namespace RedditTtsBot.General
{
    class Startup
    {
        public static void startup()
        {
            ConfigProvider.GetGeneralConfig();
            ConfigProvider.GetRedditConfig();
        }
    }
}
