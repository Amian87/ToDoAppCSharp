using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;

namespace ToDoApp
{
    public class ToDoClasses
    {


    public class List
        {
            public int ListID { get; set; }
            public string ListName { get; set; }
        }

        public class Task
        {
            public int ListID { get; set; }
            public int TaskID { get; set; }
            public string TaskDescription { get; set; }
            public string CompletionDate { get; set; }
        }

  

    }
}
