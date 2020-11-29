using System;
using Newtonsoft.Json;

namespace RedditTtsBot.General.General_classes.Config
{
    public interface IGeneralConfig
    {
        Uri DefaultUri { get; set; }
        string DefualtOutputPath { get; set; }  
    }

    public class GeneralConfig : IGeneralConfig
    {
        [JsonProperty("defaultUri")]
        public Uri DefaultUri { get; set; }

        [JsonProperty("defualtoutputPath")]
        public string DefualtOutputPath { get; set; }

        public GeneralConfig(string defualtoutputPath, Uri defaultUri)
        {
            DefaultUri = defaultUri;
            DefualtOutputPath = defualtoutputPath;
        }
    }
}
