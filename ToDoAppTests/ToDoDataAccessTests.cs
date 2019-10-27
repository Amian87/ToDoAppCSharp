using Moq;
using NUnit.Framework;
using System.Data.Entity;
using  ToDoApp;


namespace ToDoAppTests
{

    class ToDoDataAccessTests
    {
        [Test]
        public void Create_a_ToDoList_And_saves_it_via_context()
        {
            var mockSet = new Mock<DbSet<List>>();

            var mockContext = new Mock<ToDoContext>();
            mockContext.Setup(m => m.Lists).Returns(mockSet.Object);

            var service = new ToDoContext(mockContext.Object);
            service("ADO.NET Blog", "http://blogs.msdn.com/adonet");

            mockSet.Verify(m => m.Add(It.IsAny<Blog>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }
    }
}
