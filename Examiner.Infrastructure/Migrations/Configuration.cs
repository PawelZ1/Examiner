namespace Examiner.Infrastructure.Migrations
{
    using Examiner.Core.DomainModels;
    using Examiner.Infrastructure.Data;
    using Examiner.Infrastructure.IdentityServices;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Examiner.Infrastructure.Data.ExaminerDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Examiner.Infrastructure.Data.ExaminerDBContext context)
        {
            ApplicationUserManager _userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));

            ApplicationInitializer init = new ApplicationInitializer();
            init.InitializeUser(_userManager);
            init.InitializeData(context, _userManager);

            base.Seed(context);
        }
    }
}
