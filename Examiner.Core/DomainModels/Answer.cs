using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examiner.Core.DomainModels
{
    public class Answer : TestComponent
    {
        public string Content { get; private set; }
        public bool IsCorrect { get; private set; }

        private Guid ApplicableFor;
        public Question Question { get; set; }

        public virtual string UserId { get; private set; }
        public virtual ApplicationUser User { get; private set; }

        private Answer() { }

        public Answer(Guid id, string content, Guid applicableFor, bool isCorrect, string userId) : base(id)
        {
            SetContent(content);
            ApplicableFor = applicableFor;
            SetIsCorrect(isCorrect);
            UserId = userId;
        }

        public override string GetContent()
        {
            return Content;
        }

        public override Guid GetApplicableFor()
        {
            return ApplicableFor;
        }

        public void SetContent(string content)
        {
            if (string.IsNullOrWhiteSpace(content))
                throw new ArgumentNullException("Answer content cannot be empty");

            Content = content;
        }

        public void SetIsCorrect(bool value)
        {
            IsCorrect = value;
        }

        public override void Add(TestComponent component)
        {
            throw new NotImplementedException("This element cannot have components");
        }

        public override void Remove(TestComponent component)
        {
            throw new NotImplementedException("This element cannot have components");
        }
    }
}
