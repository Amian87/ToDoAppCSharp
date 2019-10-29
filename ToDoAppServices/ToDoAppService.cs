﻿using System;
using System.Collections.Generic;
using static ToDoAppDomain.Classes.DomainClasses;
using System.Linq;
using ToDoAppDomain.Classes;

namespace ToDoAppServices
{
    public class ToDoAppService
    {
        private readonly ToDoContext _context;


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

        public Task CreateTask(string taskDescription)
        {
            var task = _context.Tasks.Add(new Task { TaskDescription = taskDescription, TaskStatus = false});
            _context.SaveChanges();
            return task;
        }

        public void CompleteTask(int taskID)
        {
            var task = _context.Tasks.Where(t => t.TaskID == taskID).FirstOrDefault();
            task.CompletionDate = DateTime.Now.ToString("MM-dd-yyyy");
            task.TaskStatus = true;
            _context.SaveChanges();
        }

        public List<TaskDTO> GetAllTasks()
        {
            var query = _context.Tasks.Select(t => new TaskDTO { TaskDescription = t.TaskDescription, TaskID = t.TaskID, TaskStatus = t.TaskStatus, CompletionDate = t.CompletionDate, ListID = t.ListID });
            return query.ToList();   
        }

        public void UpdateTask(string taskDescription, int taskID)
        {
            var task = _context.Tasks.Where(t => t.TaskID == taskID).FirstOrDefault();
            task.TaskDescription = taskDescription;
            _context.SaveChanges();
        }

    }
}
