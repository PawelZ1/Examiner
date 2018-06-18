using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examiner.Core.DomainModels
{
    public class QuestionVersion : TestComponent
    {
        public virtual Guid QuestionId { get; private set; }
        public virtual Question Question { get; private set; }

        private QuestionVersion() { }

        public QuestionVersion(Guid id, Question question) : base(id)
        {
            Question = question;
        }

        public override Guid GetApplicableFor()
        {
            return Question.ApplicableFor;    
        }

        public override string GetContent()
        {
            return Question.Content;
        }

        public override void Add(TestComponent component)
        {
            if (Question.QuestionId == component.GetApplicableFor())
                Components.Add(component);
            else
                throw new ArgumentException("Given component is not applicable for this element");
        }

        public override void Remove(TestComponent component)
        {
            Components.Remove(component);
        }


    }
}
