using System;

namespace PlayersAndMonsters
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            MuseElf museElf = new MuseElf("luzterin", 15);
            Console.WriteLine(museElf.ToString());
            Elf elf = new Elf("Elfata", 12);
            Console.WriteLine(elf.ToString());
        }
    }
}