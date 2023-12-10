using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactList.Application.DTO;
using ContactList.Application.Models;
using ContactList.Core.Entities;
using ContactList.Application.Interface;
using ContactList.Core.Common;


namespace ContactList.API.Shared
{
    public class ModelMapper : Profile
    {
        public ModelMapper()
        {
            CreateMap<ContactListCreateModel, ContactListDTO>().ReverseMap();
            CreateMap<ContactListEditModel, ContactListDTO>().ReverseMap();
            CreateMap<ContactListViewModel, ContactListDTO>().ReverseMap();
            CreateMap<ExecuteResult<ContactListDTO>, ExecuteResult<ContactListViewModel>>()
           .ForMember(dest => dest.Results, opt => opt.MapFrom(src => src.Results));
            

        }
    }
}
   

