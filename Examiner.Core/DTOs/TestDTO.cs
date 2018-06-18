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
        public string Content { get; set; }
        public Guid? ApplicableFor { get; set; }

        public virtual ICollection<TestVersionDTO> TestVersions { get; set; }
    }
}
