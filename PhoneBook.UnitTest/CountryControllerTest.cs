using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhoneBookApp.Controllers;
using PhoneBook.DAL.Interfaces;
using PhoneBook.DAL;

namespace PhoneBook.UnitTest
{
    [TestClass]
    public class CountryControllerTest
    {
        
        [TestMethod]
        public void ControllerIndex()
        {
            // Arrange
            CountryController controller = new CountryController();
            // Act
            var result = controller.Index();
            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ControllerCreate()
        {
            // Arrange
            CountryController controller = new CountryController();
            // Act
            ViewResult result = controller.Create() as ViewResult;
            // Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void ControllerEdit()
        {
            IPersonContext personContext = new DummyPersonContext();
            CountryController controller = new CountryController(personContext);
            int? id = 3;
            ViewResult result = controller.Edit(id) as ViewResult;
            Assert.IsNotNull(result);
        }
    }
}
