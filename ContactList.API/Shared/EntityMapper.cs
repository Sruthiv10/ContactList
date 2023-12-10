using AutoMapper;
using ContactList.Application.DTO;
using ContactList.Application.Models;
using ContactList.Core.Common;
using ContactList.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactList.API.Shared
{
    public class EntityMapper : Profile
    {
        public EntityMapper()
        {

            CreateMap<ContactListEntity, ContactListDTO>().ReverseMap();
            CreateMap<ExecuteResult<ContactListEntity>, ExecuteResult<ContactListDTO>>()
            .ForMember(dest => dest.Results, opt => opt.MapFrom(src => src.Results));


        }
    }
}
