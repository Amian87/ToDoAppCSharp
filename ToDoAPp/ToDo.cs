using System;
using ToDoAppServices;
using System.Collections.Generic;
using ToDoAppDomain.Classes;
using static ToDoAppDomain.Classes.DomainClasses;

namespace ToDoApp
{
    public class ToDo
    {
        private readonly static ToDoContext context = new ToDoContext();
        private readonly ToDoAppService tds = new ToDoAppService(context);
        public List<TaskDTO> listOfTasks;
        private readonly Dictionary<int, string> menuDictionary = new Dictionary<int, string>()
        {
            [1] = "Create a Task",
            [2] = "Exit the App"
        };

        public List<TaskDTO> GetAllTasksFromDB()
        {
            var tasks = tds.GetAllTasks();
            return tasks;
        }


        public void DisplayTasksOnConsole(List<TaskDTO> tasks)
        {
            int taskNumber = 0;

            for(int i = 0; i < tasks.Count; i++)
            {
                if(tasks[i].TaskStatus == true)
                {
                    Console.WriteLine($"{taskNumber + 1} - {tasks[i].TaskDescription} X Completed On {tasks[i].CompletionDate}");
                    taskNumber += 1;
                }

                if (tasks[i].TaskStatus == false)
                {
                    Console.WriteLine($"{taskNumber + 1} - {tasks[i].TaskDescription}");
                    taskNumber += 1;
                }
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

        public void UpdateTask(int taskNumber, string taskDescription, List<TaskDTO> listOfTasks)
        {
            int taskID = listOfTasks[taskNumber - 1].TaskID;
            tds.UpdateTask(taskDescription, taskID);
        }


        public void ToDoAppLoop()
        {
            bool status = true;
            int userTaskNumberInput;
         

            Console.WriteLine("Welcome To The To-Do App");
               
            while (status == true)
            {
                listOfTasks = GetAllTasksFromDB();
                WriteTasksOnConsole(listOfTasks);
                CondtionallyDisplayUpdateAndCompleteMenuOptions(listOfTasks);
                Console.WriteLine("To-Do App Menu");
                DisplayMenuOptionsOnConsole();
                Console.Write("Select option number from the menu >> ");
                string userInput = Console.ReadLine().ToString();

                if (userInput == "1")
                {
                    Console.Write("Create a task >> ");
                    userInput = Console.ReadLine().ToString();
                    tds.CreateTask(userInput);
                }
                else if (userInput == "2")
                {
                    status = false;
                }
                else if (userInput == "3" && listOfTasks.Count != 0)
                {
                    Console.WriteLine("Which task number would you like to update?");
                    if(Int32.TryParse(Console.ReadLine(), out userTaskNumberInput) && userTaskNumberInput < listOfTasks.Count)
                    {
                        Console.Write("Update task number " + userTaskNumberInput + " >> ");
                        userInput = Console.ReadLine();
                        UpdateTask(userTaskNumberInput, userInput, listOfTasks);
                    }
                }
                else if (userInput == "4" && listOfTasks.Count != 0)
                {
                    Console.WriteLine("Which task number would you like to mark as complete?");
                    if(Int32.TryParse(Console.ReadLine(), out userTaskNumberInput) && userTaskNumberInput < listOfTasks.Count)
                    {
                        if(listOfTasks[userTaskNumberInput -1].TaskStatus != true)
                        {
                            int taskID = listOfTasks[userTaskNumberInput - 1].TaskID;
                            tds.CompleteTask(taskID);
                        }

                    }
                }
            }

        }

        private void WriteTasksOnConsole(List<TaskDTO> listOfTasks)
        {
            if (listOfTasks.Count != 0)
            {
                Console.Clear();
                Console.WriteLine("Your tasks");
                DisplayTasksOnConsole(listOfTasks);
            }
        }

        private void CondtionallyDisplayUpdateAndCompleteMenuOptions(List<TaskDTO> listOfTasks)
        {
            if (listOfTasks.Count != 0)
            {
                MenuDictionary().Remove(3);
                MenuDictionary().Add(3, "Update a Task");
                MenuDictionary().Remove(4);
                MenuDictionary().Add(4, "Mark Task as Complete");
            }
        }

    }
}
