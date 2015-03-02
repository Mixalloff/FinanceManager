using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinanceManager.Models.Entities
{
    /// <summary>
    /// Электронные кошельки (в том числе счет мобильного и другие электронные финансовые хранилища)
    /// </summary>
    public class EWallet
    {
        /// <summary>
        /// Возвращает или устанавливает идентификатор электронного хранилища
        /// </summary>
        [Key]
        public int EWalletId { get; set; }

        /// <summary>
        /// Возвращает или устанавливает ресурс, содержащий данный кошелек
        /// </summary>
       // [ForeignKey("ExternalResourceId")]
        public ExternalResource ExResource { get; set; }

        /// <summary>
        ///  Возвращает или устанавливает счет, связанный с электронным хранилищем
        /// </summary>
        public Account Account { get; set; }

        /// <summary>
        /// Возвращает или устанавливает логин на ресурсе
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Возвращает или устанавливает пароль на ресурсе
        /// </summary>
        public string Password { get; set; }     
    }
}