using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Platform.ApplicationServices.Contexts;
using Platform.ApplicationServices.Data.Entities;
using Platform.ApplicationServices.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Platform.ApplicationServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeeDbContext _context;
        private readonly ILogger<EmployeesController> _logger;

        public EmployeesController(EmployeeDbContext context, ILogger<EmployeesController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpGet, Route("get")]
        public async Task<IActionResult> Get(string? name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                var emp = await _context.Employees
          .FirstOrDefaultAsync(m => m.FirstName == name);
                return Ok(emp);
            }
            else
            {
                var emp =  _context.Employees;
                return Ok(emp);
            }
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpPost]
        public async Task<IActionResult> Save(Employee emp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _context.Employees.Add(new Employee()
            {
                FirstName = emp.FirstName,
                LastName = emp.LastName,
                RoleId = emp.RoleId,
                DepartmentId = emp.DepartmentId,
                CreatedAt=DateTime.Now
            });
            _context.SaveChanges();
            return Ok();
        }
    }
}
