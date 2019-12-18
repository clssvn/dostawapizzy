using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Internal;
using Pizza.Models;

namespace Pizza.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    /// <summary>
    /// Metoda zwraca dane..
    /// </summary>
    /// <returns>
    /// Lista...
    /// </returns>
    /// 
    public class PizzaController : ControllerBase
    {
        private s17628Context _context;
        public PizzaController(s17628Context context)
        {
            _context = context;
        }

        public OkObjectResult GetPizzas()
        {
            return Ok(_context.Pizza.ToList());
        }

        [HttpGet("{id:int}")]
        public IActionResult GetPizza(int id)
        {
            var pizza = _context.Pizza.FirstOrDefault(e => e.IdPizza == id);
            if (pizza == null)
            {
                return NotFound();
            }
            return Ok(pizza);
        }

        [HttpGet("{id:int}/skladniki")]
        public IActionResult GetSkladnikiPizzy(int id)
        {
         var skladniki = _context.PizzaSkladnik.Where(p => p.PizzaIdPizza == id).Join(_context.Skladnik,
             ps => ps.SkladnikIdSkladnik, s => s.IdSkladnik, (ps, s) => new { ps, s })
             .Select(res => res.s.Nazwa).ToList()
                ;

            if (skladniki == null)
            {
                return NotFound();
            }
            return Ok(skladniki);
        }


    }
}