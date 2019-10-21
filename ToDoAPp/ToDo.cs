using System;
using System.Collections.Generic;

namespace ToDoApp
{
    public class ToDo
    {
        private readonly Dictionary<int, string> taskDictionary = new Dictionary<int, string>();
        private readonly List<int> taskNumbersComplate = new List<int>();
        private readonly Dictionary<int, string> menuDictionary = new Dictionary<int, string>()
        {
            [1] = "Create a Task",
            [2] = "Exit the App"
        };

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

        public void DisplayTasksOnConsole()
        {
            foreach(var(taskNumber, task) in taskDictionary)
            {
                Console.WriteLine($"{taskNumber} - {task}");
            }
        }

        public Dictionary<int, string> MenuDictionary()
        {
            return menuDictionary;
        }

        public void DisplayMenuOptionsOnConsole()
        {
            foreach (var (menuNumber, menuOption) in menuDictionary)
            {
                Console.WriteLine($"{menuNumber} - {menuOption}");
            }
        }

        public void UpdateTask(int taskNumber, string updatedTask)
        {
            if(taskDictionary.ContainsKey(taskNumber))
            {
                taskDictionary[taskNumber] = updatedTask;
            }
        }

        public void MarkTaskComplete(int taskNumber)
        {
            string appendToCompleteTask = "  X  " + "Completed on " + DateTime.Now.ToString("MM-dd-yyyy");

            if (taskDictionary.ContainsKey(taskNumber) && !taskNumbersComplate.Contains(taskNumber))
            {
                string task = taskDictionary[taskNumber];
                taskDictionary[taskNumber] = string.Concat(task, appendToCompleteTask);
                taskNumbersComplate.Add(taskNumber);
            }

        }

        public void ToDoAppLoop()
        {
            bool status = true;
            int userTaskNumberInput;

            Console.WriteLine("Welcome To The To-Do App");
               
            while (status == true)
            {                
                CondtionallyDisplayUpdateOption();
                CondtionallyDisplayCompleteOption();
                Console.WriteLine("To-Do App Menu");
                DisplayMenuOptionsOnConsole();
                Console.Write("Select option number from the menu >>  ");
                string userInput = Console.ReadLine().ToString();

                if (userInput == "1")
                {
                    Console.Write("Create a task >> ");
                    userInput = Console.ReadLine().ToString();
                    CreateTask(userInput);
                    Console.Clear();
                    DisplayTasksOnCosole();

                }
                else if (userInput == "2")
                {
                    status = false;
                }
                else if (userInput == "3" && TasksDictionary().Count != 0)
                {
                    Console.WriteLine("Which task number would you like to update?");
                    userTaskNumberInput = Int32.Parse(Console.ReadLine());
                    Console.Write("Update task number " + userTaskNumberInput + " >>");
                    userInput = Console.ReadLine();
                    UpdateTask(userTaskNumberInput, userInput);
                    DisplayTasksOnCosole();
                }
                else if (userInput == "4" && TasksDictionary().Count != 0)
                {
                    Console.WriteLine("Which task number would you like to mark as complete?");
                    if(Int32.TryParse(Console.ReadLine(), out userTaskNumberInput))
                    {
                        MarkTaskComplete(userTaskNumberInput);
                    }
                    DisplayTasksOnCosole();

                }
            }

        }

        private void DisplayTasksOnCosole()
        {
            Console.WriteLine("Your tasks");
            DisplayTasksOnConsole();
        }

        private void CondtionallyDisplayUpdateOption()
        {
            if (TasksDictionary().Count != 0)
            {
                menuDictionary.Remove(3);
                MenuDictionary().Add(3, "Update a Task");
            }
        }

        private void CondtionallyDisplayCompleteOption()
        {
            if (TasksDictionary().Count != 0)
            {
                menuDictionary.Remove(4);
                MenuDictionary().Add(4, "Mark Task as Complete");
            }
        }

    }
}
