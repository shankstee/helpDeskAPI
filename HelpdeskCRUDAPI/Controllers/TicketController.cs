using Microsoft.AspNetCore.Mvc;
using System.Linq;
using HelpdeskCRUDAPI.Data;
using HelpdeskCRUDAPI.Models;
using System.Threading.Tasks;

namespace AspCoreCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public TicketController(ApplicationDbContext db)
        {
            _db = db;
        }

        // Action Methods

        [HttpGet]
        public IActionResult GetTickets()
        {
            return Ok(_db.Ticket.ToList());
        }

        [HttpPost]
        public async Task<IActionResult> AddTicket([FromBody] Ticket objTicket)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult("Ticket While Creating New User");
            }
            _db.Ticket.Add(objTicket);
            await _db.SaveChangesAsync();

            return new JsonResult("Ticket Created Successfully");

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTicket([FromRoute] int id, [FromBody] Ticket objTicket)
        {
            if (objTicket == null || id != objTicket.id)
            {
                return new JsonResult("User Was Not Found");
            }
            else
            {
                _db.Ticket.Update(objTicket);
                await _db.SaveChangesAsync();
                return new JsonResult("Ticket Was Updated Successfully");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTicket([FromRoute] int id)
        {
            var findTicket = await _db.Ticket.FindAsync(id);
            if (findTicket == null)
            {
                return NotFound();
            }
            else
            {
                _db.Ticket.Remove(findTicket);
                await _db.SaveChangesAsync();
                return new JsonResult("Tickete Was Deleted Successfully");
            }
        }
    }
}