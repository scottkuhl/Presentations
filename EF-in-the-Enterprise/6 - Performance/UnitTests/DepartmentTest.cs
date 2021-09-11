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
    public class DepartmentTest
    {
        [TestInitialize]
        public void Initiaize()
        {
            Helper.DataInitialize();
        }

        [TestMethod]
        public void ValidateOneAdministratorAssignmentPerInstructor()
        {
            var context = new SchoolContext();
            var controller = new DepartmentController();

            var departmentId = 1;
            var department = context.Departments.Find(departmentId);
            department.PersonID = 10;
            var expectedMessage = "Instructor Fadi Fakhouri is already administrator of the Mathematics department.";

            controller.Edit(department);

            Assert.AreEqual(expectedMessage, controller.ModelState[""].Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void Index()
        {
            var controller = new DepartmentController();

            var expectedDepartmentCount = 4;

            controller.Index();

            Assert.AreEqual(expectedDepartmentCount, (controller.ViewData.Model as IEnumerable<Department>).Count());
        }

        [TestMethod]
        public void Details()
        {
            var controller = new DepartmentController();

            var departmentId = 1;
            var expectedName = "English";

            controller.Details(departmentId);

            Assert.AreEqual(expectedName, (controller.ViewData.Model as Department).Name);
        }

        [TestMethod]
        public void Create()
        {
            var controller = new DepartmentController();

            var expectedDepartmentName = "Computer Science";
            var expectedInstructorId = 10;

            controller.Create();

            Assert.AreEqual(expectedDepartmentName, (controller.ViewData.Model as Department).Name);
            Assert.AreEqual(expectedInstructorId, (controller.ViewBag.PersonID as SelectList).SelectedValue);
        }

        [TestMethod]
        public void CreateDepartment()
        {
            var context = new SchoolContext();
            var controller = new DepartmentController();

            var expectedDepartmentId = 5;
            var expectedName = "Unit Test";
            var department = new Department() { Name = expectedName, Budget = 8000, StartDate = new DateTime(2013,8,1), PersonID = 1 };

            controller.Create(department);

            Assert.AreEqual(expectedName, context.Departments.Find(expectedDepartmentId).Name);
        }

        [TestMethod]
        public void Edit()
        {
            var controller = new DepartmentController();

            var departmentId = 1;
            var expectedName = "English";
            var expectedInstructorId = 9;

            controller.Edit(departmentId);

            Assert.AreEqual(expectedName, (controller.ViewData.Model as Department).Name);
            Assert.AreEqual(expectedInstructorId, (controller.ViewBag.PersonID as SelectList).SelectedValue);
        }

        [TestMethod]
        public void EditDepartment()
        {
            var context = new SchoolContext();
            var controller = new DepartmentController();

            var departmentId = 1;
            var expectedName = "Unit Test";
            var department = context.Departments.Find(departmentId);
            var editDepartment = new Department() { DepartmentID = departmentId, Name = expectedName, Budget = department.Budget, StartDate = department.StartDate, PersonID = department.PersonID, RowVersion = department.RowVersion };

            controller.Edit(editDepartment);

            context = new SchoolContext();
            Assert.AreEqual(expectedName, context.Departments.Find(departmentId).Name);
        }

        [TestMethod]
        public void EditDepartmentConcurrencyError()
        {
            var context = new SchoolContext();
            var controller = new DepartmentController();

            var departmentId = 1;
            var expectedName = "Unit Test";
            var department = context.Departments.Find(departmentId);
            var editDepartment = new Department() { DepartmentID = departmentId, Name = expectedName, Budget = department.Budget, StartDate = department.StartDate, PersonID = department.PersonID, RowVersion = new byte[1] };

            controller.Edit(editDepartment);

            context = new SchoolContext();
            Assert.AreEqual(expectedName, context.Departments.Find(departmentId).Name);
        }
        
        [TestMethod]
        public void Delete()
        {
            var controller = new DepartmentController();

            var departmentId = 1;
            var expectedName = "English";

            controller.Delete(departmentId, false);

            Assert.AreEqual(expectedName, (controller.ViewData.Model as Department).Name);
        }

        [TestMethod]
        public void DeleteConcurrencyError()
        {
            var controller = new DepartmentController();

            var departmentId = 1;

            controller.Delete(departmentId, true);

            Assert.IsTrue((controller.ViewBag.ConcurrencyErrorMessage as string).StartsWith("The record you attempted to delete"));
        }
        
        [TestMethod]
        public void DeleteDepartment()
        {
            var context = new SchoolContext();
            var controller = new DepartmentController();

            var departmentId = 1;
            var department = context.Departments.Find(departmentId);
            var editDepartment = new Department() { DepartmentID = departmentId, Name = department.Name, Budget = department.Budget, StartDate = department.StartDate, PersonID = department.PersonID, RowVersion = department.RowVersion };

            controller.Delete(editDepartment);

            context = new SchoolContext();
            Assert.IsNull(context.Departments.Find(departmentId));
        }

        [TestMethod]
        public void DeleteDepartmentConcurrencyError()
        {
            var context = new SchoolContext();
            var controller = new DepartmentController();

            var departmentId = 1;
            var department = context.Departments.Find(departmentId);
            var editDepartment = new Department() { DepartmentID = departmentId, Name = department.Name, Budget = department.Budget, StartDate = department.StartDate, PersonID = department.PersonID, RowVersion = new byte[1] };

            controller.Delete(editDepartment);

            context = new SchoolContext();
            Assert.IsNotNull(context.Departments.Find(departmentId));
        }
    }
}
