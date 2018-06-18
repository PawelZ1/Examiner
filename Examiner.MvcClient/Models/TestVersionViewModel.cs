using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Examiner.MvcClient.Models
{
    public class TestVersionViewModel
    {
        public string Name { get; set; }
        public Guid Id { get; set; }
        public int NumberOfQuestions { get; set; }
    }
}