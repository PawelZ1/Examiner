using Examiner.Core.DomainModels;
using Examiner.Infrastructure.IdentityServices;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examiner.Infrastructure.Data
{
    public class ApplicationInitializer
    {
        public void InitializeUser(ApplicationUserManager userManager)
        {
            var user = new ApplicationUser
            {
                UserName = "user1@email.com",
                Email = "user1@email.com"
            };

            if (userManager.FindByName("user1@email.com") == null)
                userManager.Create(user, "Admin1");

        }

       public void InitializeData(ExaminerDBContext context, ApplicationUserManager userManager)
        {
            var user = userManager.FindByName("user1@email.com");

            context.Tests.AddOrUpdate(new Test(Guid.NewGuid(), "C# Essential", "Programming Languages", user.Id));
        }
    }
}
