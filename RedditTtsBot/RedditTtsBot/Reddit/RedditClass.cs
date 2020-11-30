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
            var reddit = new RedditClient(appId: RedditConfig.AppId, refreshToken: RedditConfig.RefreshToken, appSecret: RedditConfig.ClientSecret);
            var subreddit = reddit.Subreddit("AskReddit");

            #region


            int postindex = GetIndex(0);


            #endregion

            int GetIndex(int postindex)
            {
                var post = subreddit.Posts.Hot[postindex];
                try
                {
                    var x = post.Comments.Top[0];
                    return postindex;
                }
                catch (Exception e)
                {
                    postindex++;
                    return GetIndex(postindex);
                }
            }

        }
    }
}
