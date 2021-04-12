using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeDB_WenApi
{
    public class Logik : ILogik
    {

        private readonly ILogger<Logik> _logger;
        private readonly IEmployeeAccess _employeeAccess;

        public Logik(ILogger<Logik> logger, IEmployeeAccess employeeAccess)
        {
            _logger = logger;
            _employeeAccess = employeeAccess;
        }

        public async Task<List<Employee>> GetAllEmplyees()
        {
            try
            {
                return await _employeeAccess.GetAllEmployees();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Employee>> GetAllEmployeesOlderThan(DateTime birthDate)
        {
            try
            {
                return await _employeeAccess.GetEmployees(birthDate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool AddNewEmployee(Employee employee)
        {
            try
            {
                _employeeAccess.AddEmployeeToDb(employee);
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DeleteEmployee(int id)
        {
            try
            {
                _employeeAccess.DeleteEmployee(id);
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
