using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examiner.Core.DomainModels
{
    public class QuestionBase
    {
        public Guid QuestionBaseId { get; private set; }
        public string Content { get; private set; }
        public Guid ApplicableFor { get; private set; }

        public virtual ICollection<Question> Questions { get; set; }

        public virtual ApplicationUser User { get; private set; }
        public virtual string ApplicationUserId { get; private set; }

        private QuestionBase() { }

        public QuestionBase(Guid questionBaseId, string content, string applicationUserId, Guid applicableFor)
        {
            QuestionBaseId = questionBaseId;
            SetContent(content);
            ApplicableFor = applicableFor;
            ApplicationUserId = applicationUserId;
        }

        public void SetContent(string content)
        {
            if (string.IsNullOrWhiteSpace(content))
                throw new ArgumentNullException("Question content canot be empty");

            Content = content;
        }
    }
}
