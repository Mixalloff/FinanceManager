using FinanceManager.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinanceManager.Models.Authorization
{
    /// <summary>
    /// Класс, содержащий данные для авторизации
    /// </summary>
    public class LoginData
    {
        public LoginData()
        {
            this.Roles = new List<string>();
        }

        /// <summary>
        /// Возвращает или задает логин пользователя
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Возвращает или задает авторизован пользователь или нет
        /// </summary>
        public bool IsAuthenticated { get; set; }

        /// <summary>
        /// Возвращает или задает роли пользователя
        /// </summary>
        public ICollection<string> Roles { get; set; }


    }
}