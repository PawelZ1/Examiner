using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examiner.Core.DomainModels
{
    public class TestCategory
    {
        public Guid TestCategoryId { get; private set; }
        public string Name { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        //Navigation properties
        public virtual ICollection<Test> Tests { get; private set; }
        public virtual ICollection<Question> Questions { get; private set; }
        public virtual ICollection<Answer> Answers { get; private set; }

        public virtual string UserId { get; private set; }
        public virtual ApplicationUser User { get; private set; }

        private TestCategory() { }

        public TestCategory(Guid testCategoryId, string name, string userId)
        {
            TestCategoryId = testCategoryId;
            SetName(name);
            UserId = userId;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException("Test Category Name cannot be empty");

            Name = name;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
