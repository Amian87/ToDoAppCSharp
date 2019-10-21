using System;
using ToDoApp;

namespace ToDoAppConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            ToDo todo = new ToDo();
            //todo.MenuDictionary().Add(3, "Exit the App");
            todo.ToDoAppLoop();
  
      
        }
    }
}
