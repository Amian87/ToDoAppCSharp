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
            string task1 = "this is task1";
            string task2 = "this is task2";
            string task3 = "this is task3";
            todo.CreateTask(task1);
            todo.CreateTask(task2);
            todo.CreateTask(task3);
            Assert.AreEqual(task1, todo.ListOfTasks()[1]);
        }




    }
}
