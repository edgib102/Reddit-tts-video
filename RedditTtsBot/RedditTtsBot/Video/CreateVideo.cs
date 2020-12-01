using FFMpegCore;
using FFMpegCore.Enums;
using FFMpegCore.Arguments;
using System;
using System.Collections.Generic;
using System.IO;


namespace RedditTtsBot.Video
{
    class CreateVideo
    {
        public static void Createvideo(List<DirectoryInfo> DirList)
        {
            Random rand = new Random();
            //FFMpegOptions.Configure(new FFMpegOptions { RootDirectory = OutputDir.ToString() });
            var Files = GetFiles();

            EditVideo();


            void EditVideo()
            {
                string Background = Files[0][0]; //rand.Next(0, Files[0].Count-1) put here when you add more files
                string BackgroundAudio = Files[1][0]; // same here for audio
                string OutputDir = DirList[4].FullName;
                FFMpeg.ReplaceAudio(Background, BackgroundAudio, OutputDir); // does not work
                
            }

            List<List<string>> GetFiles()
            {
                List<string> BgFiles = new List<string>();
                List<string> AudFiles = new List<string>();

                foreach (FileInfo file in DirList[0].GetFiles())
                {
                    if (file.Name.Contains("AUD"))
                    {
                        Console.WriteLine($"Audio file found: {file.Name}");
                        AudFiles.Add(file.FullName);
                    }

                    if (file.Name.Contains("BG"))
                    {
                        Console.WriteLine($"Background file found: {file.Name}");
                        BgFiles.Add(file.FullName);
                    }
                }

                return new List<List<string>> { BgFiles, AudFiles };
            }
        }
    }
}
