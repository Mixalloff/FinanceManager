using FinanceManager.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.Data.Entity;



namespace FinanceManager.Models.Repositories
{
    /// <summary>
    /// Репозиторий пользователей
    /// </summary>
    public class UserRepository : AbstractRepository<User>
    {
        public UserRepository(FinanceManagerDb context)
            : base(context)
        {
        }

        public override IEnumerable<User> GetAll()
        {
            
                return this.IncludeReferences(context.Users)
                    .ToList();
               
            
        }

        /// <summary>
        /// Получение данных о пользователях, включая внешние связи
        /// </summary>
        /// <param name="users">Список пользователей без связей</param>
        /// <returns>Список пользователей со внешними связями</returns>
        private IQueryable<User> IncludeReferences(IQueryable<User> users)
        {
            return users
                .Include(x => x.Roles)
                .Include(x => x.Accounts)
                .Include(x => x.MainCurrency);            
        }

        /// <summary>
        /// Находит пользователя по логину
        /// </summary>
        /// <param name="login">Логин пользователя</param>
        /// <returns>Данные о пользователе</returns>
        public User FindByLogin(string login)
        {
            using (var context = new FinanceManagerDb())
            {
                return this.IncludeReferences(context.Users).FirstOrDefault(x => x.Login == login);
            }
        }

        /// <summary>
        /// Находит пользователя по email
        /// </summary>
        /// <param name="email">Email пользователя</param>
        /// <returns>Данные о пользователе</returns>
        public User FindByEmail(string email)
        {
            using (var context = new FinanceManagerDb())
            {
                return this.IncludeReferences(context.Users).FirstOrDefault(x => x.Email == email);
            }
        }
    }

   
}