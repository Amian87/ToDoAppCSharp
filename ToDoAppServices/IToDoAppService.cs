using System.Collections.Generic;
using ToDoAppDomain.Classes;
using static ToDoAppDomain.Classes.DomainClasses;

namespace ToDoAppServices
{
    public interface IToDoAppService
    {
        void UpdateTask(string taskDescription, int taskID, int listID);
        List<ListDTO> GetAllLists();
        List CreateList(string userInput);
        Task CreateTask(string userInput, int listID);
        void CompleteTask(int taskID);
        List<TaskDTO> GetAllTasksInList(int listID);
    }
}