using System;
using ToDoApp;

namespace ToDoAppConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            ToDo todo = new ToDo();
            Console.WriteLine("Welcome To To-Do App");
            
            Console.WriteLine("Create a task >>");
            todo.CreateTask(Console.ReadLine().ToString());
            Console.WriteLine(todo.ListOfTasks()[1]);
            Console.ReadLine();
      
        }
    }
}
