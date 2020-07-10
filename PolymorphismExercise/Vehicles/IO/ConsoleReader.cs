using System;
using Vehicles.IO.Contracts;

namespace Vehicles.IO
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}