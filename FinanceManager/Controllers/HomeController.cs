using FinanceManager.Models;
using FinanceManager.Models.Entities;
using FinanceManager.Models.Repositories;
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
            //AbstractRepository<User> users = new AbstractRepository<User>();
            //users.Create(new User { Login = "mixalloff", Password = "111", Name = "Михаил", Surname = "Михалев" });
            //users.Save(db);

            return View();
        }

    }
}
