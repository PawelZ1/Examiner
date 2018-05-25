using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examiner.Core.DomainModels
{
    public class Test
    {
        public Guid TestId { get; private set; }
        public string Name { get; private set; }

        //Navigation properties
        public virtual ICollection<Question> Questions { get; set; }

        public virtual Guid? TestCategoryId { get; set; }
        public virtual TestCategory TestCategory { get; set; }

        private Test() { }

        public Test(Guid id, string name, Guid testCategoryId)
        {
            TestId = id;
            SetName(name);
            TestCategoryId = testCategoryId;
        }

        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException("Test name cannot be empty");

            Name = name;
        }
    }
}
