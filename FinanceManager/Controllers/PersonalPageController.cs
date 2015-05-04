using FinanceManager.Models;
using FinanceManager.Models.Authorization;
using FinanceManager.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FinanceManager.Controllers
{
    public class PersonalPageController : Controller
    {
        //
        // GET: /PersonalPage/

        public ActionResult Index()
        {
            HttpCookie cookieReq = Request.Cookies[FormsAuthentication.FormsCookieName];
            string cookie = cookieReq != null ? cookieReq.Value : string.Empty;
            if (cookie != string.Empty)
            {
                string login = FormsAuthentication.Decrypt(cookie).Name;
                if (new UserRepository(new FinanceManagerDb()).GetAll().FirstOrDefault(x => x.Login == login) != null)
                {
                    return View();
                }
            }
            return Redirect("/Home?isRedirect=true");
        }

        public RedirectResult operations()
        {
            return Redirect("/PersonalPage");
        }

        public RedirectResult accounts()
        {
            return Redirect("/PersonalPage");
        }

        public RedirectResult chats()
        {
            return Redirect("/PersonalPage");
        }

        [HttpGet]
        public JsonResult GetUserData() 
        {
            HttpCookie cookieReq = Request.Cookies[FormsAuthentication.FormsCookieName];
            string cookie = cookieReq != null ? cookieReq.Value : string.Empty;
            if (cookie != string.Empty)
            {
                string login = FormsAuthentication.Decrypt(cookie).Name;
                using (FinanceManagerDb context = new FinanceManagerDb())
                {
                    UserRepository users = new UserRepository(context);
                    var user = users.FindByLogin(login);

                    UserData data = new UserData();
                    data.Name = user.Name;
                    data.Surname = user.Surname;
                    data.Login = user.Login;
                    data.Country = user.Country;
                    data.Town = user.Town;
                    data.Email = user.Email;
                    data.Image = user.Photo;
                    data.Currency = user.MainCurrency.Name;

                    // Заглушка на баланс (необходимо рассчитывать на основании счетов и операций)
                    data.Balance = 0;

                    return this.Json(data, JsonRequestBehavior.AllowGet);
                }
            }

            return null;
        }
    }
}
