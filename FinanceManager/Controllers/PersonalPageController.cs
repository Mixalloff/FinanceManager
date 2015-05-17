using FinanceManager.CommonClasses;
using FinanceManager.Models;
using FinanceManager.Models.Authorization;
using FinanceManager.Models.Entities;
using FinanceManager.Models.PersonalPage;
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

        [HttpPost]
        public JsonResult AddAccount(int userId, string name, double balance, int typeId, int currencyId, string logo)
        {
            using (FinanceManagerDb context = new FinanceManagerDb())
            {
                AccountRepository accounts = new AccountRepository(context);
                Account newAccount = new Account();
                AbstractRepository<AccountType> types = new AbstractRepository<AccountType>(context);
                CurrencyRepository curriencies = new CurrencyRepository(context);
                UserRepository users = new UserRepository(context);

                try
                {
                    accounts.Create(new Account()
                    {
                        Name = name,
                        Balance = balance,
                        AccountTypeId = types.FindById(typeId),
                        CurrencyOfAccount = curriencies.FindById(currencyId),
                        User = users.FindById(userId),
                        Logo = logo != string.Empty ? FileWorker.GetSavePhoto(logo, users.FindById(userId).Login, name, "accounts") : null
                    });

                    var Id = accounts.GetAll().ToList()[accounts.GetAll().ToList().Count - 1].AccountId;
                    return this.Json(Id);
                }
                catch { return this.Json(false); }
            }
        }

        [HttpPost]
        public JsonResult GetAccounts(int userId)
        {
            using (FinanceManagerDb context = new FinanceManagerDb())
            {
                AccountRepository accounts = new AccountRepository(context);
                List<AccountData> accountData = new List<AccountData>();
                foreach (var account in accounts.GetAll())
                {
                    try
                    {
                        if (account.User.UserId == userId)
                        {
                            accountData.Add(new AccountData()
                            {
                                Id = account.AccountId,
                                Name = account.Name,
                                Balance = account.Balance,
                                Type = account.AccountTypeId.Name,
                                Logo = account.Logo,
                                Currency = account.CurrencyOfAccount.Abbreviation,
                            });
                        }
                    }
                    catch (Exception e)
                    {
                        continue;
                    }
                }
                return this.Json(accountData);
            }
        }

        [HttpPost]
        public JsonResult GetOperations(int userId)
        {
            using (FinanceManagerDb context = new FinanceManagerDb())
            {
                List<OperationData> operations = new List<OperationData>();
                var accounts = new UserRepository(context).FindById(userId).Accounts.ToList();
                var allOperation = new CashFlowRepository(context).GetAll();
                
                for (int i = 0; i < accounts.Count; i++)
                {
                    foreach (var operation in allOperation)
                    {
                        try
                        {
                            if (accounts[i].AccountId == operation.OperatingAccount.AccountId)
                            {
                                operations.Add(new OperationData()
                                {
                                    Id = operation.CashFlowId,
                                    Name = operation.Name,
                                    Type = operation.Type.Name,
                                    Account = operation.OperatingAccount.Name,
                                    Group = operation.GroupFlows.Name,
                                    Price = operation.Nominal,
                                    Date = operation.StartDate.GetDateTimeFormats()[0],
                                    Notes = operation.Notes,
                                    IsSelected = false
                                });
                            }
                        }

                        catch (Exception e)
                        {
                            continue;
                        }
                    }
                }
                return this.Json(operations);
            }
        }

        [HttpPost]
        public JsonResult AddOperation(string name, int groupId, int accountId, int typeId, DateTime dateStart, double amount, string notes)
        {
            using (FinanceManagerDb context = new FinanceManagerDb())
            {
                var newFlow = new CashFlowRepository(context);
                var accounts = new AccountRepository(context);
                var groups = new GroupRepository(context);
                var types = new AbstractRepository<TypeCashFlow>(context);
                var statuses = new AbstractRepository<OperationStatus>(context);

                try
                { 
                    var currentAccount = accounts.FindById(accountId);
                    var currentOperationType = types.FindById(typeId);
                    if (currentOperationType.Koefficient > 0 || currentAccount.Balance >= amount)
                    {
                        newFlow.Create(new CashFlow()
                        {
                            OperatingAccount = currentAccount,
                            GroupFlows = groups.FindById(groupId),
                            Name = name,
                            Nominal = amount,
                            Rate = 1, // В данной версии программы долевые потоки не рассматриваются
                            StartDate = dateStart,
                            endDate = dateStart,
                            Period = 0, // В данной версии программы периодические потоки не рассматриваются
                            Type = currentOperationType,
                            Status = statuses.FindById(1), // 1
                            Notes = notes
                        });
                        currentAccount.Balance = currentAccount.Balance + currentOperationType.Koefficient * amount;
                        accounts.Update(currentAccount);
                        var Id = newFlow.GetAll().ToList()[newFlow.GetAll().ToList().Count - 1].CashFlowId;
                        return this.Json(Id);
                    }
                    return this.Json(false);
                }
                catch
                {
                    return this.Json(false);
                }   
            }
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
                    data.Id = user.UserId;
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

        public JsonResult DeleteOperation(List<int> operationId)
        {
            try
            {
                using (FinanceManagerDb context = new FinanceManagerDb())
                {
                    CashFlowRepository operations = new CashFlowRepository(context);
                    foreach (var id in operationId)
                    {
                        operations.Delete(operations.FindById(id));
                    }
                }
                return this.Json(true);
            }
            catch (Exception e) { return this.Json(false); }
        }

        public JsonResult DeleteAccount(int accountId)
        {
            try
            {
                using (FinanceManagerDb context = new FinanceManagerDb())
                {
                    AccountRepository accounts = new AccountRepository(context);
                    accounts.Delete(accounts.FindById(accountId));               
                }
                return this.Json(true);
            }
            catch(Exception e) { return this.Json(false); }
        }
    }
}
