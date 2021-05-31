using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Mvc;
using WebAPICrud.EmployeeService;
using WebAPICrud.Models;

namespace WebAPICrud.Controllers
{
    public class EmployeesController : ODataController
    {
        private readonly IEmployeeService empService;

        public EmployeesController(IEmployeeService employeeService)
        {
            empService = employeeService;
        }

        [EnableQuery]
        public IActionResult GetEmployees()
        {
            return Ok(empService.GetEmployees());
        }
 
        [EnableQuery]
        [ODataRoute("employees({id})")]
        public IActionResult GetEmployee([FromODataUri] int id)
        {
            return Ok(empService.GetEmployee(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody] Employee employee)
        {
            empService.AddEmployee(employee);
            return Created(employee);
        }

        [HttpPut]
        [ODataRoute("employees({id})")]
        public IActionResult UpdateEmployee([FromODataUri] int id,  [FromBody] Employee employee)
        {
            if (id != employee.Id) {
                return BadRequest();
            }

            empService.UpdateEmployee(employee);
            return Updated(employee);
        }

        [HttpDelete]
        [ODataRoute("employees({id})")]
        public IActionResult Delete([FromODataUri] int id)
        {
            var employee = empService.GetEmployee(id);

            if (employee != null) {
                empService.DeleteEmployee(id);
                return NoContent();
            }
            else {
                return NotFound();
            }
        }
    }
}
