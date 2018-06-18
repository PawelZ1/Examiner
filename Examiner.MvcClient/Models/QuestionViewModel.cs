using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Examiner.MvcClient.Models
{
    public class QuestionViewModel
    {
        public Guid QuestionId { get; set; }
        public string Content { get; set; }
        public Guid ApplicableFor { get; set; }
        public string UserId { get; set; }
        public ICollection<AnswerViewModel> Answers { get; set; }
    }
}