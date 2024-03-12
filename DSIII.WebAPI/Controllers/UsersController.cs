using DSIII.WebAPI.Entities;
using DSIII.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DSIII.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var users = await _context.User.ToListAsync();

            return users;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(string id)
        {
            var user = await _context.User.FirstOrDefaultAsync(x => x.Id == id);
            
            return user ?? new Entities.User();
        }

        [HttpPost]
        public async Task<ActionResult<User>> PostUser(UserModel model) {
            var user = new User { 
                Id = Guid.NewGuid().ToString(),
                Username = model.Username,
                Password = model.Password,
                Email = model.Email,
                DisplayName = model.DisplayName,
                RoleId = 2,
                CreatedDate = DateTime.Now
            };

            _context.User.Add(user);
            var saved = await _context.SaveChangesAsync() > 0;

            return user;
        }
    }
}