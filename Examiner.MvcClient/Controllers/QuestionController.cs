using AutoMapper;
using Examiner.Core.DTOs;
using Examiner.Core.Interfaces.Services;
using Examiner.Core.Services;
using Examiner.MvcClient.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Examiner.MvcClient.Controllers
{
    [Authorize]
    public class QuestionController : AuthorizationController
    {
        private readonly IQuestionService _questionService;
        private readonly IMapper _mapper;


        public QuestionController(IQuestionService questionService, IMapper mapper) 
        {
            _questionService = questionService;
            _mapper = mapper;
        }
        
        // GET: QuestionBase
        public async Task<ActionResult> Index()
        {
            string user = User.Identity.GetUserId();
            IEnumerable<QuestionDTO> questions = await _questionService.GetUserQuestions(user);
            IEnumerable<QuestionForListViewModel> model =  _mapper.Map<IEnumerable<QuestionDTO>, IEnumerable<QuestionForListViewModel>>(questions);

            return View(model);
        }

        public async Task<ActionResult> GetQuestionDetails(Guid id)
        {
            QuestionDTO question = await _questionService.GetQuestion(id);
            if (GetUserId() !=  question.UserId)
                return new HttpStatusCodeResult(HttpStatusCode.Unauthorized);

            QuestionViewModel model = _mapper.Map<QuestionDTO, QuestionViewModel>(question);

            return View(model);
        }

        public async Task<ActionResult> AddAnswer()
        {
            
        }
    }
}