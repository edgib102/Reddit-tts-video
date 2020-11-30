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
        public static void getpost(List<DirectoryInfo> DirList)
        {
            var RedditConfig = ConfigProvider.GetRedditConfig();
            var GeneralConfig = ConfigProvider.GetGeneralConfig();
            var reddit = new RedditClient(appId: RedditConfig.AppId, refreshToken: RedditConfig.RefreshToken, appSecret: RedditConfig.ClientSecret);
            var subreddit = reddit.Subreddit("AskReddit");
            
            

            Console.WriteLine($"App Id: {RedditConfig.AppId}\nRefresh Token: {RedditConfig.RefreshToken}\nClient Secret: {RedditConfig.ClientSecret}");

            #region
            

            Console.WriteLine("\nGetting post index...");
            int postindex = GetIndex(0);
            Console.WriteLine("\nFinished getting post index");

            Console.WriteLine("\nGetting comments to list");
            List<string> comments = GetText(postindex);
            Console.WriteLine("\nFinished getting comments to list");

            Console.WriteLine("\nWriting comments to file");
            WriteToFile(comments);
            Console.WriteLine("\nFinished writing comments to file");
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

            void WriteToFile(List<string> comments)
            {
                File.WriteAllLines(DirList[1].FullName + @"\TestTxt.txt", comments);
            }
        }
    }
}
