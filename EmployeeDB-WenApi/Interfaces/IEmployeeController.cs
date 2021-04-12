using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDB_WenApi.Controllers
{
    public interface IEmployeeController
    {
        Task<List<Employee>> GetAllEmployees();
        Task<List<Employee>> GetAllEmployeesOlderThan(DateTime birthDate);
        string AddNewEmployee([FromBody] Employee employee);
        string DeleteEmployee(int id);
    }
}
