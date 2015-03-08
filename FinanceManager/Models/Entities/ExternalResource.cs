using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinanceManager.Models.Entities
{
    /// <summary>
    /// Внешние ресурсы, содержащие электронные активы пользователей
    /// </summary>
    public class ExternalResource
    {
        /// <summary>
        /// Возвращает или задает идентификатор ресурсв
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ExternalResourceId { get; set; }

        /// <summary>
        /// Возвращает или задает наименование ресурса
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Возвращает или задает url ресурса
        /// </summary>
        public string Url { get; set; }        
    }
}