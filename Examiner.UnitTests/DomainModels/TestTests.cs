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
    public class TestTests
    {
        public Test CreateTest()
        {
            return new Test(Guid.NewGuid(), "SampleTest", "SampleCategory", "user1");
        }

        [Test]
        public void SetName_GivenEmptyString_ThrowsArgumentException()
        {
            Test test = CreateTest();

            Assert.Throws<ArgumentException>(() => test.SetName(""));
        }

        [Test]
        public void SetName_GivenString_ChangesName()
        {
            Test test = CreateTest();

            test.SetName("NewName");

            test.Name.Should().Be("NewName");
        }

        [Test]
        public void SetCategory_GivenEmptyString_ThrowsArgumentException()
        {
            Test test = CreateTest();

            Assert.Throws<ArgumentException>(() => test.SetCategory(""));
        }

        [Test]
        public void SetCategory_GivenString_ChangesCategory()
        {
            Test test = CreateTest();

            test.SetCategory("NewCategory");

            test.Category.Should().Be("NewCategory");
        }
    }
}
