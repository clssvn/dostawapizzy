using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pizza.Models;

namespace Pizza.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZamowienieController : ControllerBase
    {
        private s17628Context _context;
        public ZamowienieController(s17628Context context)
        {
            _context = context;
        }

        public OkObjectResult GetZamowienia()
        {
            return Ok(_context.Zamowienie.ToList());
        }

        [HttpGet("{id:int}")]
        public IActionResult GetZamowienie(int id)
        {
            var zam = _context.Zamowienie.FirstOrDefault(e => e.IdZamowienie == id);
            if (zam == null)
            {
                return NotFound();
            }
            return Ok(zam);
        }

        [HttpGet("avgtime")]
        public IActionResult AvgTime(int id)
        {
            var avg = _context.Zamowienie
                .Select(e => new { day = ((System.DateTime)e.DataCzasZamowienia).Day, time = e.DataCzasRealizacjiZamowienia.Subtract((System.DateTime)e.DataCzasZamowienia )})
                .Where(f =>  f.day == DateTime.Today.Day)
                .Average(t => t.time.TotalMinutes);

            return Ok(avg);
        }

    }
}
