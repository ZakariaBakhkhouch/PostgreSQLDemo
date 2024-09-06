using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PostgreSQLDemo.Contexts;
using PostgreSQLDemo.Models;

namespace PostgreSQLDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        public readonly AppDbContext _context;

        public EmployeesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            return await _context.employees.ToListAsync();
        }
        
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var employee = await _context.employees.FindAsync(id);

            if (employee is not null)
                return employee;

            return NotFound();
        }
        
        [HttpPost]
        [Route("New")]
        public async Task<ActionResult> GetEmployees(Employee employee)
        {
            await _context.employees.AddAsync(employee);
            await _context.SaveChangesAsync();

            return Ok();
        }
        
        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            var employee = await _context.employees.FindAsync(id);

            if(employee is not null)
            {
                _context.employees.Remove(employee);
                await _context.SaveChangesAsync();
            }

            return Ok();
        }
    }
}
