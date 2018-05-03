using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examiner.Core.DTOs
{
    public class TestDTO
    {
        public Guid TestId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public IEnumerable<QuestionDTO> Questions { get; set; }
        public string UserId { get; set; }
    }

}
