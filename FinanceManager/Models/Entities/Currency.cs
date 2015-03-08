using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinanceManager.Models.Entities
{
    /// <summary>
    /// Валюты с названием и курсом в долларах
    /// </summary>
    public class Currency
    {
        /// <summary>
        /// Возвращает или задает идентификатор валюты
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CurrencyId { get; set; }

        /// <summary>
        /// Возвращает или задает название валюты
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Возвращает или задает сокращенное название валюты
        /// </summary>
        public string Abbreviation { get; set; }

        /// <summary>
        /// Возвращает или задает котировку валюты в долларах
        /// </summary>
        public double Quote { get; set; }
    }
}