﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinanceManager.Models.Entities
{
    /// <summary>
    /// Каталог (группа) для группировки схожих финансовых потоков
    /// </summary>
    public class Group
    {
        /// <summary>
        /// Возвращает или задает идентификатор группы
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GroupId { get; set; }

        /// <summary>
        /// Возвращает или задает наименование группы
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Возвращает или задает ссылку на родительскую группу (иерархическая структура)
        /// </summary>
        public Group Link { get; set; }

        /// <summary>
        /// Возвращает или задает путь к логотипу группы
        /// </summary>
        public string Logo { get; set; }

        /// <summary>
        /// Возвращает или задает владельца группы
        /// </summary>
        public User UserId { get; set; }
    }
}