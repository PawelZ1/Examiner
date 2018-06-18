using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examiner.Core.DomainModels
{
    public class Question
    {
        public Guid QuestionId { get; private set; }
        public string Content { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        public Guid ApplicableFor { get; private set; }
        public Test Test { get; private set; }

        public virtual string UserId { get; private set; }
        public virtual ApplicationUser User { get; private set; }

        public virtual ICollection<QuestionVersion> QuestionVersions { get; private set; }
        public virtual ICollection<Answer> Answers { get;  private set; }

        private Question() { }

        public Question(Guid questionId, string content, string userId, Guid applicableFor)
        {
            QuestionId = questionId;
            SetContent(content);
            UserId = userId;
            ApplicableFor = applicableFor;
            CreatedAt = DateTime.UtcNow;
            Update();
        }

        public void SetContent(string content)
        {
            if (string.IsNullOrWhiteSpace(content))
                throw new ArgumentNullException("Question content canot be empty");

            Content = content;
        }

        public void Update()
        {
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
