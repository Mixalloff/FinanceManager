using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinanceManager.Models.Authorization
{
    /// <summary>
    /// Класс, содержащий данные пользователя
    /// </summary>
    public class UserData
    {
        /// <summary>
        /// Возвращает или задает Id пользователя
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Возвращает или задает имя пользователя
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Возвращает или задает фамилию пользователя
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Возвращает или задает аватар пользователя
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// Возвращает или задает баланс пользователя
        /// </summary>
        public double Balance { get; set; }

        /// <summary>
        /// Возвращает или задает баланс пользователя
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// Возвращает или задает страну пользователя
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Возвращает или задает город пользователя
        /// </summary>
        public string Town { get; set; }

        /// <summary>
        /// Возвращает или задает логин пользователя
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Возвращает или задает email пользователя
        /// </summary>
        public string Email { get; set; }
    }
}