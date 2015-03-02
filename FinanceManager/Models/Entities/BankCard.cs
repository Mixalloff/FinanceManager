using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinanceManager.Models.Entities
{
    public class BankCard
    {
        /// <summary>
        /// Возвращает или задает идентификатор банковской карты
        /// </summary>
        [Key]
        public int BankCardId { get; set; }

        /// <summary>
        /// Возвращает или задает идентификатор связи со счетом
        /// </summary>
        public Account AccountId { get; set; }

        /// <summary>
        /// Возвращает или задает наименование типа счета
        /// </summary>
        [Required]
        public string CardNumber { get; set; }

        /// <summary>
        /// Возвращает или задает ИНН
        /// </summary>
        [Required]
        public string INN { get; set; }

        /// <summary>
        /// Возвращает или задает КПП
        /// </summary>
        [Required]
        public string KPP { get; set; }

        /// <summary>
        /// Возвращает или задает БИК
        /// </summary>
        [Required]
        public string BIK { get; set; }

        /// <summary>
        /// Возвращает или задает корреспондентский счет
        /// </summary>
        [Required]
        public string KorrNumber { get; set; }

        /// <summary>
        /// Возвращает или задает лицевой счет
        /// </summary>
        [Required]
        public string PersNumber { get; set; }

        /// <summary>
        /// Возвращает или задает номер филиала
        /// </summary>
        [Required]
        public string BranchNumber { get; set; }
    }
}