using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeDB_WenApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : IEmployeeController
    {
        private readonly ILogik _logik;
        
        
        public EmployeeController( ILogik logik)
        {
            _logik = logik;
        }

        // ?lang=en
        [HttpGet]
        public string Hello(string lang = "de")
        {
            if (lang == "en")
            {
                return "Welcome to the ASP.NET CORE Webservice of Sven Herrmann" + Environment.NewLine +
                   "I did implement two controller. EmployeeController and the TestController to check some Webservice functions." + Environment.NewLine +
                   "You could use the calls below:" + Environment.NewLine +
                   "1: ...'test/PostAddEmployees' Here it will create an new dummy employee and store it to the DB " + Environment.NewLine +
                   "2: ...'test/PostAddEmployee/WithParameter' Here you can create an employee and give the parameters (string firstName, string lastName, string birthDate, string isActive)" + Environment.NewLine +
                   "3: ...'test/DeleteEmployee/WithParameter' Here you can delete an employee that matches the given parameter id (Id)";
            }
            else
            {
                return "Willkommen zum ASP.NET CORE Webservice von Sven Herrmann." + Environment.NewLine +
                   "Er besteht aus zwei Controllern, EmployeeController und den TestController um den Webservice zu testen." + Environment.NewLine +
                   "Sie können folgende Aufrufe machen:" + Environment.NewLine +
                   "1: ...'test/PostAddEmployees' Hier wird ein Dummy Employee angelegt " + Environment.NewLine +
                   "2: ...'test/PostAddEmployee/WithParameter' Hier kann man einen Employee mit Parametern anlegen (string firstName, string lastName, string birthDate, string isActive)" + Environment.NewLine +
                   "3: ...'test/DeleteEmployee/WithParameter' Hier wird der Employee gelöscht auf den die übergebene Id passt";
            }
        }

        [HttpGet("GetEmployees")]
        public async Task<List<Employee>> GetAllEmployees()
        {
            try
            {
                //return new List<Employee>();
                return await _logik.GetAllEmplyees();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("{birthDate}")]
        public async Task<List<Employee>> GetAllEmployeesOlderThan(DateTime birthDate)
        {
            try
            {
                return await _logik.GetAllEmployeesOlderThan(birthDate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public string AddNewEmployee([FromBody] Employee employee)
        {
            try
            {
                if (String.IsNullOrEmpty(employee.FirstName) == false && String.IsNullOrEmpty(employee.LastName) == false)
                {
                    employee.IsActive = true;

                    _logik.AddNewEmployee(employee);
                    return "Success";
                }
                else
                {
                    return "Fehler";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete]
        public string DeleteEmployee(int id)
        {
            try
            {
                _logik.DeleteEmployee(id);

                return "Mitarbeiter mit Id: " + id + " wurde gelöscht";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
