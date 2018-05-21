using Examiner.Core.DomainModels;
using Examiner.Infrastructure.Data;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examiner.Infrastructure.IdentityServices
{
    public class ApplicationUserStore : UserStore<ApplicationUser>
    {
        public ApplicationUserStore(ExaminerDBContext context)
            : base(context)
        {
        }
    }
}
