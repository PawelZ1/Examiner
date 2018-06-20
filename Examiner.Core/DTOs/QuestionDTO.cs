using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examiner.Core.DTOs
{
    public class QuestionDTO
    {
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Guid QuestionId { get; set; }
        public string Content { get; set; }
        public string UserId { get; set; }
        public Guid ApplicableFor { get; private set; }
        public ICollection<AnswerDTO> AnswerDTOs { get; set; }
    }
}
