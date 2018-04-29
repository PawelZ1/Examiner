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
        public virtual Guid QuestionId { get; private set; }
        public virtual Question Question { get; private set; }


        public Answer(Guid answerId, string answerContent, bool isCorrect, Guid questionId)
        {
            AnswerId = answerId;
            SetAnswerContent(answerContent);
            SetIsCorrect(isCorrect);
            QuestionId = QuestionId;
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
