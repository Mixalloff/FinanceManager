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
        /// Конструктор
        /// </summary>
        public OperationStatus()
        {
            this.CashFlows = new List<CashFlow>();
        }

        /// <summary>
        /// Возвращает или задает идентификатор статуса
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OperationStatusId { get; set; }

        /// <summary>
        /// Возвращает или задает наименование статуса
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Возвращает или задает связанные денежные потоки
        /// </summary>
        public virtual ICollection<CashFlow> CashFlows { get; set; }
    }
}