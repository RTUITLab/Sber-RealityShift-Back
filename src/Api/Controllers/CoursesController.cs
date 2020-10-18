using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly SberDbContext dbContext;

        public CoursesController(SberDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<string>>> Get()
        {
            return await dbContext
                .Modules
                .Select(m => m.Course)
                .Where(c => c != null)
                .Distinct()
                .ToListAsync();
        }
    }
}
