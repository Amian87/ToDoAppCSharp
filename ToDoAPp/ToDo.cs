using System;
using ToDoAppServices;
using System.Collections.Generic;
using ToDoAppDomain.Classes;
using static ToDoAppDomain.Classes.DomainClasses;

namespace ToDoApp
{
    public class ToDo
    {
        private static ToDoContext context = new ToDoContext();
        private ToDoAppService tds = new ToDoAppService(context);





        private readonly Dictionary<int, string> taskDictionary = new Dictionary<int, string>();
        private readonly List<int> taskNumbersComplete = new List<int>();
        private readonly Dictionary<int, string> menuDictionary = new Dictionary<int, string>()
        {
            [1] = "Create a Task",
            [2] = "Exit the App"
        };

        public Dictionary<int, string> TasksDictionary()
        {
            return taskDictionary;
        }

        public List<TaskDTO> GetAllTasksFromDB()
        {
            var tasks = tds.GetAllTasks();
            return tasks;
        }


        public void DisplayTasksOnConsole(List<TaskDTO> tasks)
        {
            for(int i = 0; i < tasks.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {tasks[i].TaskDescription}");
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

            if (taskDictionary.ContainsKey(taskNumber) && !taskNumbersComplete.Contains(taskNumber))
            {
                string task = taskDictionary[taskNumber];
                taskDictionary[taskNumber] = string.Concat(task, appendToCompleteTask);
                taskNumbersComplete.Add(taskNumber);
            }

        }

        public void ToDoAppLoop()
        {
            bool status = true;
            int userTaskNumberInput;
         

            Console.WriteLine("Welcome To The To-Do App");
               
            while (status == true)
            {
                List<TaskDTO> allTasks = GetAllTasksFromDB();
                WriteTasksOnConsole(allTasks);
                CondtionallyDisplayUpdateAndCompleteMenuOptions(allTasks);
                Console.WriteLine("To-Do App Menu");
                DisplayMenuOptionsOnConsole();
                Console.Write("Select option number from the menu >> ");
                string userInput = Console.ReadLine().ToString();

                if (userInput == "1")
                {
                    Console.Write("Create a task >> ");
                    userInput = Console.ReadLine().ToString();
                    tds.CreateTask(userInput, false, DateTime.Today);
                }
                else if (userInput == "2")
                {
                    status = false;
                }
                else if (userInput == "3" && TasksDictionary().Count != 0)
                {
                    Console.WriteLine("Which task number would you like to update?");
                    if(Int32.TryParse(Console.ReadLine(), out userTaskNumberInput))
                    {
                        Console.Write("Update task number " + userTaskNumberInput + " >> ");
                        userInput = Console.ReadLine();
                        UpdateTask(userTaskNumberInput, userInput);
                    }
                }
                else if (userInput == "4" && TasksDictionary().Count != 0)
                {
                    Console.WriteLine("Which task number would you like to mark as complete?");
                    if(Int32.TryParse(Console.ReadLine(), out userTaskNumberInput))
                    {
                        MarkTaskComplete(userTaskNumberInput);
                    }
                }
            }

        }

        private void WriteTasksOnConsole(List<TaskDTO> tasks)
        {
            if (tasks.Count != 0)
            {
                Console.Clear();
                Console.WriteLine("Your tasks");
                DisplayTasksOnConsole(tasks);
            }
        }

        private void CondtionallyDisplayUpdateAndCompleteMenuOptions(List<TaskDTO> tasks)
        {
            if (tasks.Count != 0)
            {
                MenuDictionary().Remove(3);
                MenuDictionary().Add(3, "Update a Task");
                MenuDictionary().Remove(4);
                MenuDictionary().Add(4, "Mark Task as Complete");
            }
        }

    }
}
