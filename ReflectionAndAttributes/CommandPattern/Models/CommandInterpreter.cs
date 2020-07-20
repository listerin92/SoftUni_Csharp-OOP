using System;
using System.Linq;
using System.Reflection;
using CommandPattern.Core.Contracts;

namespace CommandPattern.Models
{
    //Holds all the reflection we should do in order to execute a command
    public class CommandInterpreter : ICommandInterpreter
    {
        private const string COMMAND_POSTFIX = "Command";
        public CommandInterpreter()
        {

        }
        /// <summary>
        /// Parse Input and execute correct commands
        /// </summary>
        /// <param name="args">Input</param>
        /// <returns></returns>
        public string Read(string args)
        {
            string[] commandTokens = args
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            string commandName = commandTokens[0] + COMMAND_POSTFIX;
            string[] commandArgs = commandTokens
                .Skip(1)
                .ToArray();

            //Get assembly to get types
            Assembly assembly = Assembly.GetCallingAssembly();

            //Get command type in order to produce correct command
            Type commandType = assembly
                .GetTypes()
                .FirstOrDefault(t =>
                    t.Name.ToLower() == commandName.ToLower());

            if (commandType == null)
            {
                throw new ArgumentException("Invalid command type!");
            }

            //Create instance of command in order to invoke Execute()
            ICommand commandInstance =
                (ICommand)Activator.CreateInstance(commandType);
            string result = commandInstance?.Execute(commandArgs);

            return result;
        }
    }
}