using VehiclesExtension.Core;
using VehiclesExtension.Core.Contracts;
using VehiclesExtension.IO;
using VehiclesExtension.IO.Contracts;

namespace VehiclesExtension
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            IEngine engine = new Engine(reader, writer);
            engine.Run();
        }
    }
}
