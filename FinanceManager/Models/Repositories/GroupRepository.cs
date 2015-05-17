using FinanceManager.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.Data.Entity;

namespace FinanceManager.Models.Repositories
{
    public class GroupRepository : AbstractRepository<Group>
    {
        public GroupRepository(FinanceManagerDb context)
            : base(context)
        {
        }

        /// <summary>
        /// Получение данных о группах, включая внешние связи
        /// </summary>
        /// <param name="groups">Список групп без связей</param>
        /// <returns>Список групп со внешними связями</returns>
        private IQueryable<Group> IncludeReferences(IQueryable<Group> groups)
        {
            return groups
                .Include(x => x.Link)
                .Include(x => x.CashFlows)
                .Include(x => x.Groups)
                .Include(x => x.UserId);
        }
    }
}