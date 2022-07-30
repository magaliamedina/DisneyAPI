using DisneyData;
using DisneyData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DisneyWebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DisneyDbContext _context;

        public UsersController(DisneyDbContext context)
        {
            _context = context;
        }

        //Get
        //GetUsers
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            return Ok(_context.Users.ToList());
        }

        //Get
        //GetUserById
        [HttpGet("{id}")]
        public ActionResult<User> GetUser(int id)
        {
            return Ok(_context.Users.Find(id));
        }
    }
}

