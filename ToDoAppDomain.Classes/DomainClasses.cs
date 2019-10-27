using System;
using System.Data.Entity;

namespace ToDoAppDomain.Classes
{
    public class DomainClasses
    {
        public class Task
        {
            public int ListID { get; set; }
            public int TaskID { get; set; }
            public string TaskDescription { get; set; }
            public DateTime CompletionDate { get; set; }
            public bool TaskStatus { get; set; }
        }

        public class List
        {
            public int ListID { get; set; }
            public string ListName { get; set; }
        }
        public class ToDoContext : DbContext
        {
            public virtual DbSet<List> Lists { get; set; }
            public virtual DbSet<Task> Tasks { get; set; }
        }
    }
}
