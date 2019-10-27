using System;
using System.Data.Entity;
using ToDoApp;
using static ToDoApp.ToDoClasses;

namespace ToDoAppConsole
{

    class Program
    {
        static void Main( )
        {
            ToDo todo = new ToDo();  
            todo.ToDoAppLoop();
        }

    

    }


}
