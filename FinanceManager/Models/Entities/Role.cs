using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinanceManager.Models.Entities
{
    /// <summary>
    /// Роли пользователей
    /// </summary>
    public class Role
    {
        /// <summary>
        /// Конструктор, инициализирующий связь ролей с пользователем
        /// </summary>
        public Role()
        {
            this.Users = new List<User>();
        }

        /// <summary>
        /// Возвращает или задает идентификатор роли
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoleId { get; set; }

        /// <summary>
        /// Возвращает или задает наименование роли
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Возвращает или задает приоритет роли
        /// </summary>
        public int Priority { get; set; }

        /// <summary>
        /// Возвращает или задает список пользователей, имеющих данную роль
        /// </summary>
        public virtual ICollection<User> Users { get; set; }
    }
}