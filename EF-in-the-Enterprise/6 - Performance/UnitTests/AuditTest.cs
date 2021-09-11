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
    public class AuditTest
    {
        [TestInitialize]
        public void Initiaize()
        {
            Helper.DataInitialize();
        }

        [TestMethod]
        public void CreateStudent()
        {
            var context = new SchoolContext();
            var controller = new StudentController();

            var expectedTableId = 14;
            var expectedTableName = "Student";
            var expectedAction = "Added";
            var student = new Student() { LastName = "Unit", FirstMidName = "Test", Email="test@contosou.edu", EnrollmentDate = new DateTime(2013,8,1) };

            controller.Create(student);

            Assert.AreEqual(expectedTableId, context.Audits.First().TableId);
            Assert.AreEqual(expectedTableName, context.Audits.First().TableName);
            Assert.AreEqual(expectedAction, context.Audits.First().Action);
        }

        [TestMethod]
        public void EditStudent()
        {
            var context = new SchoolContext();
            var controller = new StudentController();

            var expectedTableId = 1;
            var expectedTableName = "Student";
            var expectedAction = "Modified";
            var student = new Student() { PersonID = expectedTableId, LastName = "Unit Test", FirstMidName = "Test", Email = "test@contosou.edu", EnrollmentDate = new DateTime(2013, 8, 1) };

            controller.Edit(student);

            Assert.AreEqual(expectedTableId, context.Audits.First().TableId);
            Assert.AreEqual(expectedTableName, context.Audits.First().TableName);
            Assert.AreEqual(expectedAction, context.Audits.First().Action);
        }

        [TestMethod]
        public void DeleteStudent()
        {
            var context = new SchoolContext();
            var controller = new StudentController();

            var expectedTableId = 1;
            var expectedTableName = "Student";
            var expectedAction = "Deleted";

            controller.Delete(expectedTableId);

            Assert.AreEqual(expectedTableId, context.Audits.First().TableId);
            Assert.AreEqual(expectedTableName, context.Audits.First().TableName);
            Assert.AreEqual(expectedAction, context.Audits.First().Action);
        }
    }
}
