using FinanceManager.Models;
using FinanceManager.Models.Authorization;
using FinanceManager.Models.Entities;
using FinanceManager.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FinanceManager.Controllers
{
    public class AuthorizationController : Controller
    {
        //
        // GET: /Authorization/

        /// <summary>
        /// Проверяет данные пользователя, осуществляющего вход
        /// </summary>
        /// <param name="login">Логин или email пользователя</param>
        /// <param name="password">Пароль пользователя</param>
        /// <returns>Данные авторизации с логином и ролью</returns>
        [HttpPost]
        public JsonResult SignIn(string login, string password)
        {
            foreach (var user in new UserRepository(new FinanceManagerDb()).GetAll())
            {
                if (user.Login == login || user.Email == login)
                {
                    if (user.Password == password)
                    {
                        LoginData data = new LoginData();
                        data.Login = user.Login;
                        data.IsAuthenticated = true;
                        foreach (var role in user.Roles)
                        {
                            data.Roles.Add(role.Name);
                        }

                        // Работа с куки
                        Response.Cookies["VisitorName"].Value = user.Name;
                        Response.Cookies["VisitorSurname"].Value = user.Surname;
                        Response.Cookies["CookieNameOfTicket"].Value = FormsAuthentication.FormsCookieName;

                        DateTime expiration = DateTime.Now.AddHours(1);
                        var ticket = new FormsAuthenticationTicket(1, user.Login, DateTime.Now, expiration, true, string.Empty, FormsAuthentication.FormsCookiePath);
                        var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket))
                        {
                            Expires = expiration
                        };
                        System.Web.HttpContext.Current.Response.Cookies.Add(cookie);

                        return this.Json(data);
                    }
                }
            }
            return this.Json(new LoginData { Login = login, Roles = null, IsAuthenticated = false });
        }

        [HttpPost]
        public JsonResult Register(string name, string surname, string email, string country, string town, string login, string password, string currency)
        {
            using (FinanceManagerDb context = new FinanceManagerDb())
            {
                UserRepository users = new UserRepository(context);
                // Если не существет пользователя с данным email и login
                if (users.FindByLogin(login) == null && users.FindByEmail(email) == null)
                {
                    User user = new User();
                    user.Name = name;
                    user.Surname = surname;
                    user.Email = email;
                    user.Country = country;
                    user.Town = town;
                    user.Login = login;
                    user.Password = password;
                    user.Roles.Add(new RoleRepository(context).FindByName("Админ"));
                    user.MainCurrency = new CurrencyRepository(context).FindByName(currency);
                    new CurrencyRepository(context).FindByName(currency).Users.Add(user);
                    users.Create(user);

                    return this.Json("Пользователь успешно добавлен!");
                }
                
                else
                {
                    return this.Json(null);
                }
            }
        }
    }
}
