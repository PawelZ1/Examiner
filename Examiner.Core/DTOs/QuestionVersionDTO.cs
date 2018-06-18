using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examiner.Core.DTOs
{
    public class QuestionVersionDTO
    {
        public virtual Guid Id { get; set; }
        public virtual QuestionDTO Question { get; set; }
    }
}
