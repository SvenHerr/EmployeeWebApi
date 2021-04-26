using EmployeeDB_WenApi;
using EmployeeDB_WenApi.Controllers;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NUnitTestProject
{
    public class Tests
    {
        private Mock<ILogik> _logik = new Mock<ILogik>();

        //[SetUp]
        //public void Setup()
        //{

        //}

        [Test]
        public async Task GetAllEmployeesTest()
        {
            // arrange
            var mainClass = new EmployeeController(_logik.Object);

            // act
            await mainClass.GetAllEmployees();

            // assert    
            _logik
                .Verify(v => v.GetAllEmplyees(), Times.Once);

        }

        [Test]
        public async Task GetAllEmployeesOlderThanTest()
        {
            // arrange
            var mainClass = new EmployeeController(_logik.Object);
            var date = new DateTime(1992, 1, 12);

            // act
            var a = await mainClass.GetAllEmployeesOlderThan(date);

            // assert    
            _logik
                .Verify(v => v.GetAllEmployeesOlderThan(date), Times.Once);
        }

        [Test]
        public void AddNewEmployeeTest()
        {
            // arrange
            var mainClass = new EmployeeController(_logik.Object);
            var employee = new Employee()
            {
                FirstName = "Sven",
                LastName = "Herrmann",
                BirthDate = new DateTime(1992, 1, 12),
                IsActive = true
            };

            // act
            var a = mainClass.AddNewEmployee(employee);

            // assert    
            _logik
                .Verify(v => v.AddNewEmployee(employee), Times.Once);
        }

        [Test]
        public void AddNewEmployeeDBTest()
        {
            // arrange
            var mockDB = new Mock<IEmployeeAccess>();


            var employee = new Employee()
            {
                FirstName = "Sven",
                LastName = "Herrmann",
                BirthDate = new DateTime(1992, 1, 12),
                IsActive = true
            };


            mockDB.Setup(x => x.AddEmployeeToDb(employee)).Returns(true);
        }
        [Test]
        public void GetAllEmployeesDBTest()
        {
            // arrange
            var mockDB = new Mock<IEmployeeAccess>();


            var result = new List<Employee>();


            mockDB.Setup(x => x.GetAllEmployees()).ReturnsAsync(result);
        }

        [Test]
        public void DeleteEmployeeTest()
        {
            // arrange
            var mainClass = new EmployeeController(_logik.Object);
            var id = 1;

            // act
            var a = mainClass.DeleteEmployee(id);

            // assert    
            _logik
                .Verify(v => v.DeleteEmployee(id), Times.Once);
        }
    }
}