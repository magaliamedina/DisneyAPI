using DisneyData;
using DisneyData.Models;
using DisneyDomain.DTO;
using DisneyDomain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;

namespace DisneyWebAPI.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly DisneyDbContext _context;
        public readonly ITokenService _tokenService;

        public AuthController(DisneyDbContext context, ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        //Post
        //login
        [HttpPost("login")]
        public ActionResult<UserDTO> Login(LoginDTO login)
        {
            var user = _context.Users.SingleOrDefault(x => x.UserName == login.Email);

            if (user == null) return Unauthorized("Username or password incorrect");

            using var hmac = new HMACSHA512(user.PasswordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(login.Password));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i]) return Unauthorized("Username or password incorrect");
            }

            var token = _tokenService.CreateToken(user);

            var userDto = new UserDTO()
            {
                UserName = login.Email,
                Token = token
            };

            return Ok(userDto);
        }

        //Post
        //register
        [HttpPost("register")]
        public ActionResult<UserDTO> Register(RegisterDTO user)
        {
            //if (UserExists(user.Username)) return BadRequest("User already taken");

            using var hmac = new HMACSHA512();

            var newUser = new User()
            {
                UserName = user.Email,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(user.Password)),
                PasswordSalt = hmac.Key
            };

            _context.Users.Add(newUser);
            _context.SaveChanges();

            var token = _tokenService.CreateToken(newUser);

            var userDto = new UserDTO()
            {
                UserName = user.Email,
                Token = token
            };

            return Ok(userDto);
        }

        private bool UserExists(string username)
        {
            return _context.Users.Any(u => u.UserName == username);
        }
    }
}
