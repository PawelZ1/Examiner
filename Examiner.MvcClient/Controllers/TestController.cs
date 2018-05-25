using AutoMapper;
using Examiner.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Examiner.Core.DTOs;
using Examiner.MvcClient.Models;
using System.Threading.Tasks;

namespace Examiner.MvcClient.Controllers
{
    [Authorize]
    public class TestController : Controller
    {
        private readonly ITestService _testService;
        private readonly IMapper _mapper;


        public TestController(ITestService testService, IMapper mapper)
        {
            _testService = testService;
            _mapper = mapper;
        }

    }
}