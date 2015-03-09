using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinanceManager.Models.Entities
{
    /// <summary>
    /// Пользователь приложения
    /// </summary>
    public class User
    {
        /// <summary>
        /// Конструктор, инициализирующий связь пользователя с ролями
        /// </summary>
        public User()
        {
            this.Roles = new List<Role>();
            this.Accounts = new List<Account>();
            this.Groups = new List<Group>();
        }

        /// <summary>
        /// Возвращает или задает идентификатор пользователя
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        /// <summary>
        /// Возвращает или задает логин пользователя
        /// </summary>
       // [Required]
        public string Login { get; set; }
        
        /// <summary>
        /// Возвращает или задает имя пользователя
        /// </summary>
       // [Required]
        public string Name { get; set; }

        /// <summary>
        /// Возвращает или задает фамилию пользователя
        /// </summary>
       // [Required]
        public string Surname { get; set; }

        /// <summary>
        /// Возвращает или задает e-mail пользователя
        /// </summary>
       // [Required]
        public string Email { get; set; }

        /// <summary>
        /// Возвращает или задает пароль пользователя
        /// </summary>
       // [Required]
        public string Password { get; set; }

        /// <summary>
        /// Возвращает или задает страну пользователя
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Возвращает или задает город пользователя
        /// </summary>
        public string Town { get; set; }

        /// <summary>
        /// Возвращает или задает изображение пользователя
        /// </summary>
        public string Photo { get; set; }

        /// <summary>
        /// Возвращает или задает список ролей, принадлежащих пользователю
        /// </summary>
        public virtual ICollection<Role> Roles { get; set; }

        /// <summary>
        /// Возвращает или задает список счетов, принадлежащих пользователю
        /// </summary>
        public virtual ICollection<Account> Accounts { get; set; }

        /// <summary>
        /// Возвращает или задает основную расчетную валюту пользователя
        /// </summary>
       // [ForeignKey("CurrencyId")]
        public virtual Currency MainCurrency { get; set; }

        // <summary>
        /// Возвращает или задает список групп пользователя
        /// </summary>
        public virtual ICollection<Group> Groups { get; set; }
    }
}