using System;
using Newtonsoft.Json;


namespace RedditTtsBot.General.General_classes.Config
{
    public interface IRedditConfig
    {
        string AppId { get; set; }
        string RefreshToken { get; set; }
        string ClientSecret { get; set; }
    }

    public class RedditConfig : IRedditConfig
    {
        [JsonProperty("appId")]
        public string AppId { get; set; }

        [JsonProperty("refreshToken")]
        public string RefreshToken { get; set; }

        [JsonProperty("clientSecret")]
        public string ClientSecret { get; set; }


        public RedditConfig(string appId, string refreshToken, string clientSecret)
        {
            AppId = appId;
            RefreshToken = refreshToken;
            ClientSecret = clientSecret;
        }


    }
}
