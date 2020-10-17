using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Database;
using Models;
using PublicApi.Responses;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using PublicApi.Requests;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModulesController : ControllerBase
    {
        private readonly SberDbContext _context;
        private readonly IMapper mapper;

        public ModulesController(SberDbContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }

        // GET: api/Modules
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ModuleCompactResponse>>> GetModules()
        {
            return await _context.Modules
                .ProjectTo<ModuleCompactResponse>(mapper.ConfigurationProvider)
                .ToListAsync();
        }

        // GET: api/Modules/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ModuleResponse>> GetModule(int id)
        {
            var module = await _context
                .Modules
                .Include(m => m.GeneralInformation)
                .SingleOrDefaultAsync(m => m.Id == id);

            if (module == null)
            {
                return NotFound();
            }

            return mapper.Map<ModuleResponse>(module);
        }

        // PUT: api/Modules/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutModule(int id, CreateEditModuleRequest request)
        {
            var module = new Module
            {
                Id = id,
                LastEditTime = DateTime.UtcNow,
                Title = request.Title
            };
            _context.Entry(module).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModuleExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Modules
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ModuleCompactResponse>> PostModule(CreateEditModuleRequest moduleRequest)
        {
            var module = new Module
            {
                LastEditTime = DateTime.UtcNow,
                Title = moduleRequest.Title
            };
            _context.Modules.Add(module);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetModule", new { id = module.Id }, mapper.Map<ModuleCompactResponse>(module));
        }

        // DELETE: api/Modules/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ModuleResponse>> DeleteModule(int id)
        {
            var module = await _context.Modules.FindAsync(id);
            if (module == null)
            {
                return NotFound();
            }

            _context.Modules.Remove(module);
            await _context.SaveChangesAsync();

            return mapper.Map<ModuleResponse>(module);
        }

        private bool ModuleExists(int id)
        {
            return _context.Modules.Any(e => e.Id == id);
        }
    }
}
