using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examiner.Core.DomainModels
{
    public class Answer
    {
        public Guid AnswerId { get; private set; }
        public string AnswerContent { get; private set; }
        public bool IsCorrect { get; private set; }

        //Navigation properties
        public virtual ICollection<Question> Questions { get; set; }

        public virtual Guid? TestCategoryId { get; set; }
        public virtual TestCategory TestCategory { get; set; }

        public Answer(Guid answerId, string answerContent, bool isCorrect, Guid testCategoryId)
        {
            AnswerId = answerId;
            SetAnswerContent(answerContent);
            SetIsCorrect(isCorrect);
            TestCategoryId = testCategoryId;
        }

        public void SetAnswerContent(string answerContent)
        {
            if (string.IsNullOrWhiteSpace(answerContent))
                throw new ArgumentException("Answer content cannot be empty");

            AnswerContent = answerContent;
        }

        public void SetIsCorrect(bool isCorrect)
        {
            IsCorrect = isCorrect;
        }
    }
}
