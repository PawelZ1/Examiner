using AutoMapper;
using Examiner.Core.DTOs;
using Examiner.Core.Interfaces.Services;
using Examiner.MvcClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Examiner.MvcClient.Controllers
{
    public class AnswerController : AuthorizationController
    {
        private readonly IAnswerService _answerService;
        private readonly IMapper _mapper;

        public AnswerController(IAnswerService answerService, IMapper mapper)
        {
            _answerService = answerService;
            _mapper = mapper;
        }

        public async Task<ActionResult> RemoveAnswer(Guid id)
        {
            AnswerDTO answer = await _answerService.GetAnswerAsync(id);

            if (answer == null)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            if (GetUserId() != answer.UserId)
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);

            AnswerViewModel model = _mapper.Map<AnswerDTO, AnswerViewModel>(answer);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RemoveAnswerConfirmed(AnswerViewModel answerViewModel)
        {
            await _answerService.RemoveAnswerAsync(answerViewModel.Id);

            return RedirectToAction("GetQuestionDetails", "Question", new { id = answerViewModel.ApplicableFor });
        }
    }
}