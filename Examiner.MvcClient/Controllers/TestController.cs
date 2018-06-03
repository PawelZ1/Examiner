using Examiner.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Examiner.MvcClient.Controllers
{
    public class TestController : Controller
    {
        private readonly ExaminerDBContext _context;

        public TestController(ExaminerDBContext context)
        {
            _context = context;
        }

        // GET: Test
        public ActionResult Index()
        {

            var model = _context.TestComponents.ToList();

            return View(model);
        }
    }
}