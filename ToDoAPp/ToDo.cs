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
        private readonly ToDoAppService service = new ToDoAppService(context);
        private List<TaskDTO> listOfTasks;
        private List<ListDTO> availableLists = new List<ListDTO>();
        private int listNumber;
        private string userInput;
        private int listID;
        private string listName;
        private bool displayListFlag = false;
        private IConsoleIO consoleIO;
        private ToDoConsoleGUI toDoConsoleGUI;

        public ToDo(IConsoleIO cIO)
        {
            consoleIO = cIO;
            toDoConsoleGUI = new ToDoConsoleGUI();
        }

        public void DisplayTasksOnConsole()
        {
            for(int i = 0; i < listOfTasks.Count; i++)
            {
                if(listOfTasks[i].TaskStatus)
                {
                    consoleIO.ConsoleWrite($"{i + 1} - {listOfTasks[i].TaskDescription} X Completed On {listOfTasks[i].CompletionDate}");
                }
                else
                {
                    consoleIO.ConsoleWrite($"{i + 1} - {listOfTasks[i].TaskDescription}");
                }
            }
        }

        public void DisplayListsOnConsole()
        {
            foreach(string listItem in toDoConsoleGUI.FormatListNames(availableLists))
            {
                consoleIO.ConsoleWrite(listItem);
            }
        }

        public void DisplayMenuOptionsOnConsole(Dictionary<int,string> menuDictionary)
        {
            foreach (var (menuNumber, menuOption) in menuDictionary)
            {
                consoleIO.ConsoleWrite($"{menuNumber} - {menuOption}");
            }
        }

        public void UpdateTask(int taskNumber, string taskDescription, List<TaskDTO> listOfTasks)
        {
            int taskID = listOfTasks[taskNumber - 1].TaskID;
            service.UpdateTask(taskDescription, taskID, listID);
        }


        public void ToDoAppLoop()
        {
            bool status = true;
            int userTaskNumberInput;

            consoleIO.ConsoleWrite("Welcome To The To-Do App");
               
            while (status == true)
            {
                availableLists = service.GetAllLists();
                WriteListsOnConsole();

                if (userInput == "1" && displayListFlag == false)
                {
                    consoleIO.ConsoleWrite("Create a List >> ");
                    userInput = consoleIO.ConsoleRead();
                    service.CreateList(userInput);
                }

                else if (userInput == "2" && displayListFlag == false)
                {
                    consoleIO.ConsoleWrite("Select the list number >> ");
                    displayListFlag = true;

                    if (Int32.TryParse(consoleIO.ConsoleRead(), out listNumber) && listNumber <= availableLists.Count)
                    {
                        listID = availableLists[listNumber - 1].ListID;
                        listName = availableLists[listNumber - 1].ListName;
                       
                    }
                }
                else if (userInput == "1" && displayListFlag == true)
                {
                    consoleIO.ConsoleWrite("Create a task >> ");
                    userInput = consoleIO.ConsoleRead();
                    if (userInput != "")
                    {
                        service.CreateTask(userInput, listID);
                    }

                }
                else if (userInput == "2" && listOfTasks.Count != 0 && displayListFlag == true)
                {
                    consoleIO.ConsoleWrite("Which task number would you like to update?");
                    if (Int32.TryParse(consoleIO.ConsoleRead(), out userTaskNumberInput) && userTaskNumberInput < listOfTasks.Count)
                    {
                        consoleIO.ConsoleWrite("Update task number " + userTaskNumberInput + " >> ");
                        userInput = consoleIO.ConsoleRead();
                        UpdateTask(userTaskNumberInput, userInput, listOfTasks);
                    }
                }
                else if (userInput == "3"  && displayListFlag == true )
                {
                    consoleIO.ConsoleWrite("Which task number would you like to mark as complete?");
                    if (Int32.TryParse(consoleIO.ConsoleRead(), out userTaskNumberInput) && userTaskNumberInput <= listOfTasks.Count)
                    {

                        if (listOfTasks[userTaskNumberInput - 1].TaskStatus == false)
                        {
                            int taskID = listOfTasks[userTaskNumberInput - 1].TaskID;
                            service.CompleteTask(taskID);
                        }

                    }

                }

                else if (userInput == "3" && displayListFlag == false)
                {
                    status = false;
                }

                else if (userInput == "4" && displayListFlag == true)
                {
                    displayListFlag = false;
                }
            }
        }

        private void WriteListsOnConsole()
        {
            if (availableLists.Count >= 0 && displayListFlag == false)
            {
                consoleIO.ConsoleClear();
                consoleIO.ConsoleWrite("Your Lists");
                DisplayListsOnConsole();
                consoleIO.ConsoleWrite("To-Do App Menu");
                DisplayMenuOptionsOnConsole(toDoConsoleGUI.ListMenuOptions());
            }
            else
            {
                DisplayListOfTasksBasedOnSelectedList();
                consoleIO.ConsoleWrite("To-Do App Menu");
                DisplayMenuOptionsOnConsole(toDoConsoleGUI.TaskMenuOptions());
            }
            consoleIO.ConsoleWriteInLine("Select option number from the menu >> ");
            userInput = consoleIO.ConsoleRead();
        }

        private void DisplayListOfTasksBasedOnSelectedList()
        {
            listOfTasks = service.GetAllTasksInList(listID);
            WriteTasksOnConsole();
        }

        private void WriteTasksOnConsole()
        {
            if (listOfTasks.Count != 0)
            {
                consoleIO.ConsoleClear();
                consoleIO.ConsoleWrite("Your tasks in List " + listName);
                DisplayTasksOnConsole();
            }
            else
            {
                consoleIO.ConsoleClear();
                consoleIO.ConsoleWrite("Create tasks in " + listName + " list");
            }
        }
    }
}
