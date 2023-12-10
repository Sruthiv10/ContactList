using AutoMapper;
using RFL.TechStack.Application.CTO;
using RFL.TechStack.Application.DTO;
using RFL.TechStack.Application.Models;
using RFL.TechStack.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFL.TechStack.Framework.Host
{
    public class EntityMapper : Profile
    {
        public EntityMapper()
        {

            CreateMap<PurchaseorderEntry, PurchaseorderEntryDTO>().ReverseMap();


        }
    }
}
