using System;

namespace BDDTests.ConsoleManager
{
    public abstract class ConsoleManagerBase : IConsoleManager
    {
        public abstract void Clear();
        public abstract ConsoleKeyInfo ReadKey();
        public abstract string ReadLine();
        public abstract void Write(string value);
        public abstract void WriteLine(string value);
    }
}