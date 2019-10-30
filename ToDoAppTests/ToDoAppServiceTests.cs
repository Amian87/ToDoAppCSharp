using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ToDoAppServices;
using static ToDoAppDomain.Classes.DomainClasses;
using List = ToDoAppDomain.Classes.DomainClasses.List;

namespace ToDoAppTests
{
    class ToDoAppServiceTests
    {
        [Test]
        public void SaveListToDatabase()
        {
            var mockSet = new Mock<DbSet<List>>();

            var mockContext = new Mock<ToDoContext>();
            mockContext.Setup(m => m.Lists).Returns(mockSet.Object);

            var service = new ToDoAppService(mockContext.Object);
            service.CreateList("Road Trip");

            mockSet.Verify(m => m.Add(It.IsAny<List>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());

        }

        [Test]
        public void SaveTaskToDatabase()
        {
            var mockSet = new Mock<DbSet<Task>>();

            var mockContext = new Mock<ToDoContext>();
            mockContext.Setup(m => m.Tasks).Returns(mockSet.Object);

            var service = new ToDoAppService(mockContext.Object);
            service.CreateTask("Visit Delaware", 1);

            mockSet.Verify(m => m.Add(It.IsAny<Task>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());

        }

        [Test]
        public void GetAllTasksInAList()
        {
            var listData = new List<List>
            {
                new List { ListName = "Learn Java", ListID = 1 }
            }.AsQueryable();

            var taskData = new List<Task>
            {
                new Task { ListID = 1, TaskDescription = "Practice Java code katas" , TaskID = 1}
            }.AsQueryable();

            var mockSetList = new Mock<DbSet<List>>();
            mockSetList.As<IQueryable<List>>().Setup(l => l.Provider).Returns(listData.Provider);
            mockSetList.As<IQueryable<List>>().Setup(l => l.Expression).Returns(listData.Expression);
            mockSetList.As<IQueryable<List>>().Setup(l => l.ElementType).Returns(listData.ElementType);
            mockSetList.As<IQueryable<List>>().Setup(l => l.GetEnumerator()).Returns(listData.GetEnumerator());

            var mockSetTask = new Mock<DbSet<Task>>();
            mockSetTask.As<IQueryable<List>>().Setup(l => l.Provider).Returns(taskData.Provider);
            mockSetTask.As<IQueryable<Task>>().Setup(l => l.Expression).Returns(taskData.Expression);
            mockSetTask.As<IQueryable<Task>>().Setup(l => l.ElementType).Returns(taskData.ElementType);
            mockSetTask.As<IQueryable<Task>>().Setup(l => l.GetEnumerator()).Returns(taskData.GetEnumerator());

            var mockContext = new Mock<ToDoContext>();
            mockContext.Setup(l => l.Lists).Returns(mockSetList.Object);
            mockContext.Setup(l => l.Tasks).Returns(mockSetTask.Object);

            var service = new ToDoAppService(mockContext.Object);
            var getList = service.GetAllLists();
            var listOfTask = service.GetAllTasksInList(1);

            Assert.AreEqual(1, getList.Count);
            Assert.AreEqual("Learn Java", getList[0].ListName);
            Assert.AreEqual( "Practice Java code katas", listOfTask[0].TaskDescription);

        }

        [Test]
        public void UpdateTask()
        {
            var taskData = new List<Task>
            {
                new Task {TaskDescription = "Buy groceries", TaskID = 1, ListID = 1}
            }.AsQueryable();

            var mockSetTask = new Mock<DbSet<Task>>();
            mockSetTask.As<IQueryable<Task>>().Setup(l => l.Provider).Returns(taskData.Provider);
            mockSetTask.As<IQueryable<Task>>().Setup(l => l.Expression).Returns(taskData.Expression);
            mockSetTask.As<IQueryable<Task>>().Setup(l => l.ElementType).Returns(taskData.ElementType);
            mockSetTask.As<IQueryable<Task>>().Setup(l => l.GetEnumerator()).Returns(taskData.GetEnumerator());

            var mockContext = new Mock<ToDoContext>();
            mockContext.Setup(l => l.Tasks).Returns(mockSetTask.Object);

            var service = new ToDoAppService(mockContext.Object);
            service.UpdateTask("Buy avocado", 1, 1);
            var getTask = service.GetAllTasksInList(1);


            Assert.AreEqual(1, getTask.Count);
            Assert.AreEqual("Buy avocado", getTask[0].TaskDescription);

        }

  

    }
}
