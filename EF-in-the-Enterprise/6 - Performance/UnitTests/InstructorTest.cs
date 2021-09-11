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
    public class InstructorTest
    {
        [TestInitialize]
        public void Initiaize()
        {
            Helper.DataInitialize();
        }

        [TestMethod]
        public void Index()
        {
            var controller = new InstructorController();

            var instructorId = 9;
            var courseId = 2021;
            var expectedInstructorsCount = 5;
            var expectedCoursesCount = 2;
            var expectedEnrollmentCount = 2;

            controller.Index(instructorId, courseId);

            Assert.AreEqual(expectedInstructorsCount, (controller.ViewData.Model as InstructorIndexData).Instructors.Count());
            Assert.AreEqual(instructorId, controller.ViewBag.PersonID);
            Assert.AreEqual(expectedCoursesCount, (controller.ViewData.Model as InstructorIndexData).Courses.Count());
            Assert.AreEqual(courseId, controller.ViewBag.CourseID);
            Assert.AreEqual(expectedEnrollmentCount, (controller.ViewData.Model as InstructorIndexData).Enrollments.Count());
        }

        [TestMethod]
        public void Details()
        {
            var controller = new InstructorController();

            var instructorId = 9;
            var expectedLastName = "Abercrombie";

            controller.Details(instructorId);

            Assert.AreEqual(expectedLastName, (controller.ViewData.Model as Instructor).LastName);
        }

        [TestMethod]
        public void Create()
        {
            var controller = new InstructorController();

            var expectedCount = 3;

            controller.Create();

            Assert.AreEqual(expectedCount, (controller.ViewBag.PersonID as SelectList).Count());
        }

        [TestMethod]
        public void CreateDepartment()
        {
            var context = new SchoolContext();
            var controller = new InstructorController();

            var expectedInstructorId = 14;
            var instructor = new Instructor() { LastName = "Unit", FirstMidName = "Test", Email = "test@contosou.edu", HireDate = new DateTime(2013, 8, 1) };

            controller.Create(instructor);

            Assert.AreEqual(expectedInstructorId, context.Instructors.Find(expectedInstructorId).PersonID);
        }

        [TestMethod]
        public void Edit()
        {
            var controller = new InstructorController();

            var instructorId = 9;
            var expectedLastName = "Abercrombie";

            controller.Edit(instructorId);

            Assert.AreEqual(expectedLastName, (controller.ViewData.Model as Instructor).LastName);
        }

        [TestMethod]
        public void EditInstructor()
        {
            var context = new SchoolContext();
            var controller = new InstructorController();
            controller.SetFakeControllerContext();

            var instructorId = 9;
            var expectedLastName = "Unit Test";
            var expectedCourseCount = 1;
            var selectedCourses = new string[] { "2021" };

            var formCollection = new FormCollection();
            formCollection.Add("LastName", expectedLastName);
            formCollection.Add("FirstMidName", "Kim");
            formCollection.Add("Emai", "test@contosou.edu");
            formCollection.Add("HireDate", "3/11/1995");
            formCollection.Add("OfficeAssignment.Location", "");
            controller.ValueProvider = formCollection.ToValueProvider();

            controller.Edit(instructorId, formCollection, selectedCourses);

            context = new SchoolContext();
            Assert.AreEqual(expectedLastName, context.Instructors.Find(instructorId).LastName);
            Assert.AreEqual(expectedCourseCount, context.Instructors.Find(instructorId).Courses.Count);
        }
        
        [TestMethod]
        public void Delete()
        {
            var controller = new InstructorController();

            var instructorId = 9;
            var expectedLastName = "Abercrombie";

            controller.Delete(instructorId);

            Assert.AreEqual(expectedLastName, (controller.ViewData.Model as Instructor).LastName);
        }
        
        [TestMethod]
        public void DeleteInstructor()
        {
            var context = new SchoolContext();
            var controller = new InstructorController();

            var instructorId = 13;

            controller.DeleteConfirmed(instructorId);

            context = new SchoolContext();
            Assert.IsNull(context.Instructors.Find(instructorId));
        }
    }
}
