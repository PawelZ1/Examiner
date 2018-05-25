using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examiner.Core.DTOs
{
    public class TestCategoryDTO
    {
        public Guid TestCategoryId { get; set; }
        public string Name { get; set; }
        public IEnumerable<TestDTO> Tests { get; set; }
        public string UserId { get; set; }
    }
}
