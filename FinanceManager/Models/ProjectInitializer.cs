using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FinanceManager.Models
{
    public class ProjectInitializer : DropCreateDatabaseIfModelChanges<FinanceManagerDb>
    {
        protected override void Seed(FinanceManagerDb context)
        {
        }
    }
}