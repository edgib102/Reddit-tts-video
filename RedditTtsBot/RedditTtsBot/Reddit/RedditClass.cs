using System;
using System.IO;
using System.Collections.Generic;
using RedditTtsBot.General;
using Reddit;
using Reddit.Controllers;



namespace RedditTtsBot.Reddit
{
    public class RedditClass
    {
        public static void getpost()
        {
            var RedditConfig = ConfigProvider.GetRedditConfig();
            var GeneralConfig = ConfigProvider.GetGeneralConfig();
            var reddit = new RedditClient(appId: RedditConfig.AppId, refreshToken: RedditConfig.RefreshToken, appSecret: RedditConfig.ClientSecret);
            var subreddit = reddit.Subreddit("AskReddit");
            
            

            Console.WriteLine($"App Id: {RedditConfig.AppId}\nRefresh Token: {RedditConfig.RefreshToken}\nClient Secret: {RedditConfig.ClientSecret}");

            #region

            //StreamWriter TxtOutput = new StreamWriter(GeneralConfig.DefualtOutputPath + @"\TestTxt.txt", append: true);
            
            //TxtOutput.WriteLine("test");
            

            Console.WriteLine("\nGetting post index...");
            int postindex = GetIndex(0);
            Console.WriteLine("\nFinished getting post index");

            Console.WriteLine("\nGetting comments to list");
            GetText(postindex);
            Console.WriteLine("\nFinished getting comments to list");
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

            List<string> GetText(int index)
            {
                var post = subreddit.Posts.Hot[index];
                List<string> CommentText = new List<string>();

                int CommentLimit = 10;
                int CurrentComments = 0;
                
                foreach (Comment comment in post.Comments.Top)
                {
                    CommentText.Add(comment.Body);
                    CurrentComments++;

                    if (CurrentComments >= CommentLimit)
                    {
                        break;
                    }
                   
                }
                return CommentText;
            }
        }
    }
}
