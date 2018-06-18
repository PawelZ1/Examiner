using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examiner.Core.DomainModels
{
    public class TestVersion : TestComponent
    {
        public string Name { get; private set; }
        public virtual Guid TestId { get; private set; }
        public virtual Test Test { get; private set; }
        public DateTime CreatedAt { get; set; } 
        public DateTime UpdatedAt { get; set; } 

        private TestVersion() { }

        public TestVersion(Guid id, Test test, string name) : base(id)
        {
            Test = test;
            SetName(name);
            CreatedAt = DateTime.UtcNow;
            Update();
        }

        public override Guid GetApplicableFor()
        {
            if (Test.ApplicableFor.HasValue)
                return Test.ApplicableFor.Value;

            //if method reaches this point Exception is thrown
            throw new ArgumentException("This Test cannot be applied as component");
        }

        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException("Name cannot be empty");

            Name = name;
        }

        public override string GetContent()
        {
            return Test.Content;
        }

        public void Update()
        {
            UpdatedAt = DateTime.UtcNow;
        }

        public override void Add(TestComponent component)
        {
            if (Test.TestId == component.GetApplicableFor())
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
