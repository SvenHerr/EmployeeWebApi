using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace EmployeeDB_WenApi
{
    public class EmployeeAccess : IEmployeeAccess
    {
        public const string CONNECTIONSTRING = "server=localhost;Initial Catalog=LocalDB;User ID=sa;Password=demol23;Trusted_Connection=true";

        public async Task<List<Employee>> GetAllEmployees()
        {
            try
            {
                using (var connection = new SqlConnection(CONNECTIONSTRING))
                {
                    connection.Open();

                    var sqlCommand = "SELECT * FROM Employees";
                    using var command = new SqlCommand(sqlCommand, connection);

                    using var reader = await command.ExecuteReaderAsync();
                    var result = new List<Employee>();

                    while (await reader.ReadAsync())
                    {
                        try
                        {
                            var tempItem = new Employee();
                            tempItem.FirstName = reader.GetValue(1).ToString();
                            tempItem.LastName = reader.GetValue(2).ToString();
                            tempItem.BirthDate = (DateTime)reader.GetValue(3);
                            tempItem.IsActive = (bool)reader.GetValue(4);

                            result.Add(tempItem);
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }

                    return result;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteToLogWithInfos(ex.ToString(), "EmployeeAccess", "GetAllEmployees");
                throw ex;
            }
        }

        public async Task<List<Employee>> GetEmployees(DateTime dateTime)
        {
            try
            {
                using (var connection = new SqlConnection(CONNECTIONSTRING))
                {
                    //Open connection
                    connection.Open();

                    //Compose query using sql parameters
                    var sqlCommand = "SELECT * FROM Employees WHERE BirthDate >= BirthDate=@value1";

                    var result = new List<Employee>();

                    var test = new Random();

                    //Create mysql command and pass sql query
                    using (var command = new SqlCommand(sqlCommand, connection))
                    {
                        command.Parameters.AddWithValue("@value1", dateTime);
                        command.ExecuteNonQuery();

                        using var reader = await command.ExecuteReaderAsync();

                        while (await reader.ReadAsync())
                        {
                            try
                            {
                                var tempItem = new Employee();
                                tempItem.FirstName = reader.GetValue(1).ToString();
                                tempItem.LastName = reader.GetValue(2).ToString();
                                tempItem.BirthDate = (DateTime)reader.GetValue(3);
                                tempItem.IsActive = (bool)reader.GetValue(4);

                                result.Add(tempItem);
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                        }
                    }
                    
                    return result;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteToLogWithInfos(ex.ToString(), "EmployeeAccess", "GetEmployees");
                throw ex;
            }
        }

        public bool AddEmployeeToDb(Employee employee)
        {
            try
            {
                using (var connection = new SqlConnection(CONNECTIONSTRING))
                {
                    //Open connection
                    connection.Open();

                    //Compose query using sql parameters
                    var sqlCommand = "INSERT INTO Employees (Id,FirstName, LastName, BirthDate, IsActive) VALUES (@value1,@value2,@value3,@value4,@value5)";

                    var test = new Random();

                    //Create mysql command and pass sql query
                    using (var command = new SqlCommand(sqlCommand, connection))
                    {
                        command.Parameters.AddWithValue("@value1", test.Next());
                        command.Parameters.AddWithValue("@value2", employee.FirstName);
                        command.Parameters.AddWithValue("@value3", employee.LastName);
                        command.Parameters.AddWithValue("@value4", employee.BirthDate);
                        command.Parameters.AddWithValue("@value5", employee.IsActive);
                        command.ExecuteNonQuery();
                    }

                    return true;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteToLogWithInfos(ex.ToString(), "EmployeeAccess", "AddEmployeeToDb");
                throw ex;
            }
        }

        public bool DeleteEmployee(int id)
        {
            try
            {
                using (var connection = new SqlConnection(CONNECTIONSTRING))
                {
                    //Open connection
                    connection.Open();

                    //Compose query using sql parameters
                    var sqlCommand = "DELETE FROM Employees WHERE Id=@value1";

                    var test = new Random();

                    //Create mysql command and pass sql query
                    using (var command = new SqlCommand(sqlCommand, connection))
                    {
                        command.Parameters.AddWithValue("@value1", id);
                        command.ExecuteNonQuery();
                    }

                    return true;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteToLogWithInfos(ex.ToString(), "EmployeeAccess", "DeleteEmployee");
                throw ex;
            }
        }
    }
}
