using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examiner.Core.DTOs
{
    public class TestComponentDTO
    {
        public virtual ICollection<TestComponentDTO> Components { get; set; }
    }
}
