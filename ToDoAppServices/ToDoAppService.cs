using System;
using System.Collections.Generic;
using static ToDoAppDomain.Classes.DomainClasses;
using System.Linq;

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
            var list = _context.Lists.Add(new List { ListName = listName });
            _context.SaveChanges();

            return list;
        }

        public Task CreateTask(string taskDescription, bool taskStatus, DateTime completionDate)
        {
            var task = _context.Tasks.Add(new Task { TaskDescription = taskDescription, TaskStatus = taskStatus, CompletionDate = completionDate });
            _context.SaveChanges();

            return task;
        }

        public List<string> GetAllTasks()
        {
            var query = from t in _context.Tasks select t.TaskDescription;
            return query.ToList();
        }

    }
}
