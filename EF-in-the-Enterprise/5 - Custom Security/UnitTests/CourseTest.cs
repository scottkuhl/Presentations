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
    public class CourseTest
    {
        [TestInitialize]
        public void Initiaize()
        {
            Helper.DataInitialize();
        }

        [TestMethod]
        public void UpdateCourseCredits()
        {
            var context = new SchoolContext();
            var controller = new CourseController();

            var calculusCredits = 4;
            var macroeconomicsCredits = 3;
            var multiplier = 2;
            var calculusCourseId = 1045;
            var macroeconomicsCourseId = 4041;
            var expectedRowsAffected = 7;

            controller.UpdateCourseCredits(multiplier);

            Assert.AreEqual(expectedRowsAffected, controller.ViewBag.RowsAffected);
            Assert.AreEqual(calculusCredits * multiplier, context.Courses.Find(calculusCourseId).Credits);
            Assert.AreEqual(macroeconomicsCredits * multiplier, context.Courses.Find(macroeconomicsCourseId).Credits);
        }

        [TestMethod]
        public void Index()
        {
            var controller = new CourseController();

            var departmentId = 1;
            var expectedSelectedValue = 1;
            var expectedCourseCount = 2;

            controller.Index(departmentId);

            Assert.AreEqual(expectedSelectedValue, controller.ViewBag.SelectedDepartment.SelectedValue);
            Assert.AreEqual(expectedCourseCount, (controller.ViewData.Model as IEnumerable<Course>).Count());
        }

        [TestMethod]
        public void Details()
        {
            var controller = new CourseController();

            var courseId = 1045;
            var expectedTitle = "Calculus";

            controller.Details(courseId);

            Assert.AreEqual(expectedTitle, (controller.ViewData.Model as Course).Title);
        }

        [TestMethod]
        public void Create()
        {
            var controller = new CourseController();

            var expectedCourseId = 3333;

            controller.Create();

            Assert.AreEqual(expectedCourseId, (controller.ViewData.Model as Course).CourseID);
        }

        [TestMethod]
        public void CreateCourse()
        {
            var context = new SchoolContext();
            var controller = new CourseController();

            var expectedCourseId = 9876;
            var expectedTitle = "Unit Test";
            var course = new Course() { CourseID = expectedCourseId, Credits = 3, DepartmentID = 1, Title = expectedTitle };

            controller.Create(course);

            Assert.AreEqual(expectedTitle, context.Courses.Find(expectedCourseId).Title);
        }

        [TestMethod]
        public void Edit()
        {
            var controller = new CourseController();

            var courseId = 1045;
            var expectedTitle = "Calculus";

            controller.Edit(courseId);

            Assert.AreEqual(expectedTitle, (controller.ViewData.Model as Course).Title);
        }

        [TestMethod]
        public void EditCourse()
        {
            var context = new SchoolContext();
            var controller = new CourseController();

            var courseId = 1045;
            var expectedTitle = "Unit Test";
            var course = new Course() { CourseID = courseId, Credits = 3, DepartmentID = 1, Title = expectedTitle };

            controller.Edit(course);

            Assert.AreEqual(expectedTitle, context.Courses.Find(courseId).Title);
        }

        [TestMethod]
        public void Delete()
        {
            var controller = new CourseController();

            var courseId = 1045;
            var expectedTitle = "Calculus";

            controller.Delete(courseId);

            Assert.AreEqual(expectedTitle, (controller.ViewData.Model as Course).Title);
        }

        [TestMethod]
        public void DeleteCourse()
        {
            var context = new SchoolContext();
            var controller = new CourseController();

            var courseId = 1045;

            controller.DeleteConfirmed(courseId);

            Assert.IsNull(context.Courses.Find(courseId));
        }
    }
}
