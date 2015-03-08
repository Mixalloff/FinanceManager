using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinanceManager.Models.Entities
{
    public class OperationStatus
    {
        /// <summary>
        /// Возвращает или задает идентификатор статуса
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OperationStatusId { get; set; }

        /// <summary>
        /// Возвращает или задает наименование статуса
        /// </summary>
        public string Name { get; set; }
    }
}