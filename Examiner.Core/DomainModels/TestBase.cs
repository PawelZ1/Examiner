using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examiner.Core.DomainModels
{
    public class TestBase
    {
        public Guid TestBaseId { get; private set; }
        public string Content { get; set; }
        public Guid? ApplicableFor { get; private set; }

        public virtual ICollection<Test> Tests { get; set; }


        private TestBase() { }

        public TestBase(Guid testBaseId ,string content, Guid? applicableFor = null)
        {
            TestBaseId = testBaseId;
            SetContent(content);
            ApplicableFor = applicableFor;
        }

        public void SetContent(string content)
        {
            if (string.IsNullOrWhiteSpace(content))
                throw new ArgumentNullException("Content cannot be empty");

            Content = content;
        }
    }
}
