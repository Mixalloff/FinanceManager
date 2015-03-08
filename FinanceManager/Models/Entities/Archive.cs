using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinanceManager.Models.Entities
{
    /// <summary>
    /// Архив изменений номинала и процентных ставок по регулярным денежным потокам
    /// </summary>
    public class Archive
    {
        /// <summary>
        /// Возвращает или задает идентификатор записи архива
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ArchieveId { get; set; }

        /// <summary>
        /// Возвращает или задает идентификатор соответствующего денежного потока
        /// </summary>
        //[ForeignKey("CashFlowId")]
        public CashFlow CashFlows { get; set; }

        /// <summary>
        /// Возвращает или задает номинал потока до момента записи
        /// </summary>
        public double Nominal { get; set; }

        /// <summary>
        /// Возвращает или задает ставку процента потока до момента записи
        /// </summary>
        public double Rate { get; set; }

        /// <summary>
        /// Возвращает или задает дату, на которую установились данный номинал и процентная ставка
        /// </summary>
        public DateTime Date { get; set; }
    }
}