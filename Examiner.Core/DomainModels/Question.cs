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
        public virtual ICollection<Answer> Answers { get; set; }
        public virtual ICollection<Test> Tests { get; set; }

        public virtual Guid? TestCategoryId { get; set; }
        public virtual TestCategory TestCategory { get; set; }

        private Question() { }

        public Question(Guid questionId, string questionContent, Guid testCategoryId)
        {
            QuestionId = questionId;
            SetQuestionContent(questionContent);
            TestCategoryId = testCategoryId;
        }

        public void SetQuestionContent(string questionContent)
        {
            if (string.IsNullOrWhiteSpace(questionContent))
                throw new ArgumentNullException("Question content cannot be empty");

            QuestionContent = questionContent;
        }

    }
}
