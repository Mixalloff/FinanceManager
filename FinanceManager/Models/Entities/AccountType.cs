using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinanceManager.Models.Entities
{
    /// <summary>
    /// Тип счета
    /// </summary>
    public class AccountType
    {
        /// <summary>
        /// Конструктор, инициализирующий связь типа со счетами
        /// </summary>
        public AccountType()
        {
          //  this.Accounts = new List<Account>();
        }

        /// <summary>
        /// Возвращает или задает идентификатор типа счета
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AccountTypeId { get; set; }

        /// <summary>
        /// Возвращает или задает наименование типа счета
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Возвращает или задает список счетов, имеющих данный тип
        /// </summary>
       // public virtual ICollection<Account> Accounts { get; set; }
    }
}