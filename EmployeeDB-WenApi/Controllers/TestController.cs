using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace EmployeeDB_WenApi.Controllers
{
    [ApiController]
    [Route("test")]
    public class TestController : ControllerBase
    {
        private readonly ILogger<EmployeeController> _logger;

        public TestController(ILogger<EmployeeController> logger)
        {
            _logger = logger;
        }

        //[Route("GetAllEmployee")]
        //public async Task<string> Test1()
        //{
        //    var newEmployee = new Employee()
        //    {
        //        FirstName = "Sven",
        //        LastName = "Herrmann",
        //        BirthDate = new DateTime(1992, 1, 12),
        //        IsActive = true
        //    };

        //    using (var client = new HttpClient())
        //    {
        //        string serializedDto = JsonConvert.SerializeObject(newEmployee);
        //        var content = new StringContent(serializedDto, Encoding.UTF8, "application/json");

        //        HttpResponseMessage response = await client.PostAsync("https://localhost:44346/employee", content);

        //        var responseString = await response.Content.ReadAsStringAsync();

        //        return responseString;
        //    }
        //}

        [Route("PostAddEmployee")]
        public async Task<string> Test()
        {
            var newEmployee = new Employee()
            {
                FirstName = "Sven",
                LastName = "Herrmann",
                BirthDate = new DateTime(1992, 1, 12),
                IsActive = true
            };

            using (var client = new HttpClient())
            {
                string serializedDto = JsonConvert.SerializeObject(newEmployee);
                var content = new StringContent(serializedDto, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync("https://localhost:44346/employee", content);

                var responseString = await response.Content.ReadAsStringAsync();

                return responseString;
            }
        }

        // https://localhost:44346/test/PostAddEmployee/WithParameter?firstName=Sven1&lastName=Herrmann&birthDate=12.01.1992&isActive=true
        [Route("PostAddEmployee/WithParameter")]
        //[Route("test/Post{firstName}")]
        public async Task<string> Test(string firstName, string lastName, string birthDate, string isActive)
        {
            var newEmployee = new Employee()
            {
                FirstName = firstName,
                LastName = lastName,
                BirthDate = DateTime.Parse(birthDate),
                IsActive = bool.Parse(isActive)
            };

            using (var client = new HttpClient())
            {
                string serializedDto = JsonConvert.SerializeObject(newEmployee);
                var content = new StringContent(serializedDto, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync("https://localhost:44346/employee", content);

                var responseString = await response.Content.ReadAsStringAsync();

                return responseString;
            }
        }

        // https://localhost:44346/test/DeleteEmployee?id=1
        [Route("DeleteEmployee/WithParameter")]
        //[Route("test/Post{firstName}")]
        public async Task<string> Test(long id)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.DeleteAsync("https://localhost:44346/employee?id=" + id);

                var responseString = await response.Content.ReadAsStringAsync();

                return responseString;
            }
        }
    }
}
