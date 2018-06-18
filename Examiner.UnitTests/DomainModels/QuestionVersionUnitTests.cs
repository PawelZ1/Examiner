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
    public class QuestionVersionUnitTests
    {
        [Test]
        public void GetApplicableFor_returnsQuestionBaseGuid()
        {
            //Arrange
            Guid guid = Guid.NewGuid();
            Question question = new Question(Guid.NewGuid(), "Sample Content", Guid.NewGuid().ToString(), guid);
            QuestionVersion questionVersion = new QuestionVersion(Guid.NewGuid(), question);

            //Act
            var result = questionVersion.GetApplicableFor();

            //Assert
            result.Should().Be(guid);
        }

        [Test]
        public void GetContent_ReturnsQuestionBaseContent()
        {
            //Arrange
            string content = "Sample content";
            Question question = new Question(Guid.NewGuid(), content, Guid.NewGuid().ToString(), Guid.NewGuid());
            QuestionVersion questionVersion = new QuestionVersion(Guid.NewGuid(), question);

            //Act
            var result = questionVersion.GetContent();

            //Assert
            result.Should().Be(content);
        }

        [Test]
        public void Add_GivenAppropiateTestComponent_AddsItemToComponents()
        {
            //Arrange
            Guid applicableFor = new Guid("069EE06B-C821-4CD6-8C8D-88CED7A1AB07");
            Question question = new Question(applicableFor, "Sample Content", Guid.NewGuid().ToString(), Guid.NewGuid());
            QuestionVersion questionVersion = new QuestionVersion(Guid.NewGuid(), question);

            Answer answer = new Answer(Guid.NewGuid(), "Sample Content", applicableFor, true, Guid.NewGuid().ToString());

            //Act
            questionVersion.Add(answer);

            //Assert
            questionVersion.Components.Should().Contain(answer);
        }

        [Test]
        public void Add_GivenNotAppropiateTestComponent_ThrowsArgumentException()
        {
            //Arrange
            Guid applicableFor = new Guid("069EE06B-C821-4CD6-8C8D-88CED7A1AB07");
            Question question = new Question(applicableFor, "Sample Content", Guid.NewGuid().ToString(), Guid.NewGuid());
            QuestionVersion questionVersion = new QuestionVersion(Guid.NewGuid(), question);

            Answer answer = new Answer(Guid.NewGuid(), "Sample Content", Guid.NewGuid(), true, Guid.NewGuid().ToString());

            //Act
            Action act = () => questionVersion.Add(answer);

            //Assert
            act.Should().Throw<ArgumentException>();
        }

        [Test]
        public void Remove_TestComponent_RemovesComponentFromComponents()
        {
            //Arrange
            Guid applicableFor = new Guid("069EE06B-C821-4CD6-8C8D-88CED7A1AB07");
            Question question = new Question(applicableFor, "Sample Content", Guid.NewGuid().ToString(), Guid.NewGuid());
            QuestionVersion questionVersion = new QuestionVersion(Guid.NewGuid(), question);
            Answer answer = new Answer(Guid.NewGuid(), "Sample Content", applicableFor, true, Guid.NewGuid().ToString());
            questionVersion.Add(answer);

            //Act
            questionVersion.Remove(answer);

            //Assert
            questionVersion.Components.Should().NotContain(answer);
        }
    }
}
