using System;
using System.Collections.Generic;

namespace ToDoApp
{
    public class ToDo
    {
        private readonly Dictionary<int, string> taskDictionary = new Dictionary<int, string>();
        private readonly Dictionary<int, string> menuDictionary = new Dictionary<int, string>();

        public void CreateTask(string task)
        {
            if(taskDictionary.ContainsKey(taskDictionary.Count))
            {
                TasksDictionary().Add(taskDictionary.Count + 1, task);
            }
            else
            {
                TasksDictionary().Add(1, task);
            }
        }

        public Dictionary<int, string> TasksDictionary()
        {
            return taskDictionary;
        }

        private string formattedTask(int taskNumber, string taskDescription)
        {
            return $"{taskNumber} - {taskDescription}";
        }

        public void DisplayTasksOnConsole()
        {
            foreach(var(taskNumber, task) in taskDictionary)
            {
                Console.WriteLine($"{taskNumber} - {task}");
            }
        }

        //public void AddMenuOptions()
        //{
        //    MenuDictionary().Add(1, "Create a Task");
        //    MenuDictionary().Add(2, "2Exit the App");
        //    MenuDictionary().Add(3, "1Exit the App");
        //}

        //public Dictionary<int, string> MenuDictionary()
        //{
        //    return menuDictionary;
        //}

        //public void DisplayMenuOptionsOnConsole()
        //{
        //    foreach (var (menuNumber, menuOption) in menuDictionary)
        //    {
        //        Console.WriteLine($"{menuNumber} - {menuOption}");
        //    }
        //}


        public void ToDoAppLoop()
        {
            bool status = true;
            string userInput = "";

            Console.WriteLine("Welcome To The To-Do App");
            //DisplayMenuOptionsOnConsole();

            while(status == true)
            {
                Console.Write("Create a task >> ");
                userInput = Console.ReadLine().ToString();
                if(userInput.ToLower() == "exit")
                {
                    status = false;
                }
                else
                {
                    CreateTask(userInput);
                    Console.Clear();
                    Console.WriteLine("Your tasks");
                    DisplayTasksOnConsole();
                }
            }

        }
    }
}
