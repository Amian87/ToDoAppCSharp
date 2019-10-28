using System;
using System.Data.Entity;
using ToDoApp;
using ToDoAppServices;

namespace ToDoAppConsole
{
    class Program
    {
        static void Main(string[] args)
        {          
            ToDo todo = new ToDo();
            todo.ToDoAppLoop();
        }
    }
}
