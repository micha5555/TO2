using System;

namespace BDDTests.ConsoleManager
{
    public class ConsoleManager : ConsoleManagerBase
    {
        public override void Clear()
        {
            Console.Clear();
        }

        public override ConsoleKeyInfo ReadKey()
        {
            return Console.ReadKey();
        }

        public override string ReadLine()
        {
            return Console.ReadLine();
        }

        public override void Write(string value)
        {
            Console.Write(value);
        }

        public override void WriteLine(string value)
        {
            Console.WriteLine(value);
        }
    }
}