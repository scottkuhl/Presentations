using System;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ContosoUniversity.Controllers;
using ContosoUniversity.DAL;
using System.Collections.Generic;
using ContosoUniversity.Models;
using ContosoUniversity.ViewModels;

namespace ContosoUniversity.UnitTests
{
    [TestClass]
    public class HomeTest
    {
        [TestInitialize]
        public void Initiaize()
        {
            Helper.DataInitialize();
        }

        [TestMethod]
        public void Index()
        {
            var controller = new HomeController();

            var expectedMessage = "Welcome to Contoso University";

            controller.Index();

            Assert.AreEqual(expectedMessage, controller.ViewBag.Message);
        }

        [TestMethod]
        public void About()
        {
            var controller = new HomeController();

            var expectedCount = 1;

            controller.About();

            Assert.AreEqual(expectedCount, (controller.ViewData.Model as IEnumerable<EnrollmentDateGroup>).First().StudentCount);
        }

        [TestMethod]
        public void Contact()
        {
            var controller = new HomeController();

            var expectedMessage = "Your contact page.";

            controller.Contact();

            Assert.AreEqual(expectedMessage, controller.ViewBag.Message);
        }
    }
}
