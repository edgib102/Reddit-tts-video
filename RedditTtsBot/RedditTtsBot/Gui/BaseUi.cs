using RedditTtsBot.General;
using System;
using System.IO;

namespace RedditTtsBot.Gui
{
    class BaseUi
    {
        public static OptionsClass ui()
        {
            Uri Url = null;
            DirectoryInfo OutputPath = null;
            var config = ConfigProvider.GetGeneralConfig();

            Url = GetUri();
            Console.WriteLine($"Url is: {Url}");

            OutputPath = GetDirectoryInfo();
            Console.WriteLine($"Output path is: {OutputPath}\n");

            return new OptionsClass(Url, OutputPath);


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
        }


    }
}
