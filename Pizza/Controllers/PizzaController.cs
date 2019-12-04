using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pizza.Models;

namespace Pizza.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private s17628Context _context;
        public PizzaController(s17628Context context)
        {
            _context = context;
        }

        public OkObjectResult GetEmpts()
        {
            return Ok(_context.Emp.ToList());
        }
        
        [HttpGet("{id:int}")]
        public IActionResult GetEmp(int id)
        {
            var emp = _context.Emp.FirstOrDefault(e => e.Empno == id);
            if (emp == null)
            {
                return NotFound();
            }
            return Ok(emp);
        }


    }
}