using System;
using System.Linq;
using Logger.Core.Contracts;
using Logger.Factories;
using Logger.Models.Contracts;

namespace Logger.Core
{
    public class Engine : IEngine
    {
        private ILogger logger;
        private ErrorFactory errorFactory;

        private Engine()
        {
            this.errorFactory = new ErrorFactory();
        }

        public Engine(ILogger logger)
            : this()
        {
            this.logger = logger;
        }
        public void Run()
        {
            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] inputArgs = input
                    .Split('|', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string level = inputArgs[0];
                string datetime = inputArgs[1];
                string message = inputArgs[2];

                try
                {
                    IError error = this.errorFactory.ProduceError(datetime, message, level);
                    this.logger.Log(error);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }

            Console.WriteLine(this.logger);
        }
    }
}
