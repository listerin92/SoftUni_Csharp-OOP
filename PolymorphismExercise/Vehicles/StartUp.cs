using System;
using Vehicles.Core.Contracts;

namespace Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
