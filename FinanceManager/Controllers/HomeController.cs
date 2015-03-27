using FinanceManager.Models;
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
    public class HomeController : Controller
    {       
        // Создаем контекст данных
        FinanceManagerDb db = new FinanceManagerDb();

        //
        // GET: /Home/
        public ActionResult Index()
        {
            //AbstractRepository<User> users = new AbstractRepository<User>(db);
            //users.Create(new User { Login = "mixalloff1", Password = "111", Name = "Михаил", Surname = "Михалев" });
            //users.Save();

            HttpCookie cookieReq = Request.Cookies[FormsAuthentication.FormsCookieName];
            string cookie = cookieReq != null ? cookieReq.Value : string.Empty;
            if (cookie != string.Empty)
            {
                string login = FormsAuthentication.Decrypt(cookie).Name;
                if (new UserRepository(new FinanceManagerDb()).GetAll().FirstOrDefault(x => x.Login == login) != null)
                {
                    return Redirect("/PersonalPage"); ;
                }
            }
            return View();
        }

    }
}
