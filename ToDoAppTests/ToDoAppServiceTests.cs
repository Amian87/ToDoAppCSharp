using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using ToDoAppServices;
using static ToDoAppDomain.Classes.DomainClasses;
using List = ToDoAppDomain.Classes.DomainClasses.List;

namespace ToDoAppTests
{
    class ToDoAppServiceTests
    {
        private ToDoAppService tds;

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
            service.CreateTask("Visit Delaware", false, DateTime.Today);

            mockSet.Verify(m => m.Add(It.IsAny<Task>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());

        }

    }
}
