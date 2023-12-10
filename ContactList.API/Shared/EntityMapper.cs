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
using System;
using Microsoft.AspNetCore.Identity;

namespace ContactList.API.Shared
{
    public class EntityMapper : Profile
    {
        public EntityMapper()
        {

            CreateMap<ContactListDTO, ContactListEntity>().ReverseMap();            


        }
    }
}
