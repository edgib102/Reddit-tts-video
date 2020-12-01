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

            string SharedAssetPathString = Path.Combine(basefolder, "Shared Assets");
            var SharedAssetDir = Directory.CreateDirectory(SharedAssetPathString);
            DirList.Add(SharedAssetDir);

            string VideoPathString = Path.Combine(basefolder, "TestFolder");
            var MainDir = Directory.CreateDirectory(VideoPathString);
            DirList.Add(MainDir);

            string pathString = Path.Combine(VideoPathString, "Text Files");
            var TxtDir = Directory.CreateDirectory(pathString);
            DirList.Add(TxtDir);

            pathString = VideoPathString;

            pathString = Path.Combine(pathString, "Audio Files");
            var AudioDir = Directory.CreateDirectory(pathString);
            DirList.Add(AudioDir);

            pathString = VideoPathString;

            pathString = Path.Combine(pathString, "Output-Video-Files");
            var OutputDir = Directory.CreateDirectory(pathString);
            DirList.Add(OutputDir);

            return DirList;
        }
    }
}
