using Microsoft.AspNetCore.Mvc;
using System.Linq;
using HelpdeskCRUDAPI.Data;
using HelpdeskCRUDAPI.Models;
using System.Threading.Tasks;

namespace AspCoreCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public UserController(ApplicationDbContext db)
        {
            _db = db;
        }

        // Action Methods

        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok(_db.Users.ToList());
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] User objUser)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult("Error While Creating New User");
            }
            _db.Users.Add(objUser);
            await _db.SaveChangesAsync();

            return new JsonResult("User Created Successfully");

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser([FromRoute] int id, [FromBody] User objUser)
        {
            if (objUser == null || id != objUser.id)
            {
                return new JsonResult("User Was Not Found");
            }
            else
            {
                _db.Users.Update(objUser);
                await _db.SaveChangesAsync();
                return new JsonResult("User Was Updated Successfully");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int id)
        {
            var findUser = await _db.Users.FindAsync(id);
            if (findUser == null)
            {
                return NotFound();
            }
            else
            {
                _db.Users.Remove(findUser);
                await _db.SaveChangesAsync();
                return new JsonResult("Employee Was Deleted Successfully");
            }
        }
    }
}