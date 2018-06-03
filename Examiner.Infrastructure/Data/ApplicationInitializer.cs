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
                Id = "77C443D6-A6AE-49BF-913B-35DD1B4E4B1A",
                UserName = "user1@email.com",
                Email = "user1@email.com"
            };

            if (userManager.FindByName("user1@email.com") == null)
                userManager.Create(user, "Admin1");

        }

       public void InitializeData(ExaminerDBContext context, ApplicationUserManager userManager)
        {

        }
    }
}
