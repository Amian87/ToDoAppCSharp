using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoApp
{
    public class MockConsoleIO : IConsoleIO
    {
        public string ConsoleRead()
        {
            return "3";
        }

        public void ConsoleWrite(string text){}
        public void ConsoleWriteInLine(string text) { }
        public void ConsoleClear() { }
    }
}
