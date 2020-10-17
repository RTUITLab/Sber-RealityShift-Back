using AutoMapper;
using Models;
using PublicApi.Requests;
using PublicApi.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Formatting
{
    public class RequestFormatting : Profile
    {
        public RequestFormatting()
        {
            CreateMap<CreateEditModuleRequest, Module>()
                .ForMember(mgi => mgi.Tags, map => map.MapFrom(gier => gier.Tags.Select(t => new Tag { Value = t })));

            CreateMap<TeacherInstructionsEditRequest, ModuleTeacherInstructions>();

            CreateMap<CreateCommentRequest, Comment>();
        }
    }
}
