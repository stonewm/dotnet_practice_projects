using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPICrud.EmployeeService;
using WebAPICrud.Models;

namespace WebAPICrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService empService;

        public EmployeesController(IEmployeeService employeeService)
        {
            empService = employeeService;
        }

        [HttpGet]
        public IEnumerable<Employee> GetEmployees()
        {
            return empService.GetEmployees();
        }

        [HttpGet("{id}")]
        public Employee GetEmployee(int id)
        {
            return empService.GetEmployee(id);
        }

        [HttpPost]
        public IActionResult AddEmployee(Employee employee)
        {
            empService.AddEmployee(employee);
            return CreatedAtAction(nameof(GetEmployee), new {id = employee.id}, employee);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(int id,  Employee employee)
        {
            if (id != employee.id) {
                return BadRequest();
            }

            empService.UpdateEmployee(employee);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            var employee = empService.GetEmployee(id);

            if (employee != null) {
                empService.DeleteEmployee(id);
                return NoContent();
            }
            else {
                return BadRequest();
            }
        }
    }
}
