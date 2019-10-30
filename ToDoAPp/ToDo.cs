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
        private List<TaskDTO> listOfTasks;
        private List<ListDTO> availableLists = new List<ListDTO>();
        private int listNumber;
        private string userInput;
        private int listID;
        private string listName;
        private bool displayListFlag = false;
   

        private readonly Dictionary<int, string> menuDictionary = new Dictionary<int, string>();

        public List<TaskDTO> GetAllTasksFromDB()
        {
            var tasks = tds.GetAllTasksInList(listID);
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

        public void DisplayListsOnConsole(List<ListDTO> list)
        {
            for(int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {list[i].ListName}");
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
            tds.UpdateTask(taskDescription, taskID, listID);
        }


        public void ToDoAppLoop()
        {
            bool status = true;
            int userTaskNumberInput;

            Console.WriteLine("Welcome To The To-Do App");
               
            while (status == true)
            {
                availableLists = tds.GetAllLists();
                WriteListsOnConsole();

                if (userInput == "1" && displayListFlag == false)
                {
                    Console.Write("Create a List >> ");
                    userInput = Console.ReadLine().ToString();
                    tds.CreateList(userInput);
                }

                else if (userInput == "2" && displayListFlag == false)
                {
                    Console.Write("Select the list number >> ");
                    displayListFlag = true;

                    if (Int32.TryParse(Console.ReadLine(), out listNumber) && listNumber <= availableLists.Count)
                    {
                        listID = availableLists[listNumber - 1].ListID;
                        listName = availableLists[listNumber - 1].ListName;
                       
                    }
                }
                else if (userInput == "1" && displayListFlag == true)
                {
                    Console.Write("Create a task >> ");
                    userInput = Console.ReadLine().ToString();
                    if (userInput != "")
                    {
                        tds.CreateTask(userInput, listID);
                    }

                }
                else if (userInput == "2" && listOfTasks.Count != 0 && displayListFlag == true)
                {
                    Console.WriteLine("Which task number would you like to update?");
                    if (Int32.TryParse(Console.ReadLine(), out userTaskNumberInput) && userTaskNumberInput < listOfTasks.Count)
                    {
                        Console.Write("Update task number " + userTaskNumberInput + " >> ");
                        userInput = Console.ReadLine();
                        UpdateTask(userTaskNumberInput, userInput, listOfTasks);
                    }
                }
                else if (userInput == "3" && listOfTasks.Count != 0 && displayListFlag == true )
                {
                    Console.WriteLine("Which task number would you like to mark as complete?");
                    if (Int32.TryParse(Console.ReadLine(), out userTaskNumberInput) && userTaskNumberInput < listOfTasks.Count)
                    {
                        if (listOfTasks[userTaskNumberInput - 1].TaskStatus != true)
                        {
                            int taskID = listOfTasks[userTaskNumberInput - 1].TaskID;
                            tds.CompleteTask(taskID);
                        }

                    }

                }



                else if (userInput == "3" )
                {
                    status = false;
                }

                else if (userInput == "4")
                {
                    displayListFlag = false;
                }


            }

        }



        private void WriteListsOnConsole()
        {
            if (availableLists.Count >= 0 && displayListFlag == false)
            {
                Console.Clear();
                Console.WriteLine("Your Lists");
                DisplayListsOnConsole(availableLists);
                CondtionallyDisplayListMenuOptions();
                Console.WriteLine("To-Do App Menu");
                DisplayMenuOptionsOnConsole();
                Console.Write("Select option number from the menu >> ");
                userInput = Console.ReadLine().ToString();
            }
            else
            {
                DisplayListOfTasksBasedOnSelectedList();
                CondtionallyDisplayUpdateAndCompleteMenuOptions();
                Console.WriteLine("To-Do App Menu");
                DisplayMenuOptionsOnConsole();
                Console.Write("Select option number from the menu >> ");
                userInput = Console.ReadLine().ToString();

            }
        }

        private void DisplayListOfTasksBasedOnSelectedList()
        {
            listOfTasks = GetAllTasksFromDB();
            WriteTasksOnConsole(listOfTasks);            
        }

        private void WriteTasksOnConsole(List<TaskDTO> listOfTasks)
        {
            if (listOfTasks.Count != 0)
            {
                Console.Clear();
                Console.WriteLine("Your tasks in List " + listName);
                DisplayTasksOnConsole(listOfTasks);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Create tasks in " + listName + " list");
            }

        }


        private void CondtionallyDisplayListMenuOptions()
        {
            if(availableLists.Count >= 0)
            {
                MenuDictionary().Remove(1);
                MenuDictionary().Add(1, "Create a List");
                MenuDictionary().Remove(2);
                MenuDictionary().Add(2, "Open a List");
                MenuDictionary().Remove(3);
                MenuDictionary().Add(3, "Exit the App");
                MenuDictionary().Remove(4);
            }
        }



        private void CondtionallyDisplayUpdateAndCompleteMenuOptions()
        {
            if (listOfTasks.Count >= 0)
            {
                MenuDictionary().Remove(1);
                MenuDictionary().Add(1, "Create a Task");
                MenuDictionary().Remove(2);
                MenuDictionary().Add(2, "Update a Task");
                MenuDictionary().Remove(3);
                MenuDictionary().Add(3, "Mark Task as Complete");
                MenuDictionary().Remove(4);
                MenuDictionary().Add(4, "Return to lists menu");
            }
        }

    }
}
