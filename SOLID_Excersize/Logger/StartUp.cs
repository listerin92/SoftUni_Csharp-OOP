using System;
using System.Collections.Generic;
using System.Linq;
using Logger.Core;
using Logger.Core.Contracts;
using Logger.Factories;
using Logger.Models.Contracts;

namespace Logger
{
    public class StartUp
    {
        static void Main()
        {
            int appendersCount = int.Parse(Console.ReadLine());
            ICollection<IAppender> appenders = new List<IAppender>();
            ParseAppendersInput(appendersCount, appenders);

            ILogger logger = new Models.Logger(appenders);

            IEngine engine = new Engine(logger);
            engine.Run();
            
        }

        private static void ParseAppendersInput(int appendersCount, ICollection<IAppender> appenders)
        {
            AppenderFactory appenderFactory = new AppenderFactory();

            for (int i = 0; i < appendersCount; i++)
            {
                string[] appendersArg = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                string appenderType = appendersArg[0];
                string layoutType = appendersArg[1];
                string level = "INFO";

                if (appendersArg.Length == 3)
                {
                    level = appendersArg[2];
                }

                try
                {
                    IAppender appender = appenderFactory.ProduceAppender(appenderType, layoutType, level);
                    appenders.Add(appender);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
        }
    }
}