using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Examiner.MvcClient.Models
{
    public class TestViewModel
    {
        public Guid TestId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string UserId { get; set; }
    }
}