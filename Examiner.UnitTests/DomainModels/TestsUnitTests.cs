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
    public class TestsUnitTests
    {
        [Test]
        public void GetApplicableFor_ApplicableForSetInTestBase_returnsGuid()
        {
            //Arrange
            Guid guid = Guid.NewGuid();
            TestBase testBase = new TestBase(Guid.NewGuid(), "Sample Content", guid);
            Test test = new Test(Guid.NewGuid(), testBase, "Sample Name", Guid.NewGuid().ToString());

            //Act
            var result = test.GetApplicableFor();

            //Assert
            result.Should().Be(guid);
        }


        [Test]
        public void GetApplicableFor_NoApplicableForSetInTestBase_ThrowsArgumentException()
        {
            //Arrange
            TestBase testBase = new TestBase(Guid.NewGuid(), "Sample Content");
            Test test = new Test(Guid.NewGuid(), testBase, "Sample Name", Guid.NewGuid().ToString());

            //Act
            Action act = () => test.GetApplicableFor();

            //Assert
            act.Should().Throw<ArgumentException>();
        }

        [Test]
        public void SetName_GivenEmptyString_ThrowsArgumentNullException()
        {
            //Arrange
            TestBase testBase = new TestBase(Guid.NewGuid(), "Sample Content");
            Test test = new Test(Guid.NewGuid(), testBase, "Sample Name", Guid.NewGuid().ToString());

            //Act
            Action act = () => test.SetName("");

            //Assert
            act.Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void SetName_GivenString_ChangesName()
        {
            //Arrange
            string name = "New Name";
            TestBase testBase = new TestBase(Guid.NewGuid(), "Sample Content");
            Test test = new Test(Guid.NewGuid(), testBase, "Sample Name", Guid.NewGuid().ToString());

            //Act
            test.SetName(name);

            //Assert
            test.Name.Should().Be(name);
        }

        [Test]
        public void GetContent_ReturnsTestBaseContent()
        {
            //Arrange
            string content = "Sample content";
            TestBase testBase = new TestBase(Guid.NewGuid(), content);
            Test test = new Test(Guid.NewGuid(), testBase, "Sample Name", Guid.NewGuid().ToString());

            //Act
            var result =  test.GetContent();

            //Assert
            result.Should().Be(content);
        }

        [Test]
        public void Add_GivenAppropiateTestComponent_AddsItemToComponents()
        {
            //Arrange
            Guid applicableFor = new Guid("069EE06B-C821-4CD6-8C8D-88CED7A1AB07");
            TestBase testBase = new TestBase(applicableFor, "Sample Content");
            Test test = new Test(Guid.NewGuid(), testBase, "Sample Name", Guid.NewGuid().ToString());

            QuestionBase questionBase = new QuestionBase(Guid.NewGuid(), "SampleContent", applicableFor);
            Question question = new Question(Guid.NewGuid(), questionBase, Guid.NewGuid().ToString());

            //Act
            test.Add(question);

            //Assert
            test.Components.Should().Contain(question);
        }

        [Test]
        public void Add_GivenNotAppropiateTestComponent_ThrowsArgumentException()
        {
            //Arrange
            Guid applicableFor = new Guid("069EE06B-C821-4CD6-8C8D-88CED7A1AB07");
            TestBase testBase = new TestBase(applicableFor, "Sample Content");
            Test test = new Test(Guid.NewGuid(), testBase, "Sample Name", Guid.NewGuid().ToString());

            QuestionBase questionBase = new QuestionBase(Guid.NewGuid(), "SampleContent", Guid.NewGuid());
            Question question = new Question(Guid.NewGuid(), questionBase, Guid.NewGuid().ToString());

            //Act
            Action act = () => test.Add(question);

            //Assert
            act.Should().Throw<ArgumentException>();
        }

        [Test]
        public void Remove_TestComponent_RemovesComponentFromComponents()
        {
            //Arrange
            Guid applicableFor = new Guid("069EE06B-C821-4CD6-8C8D-88CED7A1AB07");
            TestBase testBase = new TestBase(applicableFor, "Sample Content");
            Test test = new Test(Guid.NewGuid(), testBase, "Sample Name", Guid.NewGuid().ToString());
            QuestionBase questionBase = new QuestionBase(Guid.NewGuid(), "SampleContent", applicableFor);
            Question question = new Question(Guid.NewGuid(), questionBase, Guid.NewGuid().ToString());
            test.Add(question);

            //Act
            test.Remove(question);

            //Assert
            test.Components.Should().NotContain(question);
        }
    }
}
