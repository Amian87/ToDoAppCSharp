using Moq;
using NUnit.Framework;
using System;
using ToDoApp;

namespace ToDoAppTests
{
    public class ToDoTests
    {
        [Test]
        public void GoesThroughTheToDoLoop()
        {
            var consoleIO = new Mock<IConsoleIO>();
            consoleIO.Setup(x => x.ConsoleRead()).Returns("3");
            ToDo todo = new ToDo(consoleIO.Object);
            
            todo.ToDoAppLoop();

            consoleIO.Verify(x => x.ConsoleWrite("Welcome To The To-Do App"));
        }

    

    }
}


/*
 *
 * class MyMock<T> {
 *      T Object;
 *   Setup<T.method>(x => x[T.method]) {
 *      curretn FakeTMethod = new Setup<T, T.method.returnvalue>();
 *      Object {
 *         FakeTMethod.returnValue;
 *      }
 *      return FakeTMethod;
 *   }
 * }
 * 
 * class Setup<IConsole, string> {
 *      string ReturnValue;
 *      
 *      Returns(string value) {
 *        ReturnValue = value;
 *      }
 * }
 * 
 * 
 */
