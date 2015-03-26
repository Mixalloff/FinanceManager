using FinanceManager.Models;
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
            Response.Redirect("/");
            return null;
        }
    }
}
