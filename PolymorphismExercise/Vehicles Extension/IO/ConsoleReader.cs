using System;
using VehiclesExtension.IO.Contracts;

namespace VehiclesExtension.IO
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}