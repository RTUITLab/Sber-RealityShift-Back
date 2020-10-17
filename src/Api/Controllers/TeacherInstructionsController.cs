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
using AutoMapper.QueryableExtensions;
using AutoMapper;

namespace Api.Controllers
{
    [Route("api/modules/{moduleId}/teacherInstructions")]
    [ApiController]
    public class TeacherInstructionsController : ControllerBase
    {
        private readonly SberDbContext dbContext;
        private readonly IMapper mapper;

        public TeacherInstructionsController(SberDbContext context, IMapper mapper)
        {
            dbContext = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<TeacherInstructionsResponse>> GetModuleTeacherInstructions(int moduleId)
        {
            var moduleTeacherResponse = await dbContext.TeacherInstructions
                .Where(gi => gi.ModuleId == moduleId)
                .ProjectTo<TeacherInstructionsResponse>(mapper.ConfigurationProvider)
                .SingleOrDefaultAsync();

            if (moduleTeacherResponse == null)
            {
                return NotFound();
            }

            return moduleTeacherResponse;
        }

        [HttpPut]
        public async Task<IActionResult> PutModuleGeneralInformation(int moduleId, TeacherInstructionsEditRequest request)
        {

            var findedModule = await this.dbContext.Modules
                .Include(m => m.TeacherInstructions)
                .SingleOrDefaultAsync(i => i.Id == moduleId);
            if (findedModule == null)
            {
                return NotFound("module not found");
            }
            if (findedModule.TeacherInstructions == null)
            {
                findedModule.TeacherInstructions = mapper.Map<ModuleTeacherInstructions>(request);
                dbContext.TeacherInstructions.Add(findedModule.TeacherInstructions);
            }
            else
            {
                mapper.Map(request, findedModule.TeacherInstructions);
            }
            findedModule.LastEditTime = DateTime.UtcNow;

            await dbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
