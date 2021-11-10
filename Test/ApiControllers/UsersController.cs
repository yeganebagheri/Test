using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Data;
using Test.Models;

namespace Test.ApiControllers
{
    [Route("api/UsersController")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly TestDbContext _context;

        public UsersController(TestDbContext context)
        {
            _context = context;
        }


         [HttpGet]
        public async Task<IEnumerable<User>> Get()
        {
           
            return await (_context.Users.ToListAsync());
        }

       
    }
}
