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
        private readonly SberDbContext dbContext;
        private readonly IMapper mapper;

        public ModulesController(SberDbContext context, IMapper mapper)
        {
            dbContext = context;
            this.mapper = mapper;
        }

        // GET: api/Modules
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ModuleCompactResponse>>> GetModules()
        {
            return await dbContext.Modules
                .ProjectTo<ModuleCompactResponse>(mapper.ConfigurationProvider)
                .ToListAsync();
        }

        // GET: api/Modules/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ModuleResponse>> GetModule(int id)
        {
            var module = await dbContext
                .Modules
                .ProjectTo<ModuleResponse>(mapper.ConfigurationProvider)
                .SingleOrDefaultAsync(m => m.Id == id);

            if (module == null)
            {
                return NotFound();
            }

            return module;
        }

        [HttpPut("{id}/done")]
        public async Task<IActionResult> DoneModule(int id)
        {
            var findedModule = await this.dbContext.Modules
                .Include(i => i.Tags)
                .Include(i => i.TeacherInstructions)
                .Include(i => i.Comments)
                .SingleOrDefaultAsync(i => i.Id == id);

            if (findedModule == null)
            {
                return NotFound("module not found");
            }
            if (findedModule.TeacherInstructions == null)
            {
                return Conflict($"{nameof(findedModule.TeacherInstructions)} not exists");
            }
            if (findedModule.Comments.Where(c => c.Status != Shared.CommentStatus.Done).Any())
            {
                return Conflict($"Module have unresolved comments");
            }
            findedModule.Done = true;
            findedModule.LastEditTime = DateTime.UtcNow;

            await dbContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutModule(int id, CreateEditModuleRequest request)
        {
            var findedModule = await this.dbContext.Modules
                .Include(i => i.Tags)
                .SingleOrDefaultAsync(i => i.Id == id);

            if (findedModule == null)
            {
                return NotFound("module not found");
            }
            
            
            dbContext.Tags.RemoveRange(findedModule.Tags);
            mapper.Map(request, findedModule);
            findedModule.LastEditTime = DateTime.UtcNow;

            await dbContext.SaveChangesAsync();

            return NoContent();
        }


        [HttpPost]
        public async Task<ActionResult<ModuleCompactResponse>> PostModule(
            [FromBody] CreateEditModuleRequest request,
            [FromHeader(Name = "UserName")] string username = "server_noname")
        {
            var module = new Module
            {
                LastEditTime = DateTime.UtcNow,
                Creator = username
            };
            mapper.Map(request, module);
            dbContext.Modules.Add(module);
            await dbContext.SaveChangesAsync();

            return CreatedAtAction("GetModule", new { id = module.Id }, mapper.Map<ModuleCompactResponse>(module));
        }

        // DELETE: api/Modules/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ModuleResponse>> DeleteModule(int id)
        {
            var module = await dbContext.Modules.FindAsync(id);
            if (module == null)
            {
                return NotFound();
            }

            dbContext.Modules.Remove(module);
            await dbContext.SaveChangesAsync();

            return mapper.Map<ModuleResponse>(module);
        }
    }
}
