using FinanceManager.Models;
using FinanceManager.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            var type = new AccountType { AccountTypeId = 1, Name = "Mike" };
            db.AccountTypes.Add(type);
            int recordsAffected = db.SaveChanges();

            return View();
        }

    }
}
