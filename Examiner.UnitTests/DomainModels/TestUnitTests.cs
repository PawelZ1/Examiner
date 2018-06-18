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
    public class TestUnitTests
    {
        public Test CreateTest()
        {
            return new Test(Guid.NewGuid(), "Sample Content", Guid.NewGuid().ToString());
        }
        
        [Test]
        public void SetContent_GivenEmptyString_ThrowsArgumentNullException()
        {
            //Arrange
            var test = CreateTest();

            //Act
            Action act = () => test.SetContent("");

            //Assert
            act.Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void SetContent_GivenString_ChangesContent()
        {
            //Arrange
            var test = CreateTest();

            //Act
            test.SetContent("Changed content");

            //Assert
            test.Content.Should().Be("Changed content");
        }
    }
}
