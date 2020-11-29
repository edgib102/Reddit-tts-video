using System;
using RedditTtsBot.General;
using Reddit;

namespace RedditTtsBot.Reddit
{
    public class RedditClass
    {
        public static void getpost()
        {
            var RedditConfig = ConfigProvider.GetRedditConfig();
            var reddit = new RedditClient(appId:RedditConfig.AppId, refreshToken:RedditConfig.RefreshToken, appSecret:RedditConfig.ClientSecret);

            Console.WriteLine($"App Id: {RedditConfig.AppId}\nRefresh Token: {RedditConfig.RefreshToken}\nApp Secret: {RedditConfig.ClientSecret}");
            //var askReddit = reddit.Subreddit("AskReddit").About();
            //Console.WriteLine(askReddit);


        }
    }
}
