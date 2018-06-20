using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examiner.Core.DTOs
{
    public class AnswerDTO
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public bool IsCorrect { get; set; }
        public Guid ApplicableFor { get; set; }
        public virtual string UserId { get; set; }
    }
}
