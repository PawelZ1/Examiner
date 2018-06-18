using Examiner.Core.DomainModels;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examiner.UnitTests.DomainModels
{
    [TestFixture]
    public class TestVersionUnitTests
    {
        [Test]
        public void GetApplicableFor_ApplicableForSetInTestBase_returnsGuid()
        {
            //Arrange
            Guid guid = Guid.NewGuid();
            Test test = new Test(Guid.NewGuid(), "Sample Content", Guid.NewGuid().ToString(), guid);
            TestVersion testVersion = new TestVersion(Guid.NewGuid(), test, "Sample Name");

            //Act
            var result = testVersion.GetApplicableFor();

            //Assert
            result.Should().Be(guid);
        }


        [Test]
        public void GetApplicableFor_NoApplicableForSetInTestBase_ThrowsArgumentException()
        {
            //Arrange
            Test test = new Test(Guid.NewGuid(), "Sample Content", Guid.NewGuid().ToString());
            TestVersion testVersion = new TestVersion(Guid.NewGuid(), test, "Sample Name");

            //Act
            Action act = () => testVersion.GetApplicableFor();

            //Assert
            act.Should().Throw<ArgumentException>();
        }

        [Test]
        public void SetName_GivenEmptyString_ThrowsArgumentNullException()
        {
            //Arrange
            Test test = new Test(Guid.NewGuid(), "Sample Content", Guid.NewGuid().ToString());
            TestVersion testVersion = new TestVersion(Guid.NewGuid(), test, "Sample Name");

            //Act
            Action act = () => testVersion.SetName("");

            //Assert
            act.Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void SetName_GivenString_ChangesName()
        {
            //Arrange
            string name = "New Name";
            Test test = new Test(Guid.NewGuid(), "Sample Content", Guid.NewGuid().ToString());
            TestVersion testVersion = new TestVersion(Guid.NewGuid(), test, "Sample Name");

            //Act
            testVersion.SetName(name);

            //Assert
            testVersion.Name.Should().Be(name);
        }

        [Test]
        public void GetContent_ReturnsTestBaseContent()
        {
            //Arrange
            string content = "Sample content";
            Test test = new Test(Guid.NewGuid(), content, Guid.NewGuid().ToString());
            TestVersion testVersion = new TestVersion(Guid.NewGuid(), test, "Sample Name");

            //Act
            var result =  testVersion.GetContent();

            //Assert
            result.Should().Be(content);
        }

        [Test]
        public void Add_GivenAppropiateTestComponent_AddsItemToComponents()
        {
            //Arrange
            Guid applicableFor = new Guid("069EE06B-C821-4CD6-8C8D-88CED7A1AB07");
            Test test = new Test(applicableFor, "Sample Content", Guid.NewGuid().ToString());
            TestVersion testVersion = new TestVersion(Guid.NewGuid(), test, "Sample Name");

            Question question = new Question(Guid.NewGuid(), "SampleContent", Guid.NewGuid().ToString(), applicableFor);
            QuestionVersion questionVersion = new QuestionVersion(Guid.NewGuid(), question);

            //Act
            testVersion.Add(questionVersion);

            //Assert
            testVersion.Components.Should().Contain(questionVersion);
        }

        [Test]
        public void Add_GivenNotAppropiateTestComponent_ThrowsArgumentException()
        {
            //Arrange
            Guid applicableFor = new Guid("069EE06B-C821-4CD6-8C8D-88CED7A1AB07");
            Test test = new Test(applicableFor, "Sample Content", Guid.NewGuid().ToString());
            TestVersion testVersion = new TestVersion(Guid.NewGuid(), test, "Sample Name");

            Question question = new Question(Guid.NewGuid(), "SampleContent", Guid.NewGuid().ToString(), Guid.NewGuid());
            QuestionVersion questionVersion = new QuestionVersion(Guid.NewGuid(), question);

            //Act
            Action act = () => testVersion.Add(questionVersion);

            //Assert
            act.Should().Throw<ArgumentException>();
        }

        [Test]
        public void Remove_TestComponent_RemovesComponentFromComponents()
        {
            //Arrange
            Guid applicableFor = new Guid("069EE06B-C821-4CD6-8C8D-88CED7A1AB07");
            Test test = new Test(applicableFor, "Sample Content", Guid.NewGuid().ToString());
            TestVersion testVersion = new TestVersion(Guid.NewGuid(), test, "Sample Name");
            Question question = new Question(Guid.NewGuid(), "SampleContent", Guid.NewGuid().ToString(), applicableFor);
            QuestionVersion questionVersion = new QuestionVersion(Guid.NewGuid(), question);
            testVersion.Add(questionVersion);

            //Act
            testVersion.Remove(questionVersion);

            //Assert
            testVersion.Components.Should().NotContain(questionVersion);
        }
    }
}
