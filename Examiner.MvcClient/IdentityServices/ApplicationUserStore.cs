using Examiner.Core.DomainModels;
using Examiner.Infrastructure.Data;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Examiner.MvcClient.IdentityServices
{
    public class ApplicationUserStore : UserStore<ApplicationUser>
    {
        public ApplicationUserStore(ExaminerDBContext context)
            : base(context)
        {
        }
    }
}