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
        public string Category { get; private set; }

        //Navigation properties
        public virtual ICollection<Question> Questions { get; private set; }

        public virtual string UserId { get; private set; }
        public virtual ApplicationUser User { get; private set; }

        public Test(Guid id, string name, string category, string userId)
        {
            Id = id;
            SetName(name);
            SetCategory(category);
            UserId = userId;
        }

        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Test name cannot be empty");

            Name = name;
        }

        public void SetCategory(string category)
        {
            if (string.IsNullOrWhiteSpace(category))
                throw new ArgumentException("Test category cannot be empty");

            Category = category;
        }
    }
}
