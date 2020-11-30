using System;
using System.IO;

namespace RedditTtsBot.Gui
{
    public class OptionsClass
    {
        public Uri Url { get; set; }
        public DirectoryInfo OutputPath { get; set; }

        public OptionsClass(Uri Url, DirectoryInfo OutputPath)
        {
            this.Url = Url;
            this.OutputPath = OutputPath;
        }
    }
}
