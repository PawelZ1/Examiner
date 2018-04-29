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
        public string QuestionContent { get; private set; }

        //Navigation properties
        public virtual ICollection<Answer> Answers { get; private set; }

        public virtual Guid? TestId { get; private set; }
        public virtual Test Test { get; private set; }

        public virtual string UserId { get; private set; }
        public virtual ApplicationUser User { get; private set; }

        public Question(Guid questionId, string questionContent, string userId)
        {
            QuestionId = questionId;
            SetQuestionContent(questionContent);
            UserId = userId;
        }

        public void SetQuestionContent(string questionContent)
        {
            if (string.IsNullOrWhiteSpace(questionContent))
                throw new ArgumentException("Question content cannot be empty");

            QuestionContent = questionContent;
        }

        public void SetTestId(Guid testId)
        {
            TestId = testId;
        }
    }
}
