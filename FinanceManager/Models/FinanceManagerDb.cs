using FinanceManager.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FinanceManager.Models
{
    public class FinanceManagerDb : DbContext
    {
        public FinanceManagerDb()
            : base("FinanceManagerDb")
        {
            Database.SetInitializer(new ProjectInitializer());
        }

        /// <summary>
        /// Возвращает или задает список записей о пользователях
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// Возвращает или задает список записей о ролях
        /// </summary>
        public DbSet<Role> Roles { get; set; }

        /// <summary>
        /// Возвращает или задает список записей о типах потоков
        /// </summary>
        public DbSet<TypeCashFlow> TypeCashFlows { get; set; }

        /// <summary>
        /// Возвращает или задает список записей о статусах операций
        /// </summary>
        public DbSet<OperationStatus> OperationStatus { get; set; }

        /// <summary>
        /// Возвращает или задает список записей о группах
        /// </summary>
        public DbSet<Group> Groups { get; set; }

        /// <summary>
        /// Возвращает или задает список записей о внешних ресурсах
        /// </summary>
        public DbSet<ExternalResource> ExternalResources { get; set; }

        /// <summary>
        /// Возвращает или задает список записей об электронных счетах
        /// </summary>
        public DbSet<EWallet> EWallets { get; set; }

        /// <summary>
        /// Возвращает или задает список записей о валютах
        /// </summary>
        public DbSet<Currency> Currencies { get; set; }

        /// <summary>
        /// Возвращает или задает список записей о денежных потоках
        /// </summary>
        public DbSet<CashFlow> CashFlows { get; set; }

        /// <summary>
        /// Возвращает или задает список записей архива
        /// </summary>
        public DbSet<Archive> Archives { get; set; }

        /// <summary>
        /// Возвращает или задает список записей о счетах
        /// </summary>
        public DbSet<Account> Accounts { get; set; }

        /// <summary>
        /// Возвращает или задает список записей о типах счетов
        /// </summary>
        public DbSet<AccountType> AccountTypes { get; set; }

        /// <summary>
        /// Возвращает или задает список записей о банковских картах
        /// </summary>
        public DbSet<BankCard> BankCards { get; set; }

    }
}