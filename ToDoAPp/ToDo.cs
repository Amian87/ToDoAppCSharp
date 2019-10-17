using System;
using System.Collections.Generic;

namespace ToDoApp
{
    public class ToDo
    {
        private Dictionary<int, string> taskDictionary = new Dictionary<int, string>();

        public void CreateTask(string task)
        {
            if(taskDictionary.ContainsKey(taskDictionary.Count))
            {
                ListOfTasks().Add(taskDictionary.Count + 1, task);
            }
            else
            {
                ListOfTasks().Add(1, task);
            }
        }

        public Dictionary<int, string> ListOfTasks()
        {
            return taskDictionary;
        }

        public void DisplayTasksOnConsole()
        {
            foreach(var(taskNumber, task) in taskDictionary)
            {
                Console.WriteLine($"{taskNumber} - {task}");
            }
        }

        public void ToDoAppLoop()
        {
            bool status = true;

            Console.Write("Welcome To To-Do App");
            Console.Write("  ---- Press enter -----");

            do
            {
                
                if(Console.ReadLine().ToLower().ToString() == "exit")
                {
                    status = false;
                }
                else
                {
                    Console.Write("Create a task >> ");
                    CreateTask(Console.ReadLine().ToString());
                    Console.Clear();
                    Console.WriteLine("Your tasks");
                    DisplayTasksOnConsole();
                }
            } while (status);

        }
    }
}
