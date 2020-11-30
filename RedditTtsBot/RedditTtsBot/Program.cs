using System;
using System.IO;
using System.Collections.Generic;
using RedditTtsBot.General;
using RedditTtsBot.Reddit;

namespace RedditTtsBot
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("------------------------Program Start------------------------\n");

            ConfigProvider.GetGeneralConfig();
            ConfigProvider.GetRedditConfig();
            // checks and creates confing on startup

            var generalconfig = ConfigProvider.GetGeneralConfig();
            Console.WriteLine(string.Empty);
            //var Options = BaseUi.ui();

            #region Create stuff
            List<List<DirectoryInfo>> ParentDirList = new List<List<DirectoryInfo>>();
            ParentDirList.Add(CreateFolder.DirectoryCreate(generalconfig.DefualtOutputPath));
            RedditClass.getpost(ParentDirList[0]);
            #endregion





        }
    }
}
