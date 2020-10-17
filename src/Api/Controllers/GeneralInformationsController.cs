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
    [Route("api/modules/{moduleId}/general")]
    [ApiController]
    public class GeneralInformationsController : ControllerBase
    {
        private readonly SberDbContext dbContext;
        private readonly IMapper mapper;

        public GeneralInformationsController(SberDbContext context, IMapper mapper)
        {
            dbContext = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<GeneralInfoResponse>> GetModuleGeneralInformation(int moduleId)
        {
            var moduleGeneralInformation = await dbContext.GeneralInformation
                .Where(gi => gi.ModuleId == moduleId)
                .ProjectTo<GeneralInfoResponse>(mapper.ConfigurationProvider)
                .SingleOrDefaultAsync();

            if (moduleGeneralInformation == null)
            {
                return NotFound();
            }

            return moduleGeneralInformation;
        }

        [HttpPut]
        public async Task<IActionResult> PutModuleGeneralInformation(int moduleId, GeneralInfoEditRequest request)
        {

            var findedModule = await this.dbContext.Modules
                .Include(m => m.GeneralInformation)
                .ThenInclude(i => i.Tags)
                .SingleOrDefaultAsync(i => i.Id == moduleId);
            if (findedModule == null)
            {
                return NotFound("module not found");
            }
            if (findedModule.GeneralInformation == null)
            {
                findedModule.GeneralInformation = mapper.Map<ModuleGeneralInformation>(request);
                dbContext.GeneralInformation.Add(findedModule.GeneralInformation);
            }
            else
            {
                dbContext.GeneralInfoTags.RemoveRange(findedModule.GeneralInformation.Tags);
                mapper.Map(request, findedModule.GeneralInformation);
            }
            findedModule.LastEditTime = DateTime.UtcNow;

            await dbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
