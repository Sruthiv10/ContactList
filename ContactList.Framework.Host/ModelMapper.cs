using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using RFL.TechStack.Application.CTO;
using RFL.TechStack.Application.DTO;
using RFL.TechStack.Application.Models;
using RFL.TechStack.Core.Entities;
using RFL.TechStack.Application.Interface;
using RFL.TechStack.Application.PurchaseOrder;

namespace RFL.TechStack.Framework.Host
{
    public class ModelMapper : Profile
    {
        public ModelMapper()
        {      
            CreateMap<ContactListCreateModel, ContactListDTO>().ReverseMap();
            CreateMap<ContactListEditModel, ContactListDTO>().ReverseMap();
            CreateMap<ContactListViewModel, ContactListDTO>().ReverseMap();
        }
    }
}
