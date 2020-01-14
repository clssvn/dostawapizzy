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
    public class ClientController : ControllerBase
    {
        private s17628Context _context;
        public ClientController(s17628Context context)
        {
            _context = context;
        }

        public OkObjectResult GetClients()
        {
            return Ok(_context.Uzytkownik.ToList());
        }

        [HttpGet("{id:int}")]
        public IActionResult GetClient(int id)
        {
            var zam = _context.Uzytkownik.FirstOrDefault(e => e.IdUser == id);
            if (zam == null)
            {
                return NotFound();
            }
            return Ok(zam);
        }

        [HttpGet("{id:int}/orders")]
        public IActionResult GetClientOrders(int id)
        {
            var zam = _context.UzytkownikZamowienie.Join(_context.Zamowienie, 
                  uzzam => uzzam.ZamowienieIdZamowienie,
                  zamow => zamow.IdZamowienie,
                  (uzzam, zamow) => new { UzZam = uzzam, Zamow = zamow })
                  .Where(p => p.UzZam.UzytkownikIdUser == id);

            if (zam == null)
            {
                return NotFound();
            }
            return Ok(zam);
        }

        //------------
        [HttpPost]
        public IActionResult Create(Uzytkownik newUser)
        {
            _context.Uzytkownik.Add(newUser);
            _context.SaveChanges();

            return StatusCode(201, newUser);
        }

        [HttpPut("{userid:int}")]
        public IActionResult Update(int userid, Uzytkownik updatedUser)
        {

            if (_context.Uzytkownik.Count(e => e.IdUser == updatedUser.IdUser) == 0)
            {
                return NotFound();
            }


            _context.Uzytkownik.Attach(updatedUser);
            _context.Entry(updatedUser).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();


            return Ok(updatedUser);

        }

        [HttpDelete("{userid:int}")]

        public IActionResult Delete(int userid)
        {
            var user = _context.Uzytkownik.FirstOrDefault(e => e.IdUser == userid);
            if (user == null)
            {
                return NotFound();
            }
            _context.Uzytkownik.Remove(user);
            _context.SaveChanges();

            return Ok(user);
        }

    }
}
