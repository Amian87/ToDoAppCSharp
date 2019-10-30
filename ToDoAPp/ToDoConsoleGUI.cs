using System;
using System.Collections.Generic;
using System.Text;
using ToDoAppDomain.Classes;

namespace ToDoApp
{
    public class ToDoConsoleGUI
    {
        public List<string> FormatListNames(List<ListDTO> list)
        {
            List<string> listOfFormattedNames = new List<string>();

            for(int i = 0; i < list.Count; i++)
            {
                listOfFormattedNames.Add($"{i + 1} - {list[i].ListName}");
            }       
            return listOfFormattedNames;
        }

        public Dictionary<int, string> ListMenuOptions()
        {
            Dictionary<int, string> listMenuOptions = new Dictionary<int, string>();
            
            listMenuOptions.Add(1, "Create a List");
            listMenuOptions.Add(2, "Open a List");
            listMenuOptions.Add(3, "Exit the App");

            return listMenuOptions;

        }

        public Dictionary<int, string> TaskMenuOptions()
        {
            Dictionary<int, string> TaskMenuOptions = new Dictionary<int, string>();

            TaskMenuOptions.Add(1, "Create a Task");
            TaskMenuOptions.Add(2, "Update a Task");
            TaskMenuOptions.Add(3, "Mark Task as Complete");
            TaskMenuOptions.Add(4, "Return to lists menu");

            return TaskMenuOptions;

        }


    }
}
