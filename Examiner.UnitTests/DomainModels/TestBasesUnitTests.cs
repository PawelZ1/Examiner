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
    public class TestBasesUnitTests
    {
        public TestBase CreateTestBase()
        {
            return new TestBase(Guid.NewGuid(), "Sample Content");
        }
        
        [Test]
        public void SetContent_GivenEmptyString_ThrowsArgumentNullException()
        {
            //Arrange
            var testBase = CreateTestBase();

            //Act
            Action act = () => testBase.SetContent("");

            //Assert
            act.Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void SetContent_GivenString_ChangesContent()
        {
            //Arrange
            var testBase = CreateTestBase();

            //Act
            testBase.SetContent("Changed content");

            //Assert
            testBase.Content.Should().Be("Changed content");
        }
    }
}
