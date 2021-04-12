using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace EmployeeDB_WenApi
{
    public interface IEmployeeAccess
    {
        Task<List<Employee>> GetAllEmployees();
        bool AddEmployeeToDb(Employee employee);

        Task<List<Employee>> GetEmployees(DateTime dateTime);
        bool DeleteEmployee(int id);

    }
}
