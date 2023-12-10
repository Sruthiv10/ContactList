using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RFL.TechStack.Core.Entities;
using RFL.TechStack.Core.Interface;
using RFL.TechStack.Infrastructure.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFL.TechStack.Infrastructure.Repositories
{
    public class PurchaseorderEntryRepository : GenericRepository<PurchaseorderEntry>, IPurchaseorderEntryRepository
    {
        private readonly TECHDBContext appDbContext;
        private readonly IConfiguration configuration;
        public PurchaseorderEntryRepository(TECHDBContext appDbContext, IConfiguration configuration)
           : base(appDbContext)
        {
            this.configuration = configuration;
            this.appDbContext = appDbContext;
        }

        /// <summary>
        /// Method for getting module details with out tracking.
        /// </summary>
        /// <param name="id">id for module.</param>
        /// <returns>Response.</returns>
        public PurchaseorderEntry GetAsNoTracking(object id)
        {
            return appDbContext.PurchaseorderEntries.AsNoTracking().Where(x => x.Uid == (long)id).FirstOrDefault();
        }
    }
}
