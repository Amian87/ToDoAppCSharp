using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoApp
{
    public interface IConsoleIO
    {
        string ConsoleRead();
        void ConsoleWrite(string text);
        void ConsoleWriteInLine(string text);
        void ConsoleClear();
    }
}
