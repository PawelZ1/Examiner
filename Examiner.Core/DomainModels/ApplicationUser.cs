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
        public virtual ICollection<TestComponent> TestComponents { get; set; }
        public virtual ICollection<TestBase> TestBases { get; set; }
        public virtual ICollection<QuestionBase> QuestionBases { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }

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
