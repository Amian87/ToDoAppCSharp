using System;
using System.Collections.Generic;
using static ToDoAppDomain.Classes.DomainClasses;
using System.Linq;
using ToDoAppDomain.Classes;

namespace ToDoAppServices
{
    public class ToDoAppService
    {
        private ToDoContext _context;


        public ToDoAppService(ToDoContext context)
        {
            _context = context;
        }

        public List CreateList(string listName)
        {
            _context.Database.Log = Console.WriteLine;
            var list = _context.Lists.Add(new List { ListName = listName });
            _context.SaveChanges();

            return list;
        }

        public Task CreateTask(string taskDescription, bool taskStatus, DateTime completionDate)
        {
            _context.Database.Log = Console.WriteLine;
            var task = _context.Tasks.Add(new Task { TaskDescription = taskDescription, TaskStatus = taskStatus, CompletionDate = completionDate });
            _context.SaveChanges();

            return task;
        }

        public List<TaskDTO> GetAllTasks()
        {
            _context.Database.Log = Console.WriteLine;
            var query = _context.Tasks.Select(t => new TaskDTO { TaskDescription = t.TaskDescription, TaskID = t.TaskID, TaskStatus = t.TaskStatus, CompletionDate = t.CompletionDate, ListID = t.ListID });
            return query.ToList();   
        }

        public void UpdateTask(string taskDescription, int taskID, bool taskStatus )
        {
            var task = _context.Tasks.Where(t => t.TaskID == taskID).FirstOrDefault();
            task.TaskDescription = taskDescription;
            _context.SaveChanges();
        }

    }
}
