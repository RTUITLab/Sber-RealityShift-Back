using AutoMapper;
using Models;
using Models.Links;
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
            CreateMap<GeneralInfoEditRequest, ModuleGeneralInformation>()
                .ForMember(mgi => mgi.Tags, map => map.MapFrom(gier => gier.Tags.Select(t => new GeneralInfoTag { Tag = t })));
        }
    }
}
