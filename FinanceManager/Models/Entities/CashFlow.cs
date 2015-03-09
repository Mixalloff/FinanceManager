using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinanceManager.Models.Entities
{
    /// <summary>
    /// Денежные потоки
    /// </summary>
    public class CashFlow
    {
        public CashFlow()
        {
            this.Archives = new List<Archive>();
            this.Links = new List<CashFlow>();
        }

        /// <summary>
        /// Возвращает или задает идентификатор записи архива
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CashFlowId { get; set; }

        /// <summary>
        /// Возвращает или задает ссылку на родительский поток (при вложенных потоках)
        /// </summary>
       // [ForeignKey("CashFlowId")]
        public CashFlow Link { get; set; }

        /// <summary>
        /// Возвращает или задает счет, по которому производится операция
        /// </summary>
        //[ForeignKey("AccountId")]
        public Account OperatingAccount { get; set; }

        /// <summary>
        /// Возвращает или задает группу, которой принадлежит данный поток
        /// </summary>
       // [ForeignKey("GroupId")]
        public Group GroupFlows { get; set; }

        /// <summary>
        /// Возвращает или задает наименование потока
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Возвращает или задает номинальную стоимость потока
        /// </summary>
        public double Nominal { get; set; }

        /// <summary>
        /// Возвращает или задает процентную ставку по данной операции
        /// </summary>
        public double Rate { get; set; }

        /// <summary>
        /// Возвращает или задает дату начала текущего цикла (для переменных потоков - дата операции, для регулярных - начало текущего цикла)
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Возвращает или задает дату, до которой действителен поток
        /// </summary>
        public DateTime endDate { get; set; }

        /// <summary>
        /// Возвращает или задает период операций по данному потоку в днях
        /// </summary>
        public int Period { get; set; }

        /// <summary>
        /// Возвращает или задает тип потока
        /// </summary>
       // [ForeignKey("TypeCashFlowId")]
        public TypeCashFlow Type { get; set; }

        /// <summary>
        /// Возвращает или задает статус потока
        /// </summary>
        //[ForeignKey("OperationStatusId")]
        public OperationStatus Status { get; set; }

        /// <summary>
        /// Возвращает или задает заметки к потоку
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        /// Возвращает или задает список связанных записей в архиве
        /// </summary>
        public virtual ICollection<Archive> Archives { get; set; }

        /// <summary>
        /// Возвращает или задает список дочерних потоков
        /// </summary>
        public virtual ICollection<CashFlow> Links { get; set; }
    }
}