using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examiner.Core.DomainModels
{
    public class Question : TestComponent
    {
        public virtual Guid QuestionBaseId { get; private set; }
        public virtual QuestionBase QuestionBase { get; private set; }

        private Question() { }

        public Question(Guid id, QuestionBase questionBase, string userId) : base(id, userId)
        {
            QuestionBase = questionBase;
        }

        public override Guid GetApplicableFor()
        {
            return QuestionBase.ApplicableFor;    
        }

        public override string GetContent()
        {
            return QuestionBase.Content;
        }

        public override void Add(TestComponent component)
        {
            if (QuestionBase.QuestionBaseId == component.GetApplicableFor())
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
