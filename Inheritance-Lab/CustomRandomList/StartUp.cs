using System;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList list = new RandomList();
            list.Add("1asdfas sdfasdf");
            list.Add("2asdfas sdfasdf");
            list.Add("3asdfas sdfasdf");
            list.Add("4asdfas sdfasdf");
            list.Add("5asdfas sdfasdf");
            list.RandomString();
        }
    }
}
