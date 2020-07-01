using System;

namespace CustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            StackOfStrings stackOfStrings = new StackOfStrings();
            stackOfStrings.Push("asdf");
            Console.WriteLine(stackOfStrings.IsEmpty());
        }
    }
}
