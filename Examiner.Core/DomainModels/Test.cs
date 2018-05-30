using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examiner.Core.DomainModels
{
    public class Test : TestComponent
    {
        public virtual Guid TestBaseId { get; private set; }
        public virtual TestBase TestBase { get; private set; }

        private Test() { }

        public Test(Guid id, TestBase testBase, string userId) : base(id, userId)
        {
            TestBase = testBase;
        }

        public override Guid GetApplicableFor()
        {
            if (TestBase.ApplicableFor.HasValue)
                return TestBase.ApplicableFor.Value;

            //if method reaches this point Exception is thrown
            throw new ArgumentNullException("This Test cannot be applied as component");
        }

        public override string GetContent()
        {
            return TestBase.Content;
        }

        public override void Add(TestComponent component)
        {
            if (TestBase.TestBaseId == component.GetApplicableFor())
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
