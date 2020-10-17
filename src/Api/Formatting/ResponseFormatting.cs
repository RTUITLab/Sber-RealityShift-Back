using AutoMapper;
using Models;
using PublicApi.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Formatting
{
    public class ResponseFormatting : Profile
    {
        public ResponseFormatting()
        {
            CreateMap<Module, ModuleCompactResponse>();
            CreateMap<Module, ModuleResponse>();

            CreateMap<Module, ModuleResponse>()
                .ForMember(r => r.Tags, map => map.MapFrom(r => r.Tags.Select(tl => tl.Value)));

            CreateMap<ModuleTeacherInstructions, TeacherInstructionsResponse>();

        }
    }
}
