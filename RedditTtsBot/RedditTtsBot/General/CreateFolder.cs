using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace RedditTtsBot.General
{
    public class CreateFolder
    {
        public static List<DirectoryInfo> DirectoryCreate(string basefolder)
        {
            List<DirectoryInfo> DirList = new List<DirectoryInfo>();

            string basepathString = Path.Combine(basefolder, "SubFolder");
            var MainDir = Directory.CreateDirectory(basepathString);
            DirList.Add(MainDir);

            string pathString = Path.Combine(basepathString, "Text Files");
            var TxtDir = Directory.CreateDirectory(pathString);
            DirList.Add(TxtDir);

            pathString = basepathString;

            pathString = Path.Combine(pathString, "Audio Files");
            var AudioDir = Directory.CreateDirectory(pathString);
            DirList.Add(AudioDir);

            return DirList;
        }
    }
}
