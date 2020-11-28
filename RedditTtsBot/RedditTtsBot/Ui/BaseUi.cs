using System;
using System.IO;
using RedditTtsBot.General;

namespace RedditTtsBot.Gui
{
    class BaseUi
    {

        public static Options ui()
        {
            Uri Url = null;
            DirectoryInfo OutputPath = null;
            var config = ConfigProvider.GetConfig();

            Url = GetUri(); //could make method but i advise you to move on (sunken cost fallacy)
            Console.WriteLine($"Url is: {Url}");

            OutputPath = GetDirectoryInfo();
            Console.WriteLine($"Output path is: {OutputPath}\n");

            return new Options(Url, OutputPath);


            Uri GetUri()
            {
                Console.Write("Enter url (leave blank for default): ");
                string UriText = Console.ReadLine();

                try
                {
                    return new Uri(UriText, UriKind.Absolute);
                }
                catch (UriFormatException)
                {
                    if (UriText == "")
                    {
                        
                        return config.DefaultUri;
                    }
                    else
                    {
                        Console.WriteLine("failed to get proper url");
                        return GetUri();
                    }

                }
                

            }


            DirectoryInfo GetDirectoryInfo()
            {
                
                Console.Write("WARNING - MAKE SURE THIS IS CORRECT\nEnter output path (leave blank for default): ");
                string OutputText = Console.ReadLine();

                try
                {
                    
                    return new DirectoryInfo(OutputText);
                }
                catch (ArgumentException)
                {
                    if (OutputText == "")
                    {
                        Console.WriteLine("Getting default file path");
                        
                        return new DirectoryInfo(config.DefualtOutputPath);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return GetDirectoryInfo();
                }

                return GetDirectoryInfo();
            }

            //object YnConfirm(string method, string consoleAns)
            //{
            //    Console.WriteLine($"{method} is: {consoleAns}");

            //    Console.Write("Confirm? y/n: ");
            //    string ans = Console.ReadLine();

            //    if (ans == "y")
            //    {
            //        return null;
            //    }
            //    else if (ans == "n")
            //    {
            //        if (method == "Uri")
            //        {
            //            return GetUri();
            //        }
            //        else if (method == "File Path")
            //        {
            //            return GetDirectoryInfo();
            //        }
            //        else
            //        {
            //            return YnConfirm(method, consoleAns);
            //        }
            //    }
            //    else
            //    {
            //        return YnConfirm(method, consoleAns);
            //    }
            //}
        }


    }
}
