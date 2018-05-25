using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Examiner.Core.DomainModels
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<TestCategory> TestCategories { get; private set; }
        public virtual ICollection<Test> Tests { get; private set; }
        public virtual ICollection<Question> Questions { get; private set; }
        public virtual ICollection<Answer> Answers { get; private set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one 
            // defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity =
                await manager.CreateIdentityAsync(this,
                    DefaultAuthenticationTypes.ApplicationCookie);

            // Add custom user claims here
            return userIdentity;
        }
    }
}
