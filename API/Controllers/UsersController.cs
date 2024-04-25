using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]  // /api/users
    public class UsersController : ControllerBase
    {
        private readonly dataContext _context;
        public UsersController(dataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            var users = _context.AppUsers.ToList();
            return users;
        }
        [HttpGet("{id}")]  // /api/users/id
        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
            return _context.AppUsers.Find(id);
        }

    }
}

