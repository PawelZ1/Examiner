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
        public string Content { get; set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        public Guid? ApplicableFor { get; private set; }

        public virtual string UserId { get; private set; }
        public virtual ApplicationUser User { get; private set; }

        public virtual ICollection<TestVersion> TestVersions { get; set; }
        public virtual ICollection<Question> Questions { get; set; }

        private Test() { }

        public Test(Guid testId ,string content, string userId, Guid? applicableFor = null)
        {
            TestId = testId;
            SetContent(content);
            UserId = userId;
            ApplicableFor = applicableFor;
            CreatedAt = DateTime.UtcNow;
            Update();
        }

        public void SetContent(string content)
        {
            if (string.IsNullOrWhiteSpace(content))
                throw new ArgumentNullException("Content cannot be empty");

            Content = content;
        }

        public void Update()
        {
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
