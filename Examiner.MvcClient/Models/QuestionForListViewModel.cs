using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Examiner.MvcClient.Models
{
    public class QuestionForListViewModel
    {
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Guid QuestionId { get; set; }
        public string Content { get; set; }
        public int NumberOfAnswers { get; set; }
    }
}