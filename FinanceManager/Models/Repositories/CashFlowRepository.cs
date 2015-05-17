using FinanceManager.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.Data.Entity;

namespace FinanceManager.Models.Repositories
{
    public class CashFlowRepository : AbstractRepository<CashFlow>
    {
        public CashFlowRepository(FinanceManagerDb context)
            : base(context)
        {
        }

        /// <summary>
        /// Получение данных о потоках, включая внешние связи
        /// </summary>
        /// <param name="flows">Список потоков без связей</param>
        /// <returns>Список потоков со внешними связями</returns>
        private IEnumerable<CashFlow> IncludeReferences(IQueryable<CashFlow> flows)
        {
            return flows
                .Include(x => x.Link)
                .Include(x => x.Links)
                .Include(x => x.OperatingAccount)
                .Include(x => x.Type)
                .Include(x => x.GroupFlows)
                .Include(x => x.Archives)
                .Include(x => x.Status);
        }

        public override IEnumerable<CashFlow> GetAll()
        {
            return this.IncludeReferences(context.CashFlows)
                .ToList();
        }

    }
}