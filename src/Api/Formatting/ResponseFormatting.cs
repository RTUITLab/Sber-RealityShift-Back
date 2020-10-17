using AutoMapper;
using Models;
using PublicApi.Responses;
using Shared;
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
            CreateMap<Module, ModuleCompactResponse>()
                .ForMember(r => r.Tags, map => map.MapFrom(r => r.Tags.Select(tl => tl.Value)));

            CreateMap<Module, ModuleResponse>()
                .ForMember(r => r.Tags, map => map.MapFrom(r => r.Tags.Select(tl => tl.Value)))
                .ForMember(r => r.GeneralPart, map => map.MapFrom(m => new PartInfo { Filled = true, ContainsError = m.Comments.Where(c => c.Part == ModulePart.General).Where(c => c.Status != CommentStatus.Done).Any() }))
                .ForMember(r => r.TeacherInstructionsPart, map => map.MapFrom(m => new PartInfo { Filled = m.TeacherInstructions != null, ContainsError = m.Comments.Where(c => c.Part == ModulePart.TeacherInstructions).Where(c => c.Status != CommentStatus.Done).Any() }));

            CreateMap<ModuleTeacherInstructions, TeacherInstructionsResponse>();

            CreateMap<Comment, CommentResponse>();

        }
    }
}
