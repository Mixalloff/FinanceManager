using FinanceManager.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinanceManager.Models.Repositories
{
    public class CurrencyRepository : AbstractRepository<Currency>
    {
        public CurrencyRepository(FinanceManagerDb context)
            : base(context)
        {
        }

        public Currency FindByName(string currencyName)
        {
            
                return context.Set<Currency>().FirstOrDefault(x => x.Name == currencyName);
            
        }
    }
}