using System;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ContosoUniversity.Controllers;
using ContosoUniversity.DAL;
using System.Collections.Generic;
using ContosoUniversity.Models;

namespace ContosoUniversity.UnitTests
{
    [TestClass]
    public class StudentTest
    {
        [TestInitialize]
        public void Initiaize()
        {
            Helper.DataInitialize();
        }

        [TestMethod]
        public void Index()
        {
            var controller = new StudentController();
            var expectedLastName = "Alexander";

            controller.Index(null, null, null, null);

            Assert.AreEqual(expectedLastName, (controller.ViewData.Model as IEnumerable<Student>).First().LastName);
        }

        [TestMethod]
        public void IndexSortOrder()
        {
            var controller = new StudentController();
            var expectedLastName = "Olivetto";

            controller.Index("Date", null, null, null);

            Assert.AreEqual(expectedLastName, (controller.ViewData.Model as IEnumerable<Student>).First().LastName);
        }

        [TestMethod]
        public void IndexSearch()
        {
            var controller = new StudentController();
            var expectedLastName = "Olivetto";

            controller.Index(null, null, "Oli", null);

            Assert.AreEqual(expectedLastName, (controller.ViewData.Model as IEnumerable<Student>).First().LastName);
        }

        [TestMethod]
        public void IndexPaging()
        {
            var controller = new StudentController();
            var expectedLastName = "Barzdukas";

            controller.Index(null, null, null, 2);

            Assert.AreEqual(expectedLastName, (controller.ViewData.Model as IEnumerable<Student>).First().LastName);
        }

        [TestMethod]
        public void Details()
        {
            var controller = new StudentController();

            var studentId = 1;
            var expectedLastName = "Alexander";

            controller.Details(studentId);

            Assert.AreEqual(expectedLastName, (controller.ViewData.Model as Student).LastName);
        }

        [TestMethod]
        public void Create()
        {
            var controller = new StudentController();
            controller.Create();
        }

        [TestMethod]
        public void CreateStudent()
        {
            var context = new SchoolContext();
            var controller = new StudentController();

            var expectedStudentId = 14;
            var expectedLastName = "Unit Test";
            var student = new Student() { LastName = expectedLastName, FirstMidName = "Test", EnrollmentDate = new DateTime(2013,8,1) };

            controller.Create(student);

            Assert.AreEqual(expectedStudentId, context.Students.Find(expectedStudentId).PersonID);
        }

        [TestMethod]
        public void Edit()
        {
            var controller = new StudentController();

            var studentId = 1;
            var expectedLastName = "Alexander";

            controller.Edit(studentId);

            Assert.AreEqual(expectedLastName, (controller.ViewData.Model as Student).LastName);
        }

        [TestMethod]
        public void EditStudent()
        {
            var context = new SchoolContext();
            var controller = new StudentController();

            var studentId = 1;
            var expectedLastName = "Unit Test";
            var student = new Student() { PersonID = studentId, LastName = expectedLastName, FirstMidName = "Test", EnrollmentDate = new DateTime(2013,8,1) };

            controller.Edit(student);

            Assert.AreEqual(expectedLastName, context.Students.Find(studentId).LastName);
        }

        [TestMethod]
        public void Delete()
        {
            var controller = new StudentController();

            var studentId = 1;
            var expectedLastName = "Alexander";

            controller.Delete(false, studentId);

            Assert.AreEqual(expectedLastName, (controller.ViewData.Model as Student).LastName);
        }

        [TestMethod]
        public void DeleteStudent()
        {
            var context = new SchoolContext();
            var controller = new StudentController();

            var studentId = 1;

            controller.Delete(studentId);

            Assert.IsNull(context.Students.Find(studentId));
        }
    }
}
