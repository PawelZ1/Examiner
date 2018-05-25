using Examiner.Core.DomainModels;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examiner.UnitTests.DomainModels
{
    [TestFixture]
    public class TestCategoryTests
    {
        public TestCategory CreateTestCategory()
        {
            return new TestCategory(Guid.NewGuid(), "Sample Category", Guid.NewGuid().ToString());
        }

        public void SetName_GivenNullString_ThrowsArgumentNullException()
        {
            //Arrange
            TestCategory category = CreateTestCategory();

            //Act
            Action act = () => category.SetName(null);

            //Assert
            act.Should().Throw<ArgumentNullException>();
        }

        public void SetName_GivenString_ChangesName()
        {
            //Arrange
            TestCategory category = CreateTestCategory();
            string newName = "Changed Name";

            //Act
            category.SetName(newName);

            //Assert
            category.Name.Should().Be(newName);
        }
    }
}
