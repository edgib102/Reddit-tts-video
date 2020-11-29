using System;
using System.IO;

namespace RedditTtsBot.Gui
{
    public class Options
    {
        public Uri Url { get; set; }
        public DirectoryInfo OutputPath { get; set; }

        public Options(Uri Url, DirectoryInfo OutputPath)
        {
            this.Url = Url;
            this.OutputPath = OutputPath;
        }
    }
}