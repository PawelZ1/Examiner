using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examiner.Core.DTOs
{
    public class QuestionDTO
    {
        public Guid QuestionId { get; set; }
        public string QuestionContent { get; set; }
        public virtual IEnumerable<AnswerDTO> Answers { get; set; }
        public virtual Guid? TestId { get; set; }
        public virtual string UserId { get; set; }
    }

}
