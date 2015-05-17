using FinanceManager.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.Data.Entity;

namespace FinanceManager.Models.Repositories
{
    public class AccountRepository : AbstractRepository<Account>
    {
        public AccountRepository(FinanceManagerDb context)
            : base(context)
        {
        }

        /// <summary>
        /// Получение данных о счетах, включая внешние связи
        /// </summary>
        /// <param name="accounts">Список счетов без связей</param>
        /// <returns>Список счетов со внешними связями</returns>
        private IEnumerable<Account> IncludeReferences(IQueryable<Account> accounts)
        {
            return accounts
                .Include(x => x.AccountTypeId)
                .Include(x => x.User)
                .Include(x => x.CurrencyOfAccount)
                .Include(x => x.BankCards)
                .Include(x => x.CashFlows)
                .Include(x => x.EWallets);
        }

        public override IEnumerable<Account> GetAll()
        {
            return this.IncludeReferences(context.Accounts)
                .ToList();
        }
    }
}