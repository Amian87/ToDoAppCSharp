using NUnit.Framework;
using System;
using ToDoApp;

namespace ToDoAppTests
{
    public class ToDoTests
    {
        private ToDo todo;
        private string task = "This is a task";

        [SetUp]
        public void SetUP()
        {
            todo = new ToDo();
        }

        public void CreateMultipleTasks(int numberOfTasks, string task)
        {
            for(int i = 0; i < numberOfTasks; i++)
            {
                todo.CreateTask(task);
            }
        }

        [Test]
        public void CreateOneTask()
        {
            CreateMultipleTasks(1, task);
            Assert.AreEqual(task, todo.TasksDictionary()[1]);
        }

        [Test]
        public void CreateThreeTasks()
        {
            CreateMultipleTasks(3, task);
            Assert.AreEqual(task, todo.TasksDictionary()[1]);
            Assert.AreEqual(task, todo.TasksDictionary()[2]);
            Assert.AreEqual(task, todo.TasksDictionary()[3]);
        }

        //[Test]
        //public void CreateMenuOptions()
        //{
        //    todo.AddMenuOptions();
        //    Assert.AreEqual("Create a Task", todo.MenuDictionary()[1]);
        //    Assert.AreEqual("Exit the App", todo.MenuDictionary()[2]);
        //} 

        //[Test]
        //public void DisplayTasksOnConsole()
        //{
        //    CreateMultipleTasks(1, task);
        //    var output = todo.DisplayTasksOnConsole();
        //    Assert.AreEqual("1 - This is a task", );
        //}





    }
}
