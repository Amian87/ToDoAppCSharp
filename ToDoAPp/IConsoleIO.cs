using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoApp
{
    public interface IConsoleIO
    {
        public string ConsoleRead();
        public void ConsoleWrite(string text);
        public void ConsoleWriteInLine(string text);
        public void ConsoleClear();
    }
}
