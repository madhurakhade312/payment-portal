using employee.api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace employee.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeDbContext _context;
        public EmployeeController(EmployeeDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("GetEmployee")]
        public IActionResult getAllEmployees()
        {
            var list = _context.EmployeeModels.ToList();
            return Ok(list);
        }

        [HttpPost("CreateNewEmployee")]
        public IActionResult AddEmployee(EmployeeModel obj)
        {
            _context.EmployeeModels.Add(obj);
            //insert into employeeMasterTbl
            _context.SaveChanges();
            return Created("Employee Created Success", obj);
        }

        [HttpPut("UpdateEmployee")]
        public IActionResult UpdateEmployee(int id, EmployeeModel obj)
        {
            var existingRecord = _context.EmployeeModels.SingleOrDefault(emp => emp.empId == id);
            if(existingRecord != null)
            {
                existingRecord.empEmail = obj.empEmail;
                existingRecord.empName = obj.empName;
                existingRecord.empMobile = obj.empMobile;
                existingRecord.city = obj.city;
                existingRecord.state = obj.state;
                existingRecord.address = obj.address;
                _context.SaveChanges();
                return Ok(existingRecord);

            }
            else
            {
                return NotFound("Employee doesn't exist with the given ID");
            }

        }

        [HttpDelete("DeleteEmployee")]
        public IActionResult DeleteEmployee(int id)
        {
            var existingRecord = _context.EmployeeModels.SingleOrDefault(emp => emp.empId == id);
            if (existingRecord != null)
            {
                _context.EmployeeModels.Remove(existingRecord);
                _context.SaveChanges();
                return Ok("Employee Deleted Successfully");
            }
            else
            {
                return NotFound("Employee doesn't exist with the given ID");
            }
        }

    }
}
