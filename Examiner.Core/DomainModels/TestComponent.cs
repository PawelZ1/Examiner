using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examiner.Core.DomainModels
{
    public abstract class TestComponent
    {
        public Guid Id { get; private set; }

        //Navigation properties
        public virtual string UserId { get; private set; }
        public virtual ApplicationUser User { get; private set; }

        //Components properties
        public virtual ICollection<TestComponent> Components { get; set; }
        public virtual TestComponent Root { get; set; }

        //Methods for components
        public abstract void Add(TestComponent component);
        public abstract void Remove(TestComponent component);

        //Methods for Bases
        public abstract Guid GetApplicableFor();
        public abstract string GetContent();

        public TestComponent() { }

        public TestComponent(Guid id, string userId)
        {
            Id = id;
            UserId = userId;
            Components = new List<TestComponent>();
        }
    }
}
