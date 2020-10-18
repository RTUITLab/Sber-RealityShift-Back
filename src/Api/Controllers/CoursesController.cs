using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PublicApi.Responses;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly SberDbContext dbContext;
        private readonly IMapper mapper;

        public CoursesController(SberDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<CourseResponse>>> Get()
        {
            return await dbContext
                .Courses
                .ProjectTo<CourseResponse>(mapper.ConfigurationProvider)
                .ToListAsync();
        }
    }
}
