using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;

namespace RedditTtsBot.General
{
    public interface IConfig
    {
        Uri DefaultUri { get; set; }
        string DefualtOutputPath { get; set; }
    }

    public class Config : IConfig
    {
        [JsonProperty("defaultUri")]
        public Uri DefaultUri { get; set; }

        [JsonProperty("defualtoutputPath")]
        public string DefualtOutputPath { get; set; }

        public Config(string defualtoutputPath, Uri defaultUri)
        {
            DefaultUri = defaultUri;
            DefualtOutputPath = defualtoutputPath;
        }
    }
}
