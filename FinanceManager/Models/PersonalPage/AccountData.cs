using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinanceManager.Models.PersonalPage
{
    public class AccountData
    {
        /// <summary>
        /// Возвращает или задает Id счета
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Возвращает или задает название счета
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Возвращает или задает баланс счета
        /// </summary>
        public double Balance { get; set; }

        /// <summary>
        /// Возвращает или задает тип счета
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Возвращает или задает логотип счета
        /// </summary>
        public string Logo { get; set; }

        /// <summary>
        /// Возвращает или задает валюту счета
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// Флаг удаления
        /// </summary>
       // public bool IsDeleted { get; set; }
    }
}