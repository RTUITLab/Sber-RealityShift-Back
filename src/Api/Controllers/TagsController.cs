﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Database;

namespace Api.Controllers
{
    [Route("api/tags")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly SberDbContext _context;

        public TagsController(SberDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> GetGeneralInfoTags(string match = "")
        {
            return await _context.Tags
                .Where(t => t.Value.ToUpper().Contains(match.ToUpper()))
                .Select(t => t.Value)
                .ToListAsync();
        }
    }
}
