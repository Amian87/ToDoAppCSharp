using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using ToDoApp;
using ToDoAppDomain.Classes;

namespace ToDoAppTests
{
    class ToDoConsoleGUITests
    {
        [Test]
        public void ItReturnsAnEmptyStringForAListWithNoElements()
        {
            ToDoConsoleGUI gui = new ToDoConsoleGUI();
            
            List<ListDTO> listOfDtos = new List<ListDTO>();
            List<string> listOfStrings = new List<string>();

            Assert.AreEqual(listOfStrings, gui.FormatListNames(listOfDtos));
        }

        [Test]
        public void ItReturnsFormattedStringsForAListWithOneDto()
        {
            ToDoConsoleGUI gui = new ToDoConsoleGUI();
            
            List<ListDTO> listOfDtos = new List<ListDTO>();
            listOfDtos.Add(new ListDTO { ListID = 1, ListName = "Road Trip" });
            List<string> listOfStrings = new List<string>();
            listOfStrings.Add("1 - Road Trip");

            Assert.AreEqual(listOfStrings, gui.FormatListNames(listOfDtos));
        }

        [Test]
        public void ItReturnsFormattedStringsForAListWithManyDtos()
        {
            ToDoConsoleGUI gui = new ToDoConsoleGUI();
            
            List<ListDTO> listOfDtos = new List<ListDTO>();
            listOfDtos.Add(new ListDTO { ListID = 1, ListName = "Road Trip" });
            listOfDtos.Add(new ListDTO { ListID = 1023, ListName = "Housework" });
            List<string> listOfStrings = new List<string>();
            listOfStrings.Add("1 - Road Trip");
            listOfStrings.Add("2 - Housework");

            Assert.AreEqual(listOfStrings, gui.FormatListNames(listOfDtos));
        }

        [Test]
        public void ItReturnsAFullSetOfListMenuOptions()
        {
            ToDoConsoleGUI gui = new ToDoConsoleGUI();

            Dictionary<int, string> expectedMenuOptions = new Dictionary<int, string>();
            expectedMenuOptions.Add(1, "Create a List");
            expectedMenuOptions.Add(2, "Open a List");
            expectedMenuOptions.Add(3, "Exit the App");

            Assert.AreEqual(expectedMenuOptions, gui.ListMenuOptions());
        }

        [Test]
        public void ItReturnsAListOfTaskMenuOptions()
        {
            ToDoConsoleGUI gui = new ToDoConsoleGUI();

            Dictionary<int, string> expectedMenuOptions = new Dictionary<int, string>();
            expectedMenuOptions.Add(1, "Create a Task");
            expectedMenuOptions.Add(2, "Update a Task");
            expectedMenuOptions.Add(3, "Mark Task as Complete");
            expectedMenuOptions.Add(4, "Return to lists menu");

            Assert.AreEqual(expectedMenuOptions, gui.TaskMenuOptions());
        }


    }
}
