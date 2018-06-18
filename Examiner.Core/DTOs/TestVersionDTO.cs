using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examiner.Core.DTOs
{
    public class TestVersionDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public TestDTO Test { get; set; }
        public IEnumerable<TestComponentDTO> Components { get; set; }
    }
}
