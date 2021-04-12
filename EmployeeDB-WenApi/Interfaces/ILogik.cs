using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeDB_WenApi
{
    public interface ILogik
    {
        /// <summary>
        /// Gets all employees
        /// </summary>
        /// <returns></returns>
        Task<List<Employee>> GetAllEmplyees();

        /// <summary>
        /// Gets all employees older than the given parameter
        /// </summary>
        /// <param name="birthDate"></param>
        /// <returns></returns>
        Task<List<Employee>> GetAllEmployeesOlderThan(DateTime birthDate);

        /// <summary>
        /// Adds the given new employee to the DB
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        bool AddNewEmployee(Employee employee);

        /// <summary>
        /// Delets the employee with the given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool DeleteEmployee(int id);
    }
}
