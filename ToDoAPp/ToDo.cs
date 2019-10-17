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

        

    }
}
