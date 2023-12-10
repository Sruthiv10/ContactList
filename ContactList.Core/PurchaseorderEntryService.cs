using AutoMapper;
using RFL.TechStack.Core.Entities;
using RFL.TechStack.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFL.TechStack.Core
{
     public class PurchaseorderEntryService : GenericService<PurchaseorderEntry>, IPurchaseorderEntryService
    {
        private readonly IPurchaseorderEntryRepository repository;
        private readonly IMapper mapper;
        public PurchaseorderEntryService(IPurchaseorderEntryRepository repository, IMapper mapper)
            : base(repository, mapper)
        {
            this.mapper = mapper;
        }
    }
}
