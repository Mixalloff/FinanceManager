using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinanceManager.Models.Entities
{
    /// <summary>
    /// Тип денежных потоков
    /// </summary>
    public class TypeCashFlow
    {
        /// <summary>
        /// Возвращает или задает идентификатор типа потоков
        /// </summary>
        [Key]
        public int TypeCashFlowId { get; set; }

        /// <summary>
        /// Возвращает или задает наименование типа денежных потоков
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Возвращает или задает коэффициент потока ( 1 = доход, -1 = расход)
        /// </summary>
        public int Koefficient { get; set; }

        /// <summary>
        /// Возвращает или задает ссылку на родительский тип (иерархическая структура)
        /// </summary>
        public TypeCashFlow Link { get; set; }

    }
}