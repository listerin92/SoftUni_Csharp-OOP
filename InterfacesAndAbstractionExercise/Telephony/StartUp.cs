using System;

namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] phones = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] websites = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Smartphone smartphone = new Smartphone();
            StationaryPhone stationaryPhone = new StationaryPhone();

            for (int i = 0; i < phones.Length; i++)
            {
                try
                {
                    if (phones[i].Length == 10)
                    {
                        smartphone.PhoneNumber = phones[i];
                        Console.WriteLine(smartphone.CallOtherPhone());
                    }
                    else if (phones[i].Length == 7)
                    {
                        stationaryPhone.PhoneNumber = phones[i];
                        Console.WriteLine(stationaryPhone.CallOtherPhone());
                    }
                    else
                    {
                        throw new ArgumentException("Invalid number!");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            for (int i = 0; i < websites.Length; i++)
            {
                try
                {
                    smartphone.Website = websites[i];
                    Console.WriteLine(smartphone.Browse());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}