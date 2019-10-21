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

        [Test]
        public void CreateThreeTasks()
        {
            string task = "This is a task";

            todo.CreateTask(task);
            todo.CreateTask(task);
            todo.CreateTask(task);
            
            Assert.AreEqual(task, todo.TasksDictionary()[1]);
            Assert.AreEqual(task, todo.TasksDictionary()[2]);
            Assert.AreEqual(task, todo.TasksDictionary()[3]);
        }

        [Test]
        public void CreateMenuOption()
        {
            Assert.AreEqual("Create a Task", todo.MenuDictionary()[1]);
            Assert.AreEqual("Exit the App", todo.MenuDictionary()[2]);
        }

        [Test]
        public void UpdateOneTask()
        {
            todo.CreateTask("This is a task");
            todo.UpdateTask(1, "This is the updated task");
            Assert.AreEqual("This is the updated task", todo.TasksDictionary()[1]);
        }

        [Test]
        public void MarkTaskAsComplete()
        {
            todo.CreateTask("This is a complete task");
            todo.MarkTaskComplete(1);
            Assert.AreEqual("This is a complete task  X  Completed on " + DateTime.Now.ToString("MM-dd-yyyy"), todo.TasksDictionary()[1]);
        }

        [Test]
        public void CannotMarkTaskAsCompleteMultipleTimes()
        {
            todo.CreateTask("This is a complete task");
            todo.MarkTaskComplete(1);
            todo.MarkTaskComplete(1);
            Assert.AreEqual("This is a complete task  X  Completed on " + DateTime.Now.ToString("MM-dd-yyyy"), todo.TasksDictionary()[1]);
        }

    }
}
