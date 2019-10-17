using NUnit.Framework;
using System;
using ToDoApp;

namespace ToDoAppTests
{
    public class ToDoTests
    {
        private ToDo todo;

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
            string task = "this is task";
            CreateMultipleTasks(1, task);
            Assert.AreEqual(task, todo.ListOfTasks()[1]);
        }

        [Test]
        public void CreateThreeTasks()
        {
            string task = "this is task";
            CreateMultipleTasks(3, task);
            Assert.AreEqual(task, todo.ListOfTasks()[1]);
            Assert.AreEqual(task, todo.ListOfTasks()[2]);
            Assert.AreEqual(task, todo.ListOfTasks()[3]);
        }




    }
}
