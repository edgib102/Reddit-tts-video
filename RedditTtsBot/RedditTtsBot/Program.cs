using System;
using System.IO;
using System.Collections.Generic;
using RedditTtsBot.General;
using RedditTtsBot.Reddit;
using RedditTtsBot.Video;

namespace RedditTtsBot
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("------------------------Program Start------------------------\n");

            Startup.startup();

            var generalconfig = ConfigProvider.GetGeneralConfig();
            Console.WriteLine(string.Empty);
            List<List<DirectoryInfo>> ParentDirList = new List<List<DirectoryInfo>>();

            //var Options = BaseUi.ui();

            #region Create stuff
            ParentDirList.Add(CreateFolder.DirectoryCreate(generalconfig.DefualtOutputPath));
            //RedditClass.getpost(ParentDirList[0]);
            #endregion

            #region Make video
            CreateVideo.Createvideo(ParentDirList[0]);
            #endregion



        }
    }
}
