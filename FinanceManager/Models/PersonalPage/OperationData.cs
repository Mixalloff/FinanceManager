using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinanceManager.Models.PersonalPage
{
    public class OperationData
    {
        /// <summary>
        /// Возвращает или задает Id операции
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Возвращает или задает название операции
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Возвращает или задает тип операции
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Возвращает или задает счет операции
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// Возвращает или задает группу операции
        /// </summary>
        public string Group { get; set; }

        /// <summary>
        /// Возвращает или задает номинал операции
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// Возвращает или задает дату операции
        /// </summary>
        public string Date { get; set; }

        /// <summary>
        /// Возвращает или задает заметки по операции
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        /// Выбрана ли операция
        /// </summary>
        public bool IsSelected { get; set; }
    }
}