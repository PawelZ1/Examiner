using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examiner.Core.DTOs
{
    public class AnswerDTO
    {
        public Guid AnswerId { get; set; }
        public string AnswerContent { get; set; }
        public bool IsCorrect { get; set; }
        public virtual Guid QuestionId { get; set; }
    }

}
