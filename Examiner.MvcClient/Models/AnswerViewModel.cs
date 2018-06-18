using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Examiner.MvcClient.Models
{
    public class AnswerViewModel
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public bool IsCorrect { get; set; }
    }
}