using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Examiner.MvcClient.Controllers
{
    public class AuthorizationController : Controller
    {
        public Func<string> GetUserId;

        public AuthorizationController()
        {
            GetUserId = () => User.Identity.GetUserId();
        }
    }
}