using FinanceManager.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinanceManager.Models.Repositories
{
    public class RoleRepository : AbstractRepository<Role>
    {
        public RoleRepository(FinanceManagerDb context)
            : base(context)
        {
        }

        public Role FindByName(string roleName)
        {
            
                return context.Set<Role>().FirstOrDefault(x => x.Name == roleName);
            
        }
    }
}