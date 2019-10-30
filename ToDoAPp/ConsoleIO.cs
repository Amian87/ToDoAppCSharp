using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoApp
{
    public class ConsoleIO : IConsoleIO
    {
        public string ConsoleRead()
        {
            return Console.ReadLine();
        }

        public void ConsoleWrite(string text)
        {
            Console.WriteLine(text);
        }

        public void ConsoleWriteInLine(string text)
        {
            Console.Write(text);
        }

        public void ConsoleClear()
        {
            Console.Clear();
        }
    }
}
