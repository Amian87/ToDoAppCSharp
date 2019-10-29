using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoAppDomain.Classes
{
    public class TaskDTO
    {
            public int ListID { get; set; }
            public int TaskID { get; set; }
            public string TaskDescription { get; set; }
            public string CompletionDate { get; set; }
            public bool TaskStatus { get; set; }
    }
}
