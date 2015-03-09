using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinanceManager.Models.Entities
{
    /// <summary>
    ///  Счета пользователей
    /// </summary>
    public class Account
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public Account()
        {
            this.BankCards = new List<BankCard>();
            this.EWallets = new List<EWallet>();
            this.CashFlows = new List<CashFlow>();
        }

        /// <summary>
        /// Возвращает или задает идентификатор счета
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AccountId { get; set; }

        /// <summary>
        /// Возвращает или задает наименование счета
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Возвращает или задает текущий баланс счета
        /// </summary>
        public double Balance { get; set; }

        /// <summary>
        /// Возвращает или задает тип счета
        /// </summary>
       // public int? AccountTypeId;
      //  [ForeignKey("AccountTypeId")]
        public AccountType AccountTypeId { get; set; }

        /// <summary>
        /// Возвращает или задает путь к логотипу счета
        /// </summary>
        public string Logo { get; set; }

        /// <summary>
        /// Возвращает или задает основную расчетную валюту счета
        /// </summary>
       // [ForeignKey("CurrencyId")]
        public Currency CurrencyOfAccount { get; set; }

        /// <summary>
        /// Возвращает или задает пользователя, владеющего счетом
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Возвращает или задает связи с банковскими картами
        /// </summary>
        public virtual ICollection<BankCard> BankCards { get; set; }

        /// <summary>
        /// Возвращает или задает связи с электронными кошельками
        /// </summary>
        public virtual ICollection<EWallet> EWallets { get; set; }

        /// <summary>
        /// Возвращает или задает связи с денежными потоками
        /// </summary>
        public virtual ICollection<CashFlow> CashFlows { get; set; }
        
    }
}