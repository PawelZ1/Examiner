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
    public class QuestionsUnitTests
    {
        [Test]
        public void GetApplicableFor_returnsQuestionBaseGuid()
        {
            //Arrange
            Guid guid = Guid.NewGuid();
            QuestionBase questionBase = new QuestionBase(Guid.NewGuid(), "Sample Content", guid);
            Question question = new Question(Guid.NewGuid(), questionBase, Guid.NewGuid().ToString());

            //Act
            var result = question.GetApplicableFor();

            //Assert
            result.Should().Be(guid);
        }

        [Test]
        public void GetContent_ReturnsQuestionBaseContent()
        {
            //Arrange
            string content = "Sample content";
            QuestionBase questionBase = new QuestionBase(Guid.NewGuid(), content, Guid.NewGuid());
            Question question = new Question(Guid.NewGuid(), questionBase, Guid.NewGuid().ToString());

            //Act
            var result = question.GetContent();

            //Assert
            result.Should().Be(content);
        }

        [Test]
        public void Add_GivenAppropiateTestComponent_AddsItemToComponents()
        {
            //Arrange
            Guid applicableFor = new Guid("069EE06B-C821-4CD6-8C8D-88CED7A1AB07");
            QuestionBase questionBase = new QuestionBase(applicableFor, "Sample Content", Guid.NewGuid());
            Question question = new Question(Guid.NewGuid(), questionBase, Guid.NewGuid().ToString());

            Answer answer = new Answer(Guid.NewGuid(), "Sample Content", applicableFor, true, Guid.NewGuid().ToString());

            //Act
            question.Add(answer);

            //Assert
            question.Components.Should().Contain(answer);
        }

        [Test]
        public void Add_GivenNotAppropiateTestComponent_ThrowsArgumentException()
        {
            //Arrange
            Guid applicableFor = new Guid("069EE06B-C821-4CD6-8C8D-88CED7A1AB07");
            QuestionBase questionBase = new QuestionBase(applicableFor, "Sample Content", Guid.NewGuid());
            Question question = new Question(Guid.NewGuid(), questionBase, Guid.NewGuid().ToString());

            Answer answer = new Answer(Guid.NewGuid(), "Sample Content", Guid.NewGuid(), true, Guid.NewGuid().ToString());

            //Act
            Action act = () => question.Add(answer);

            //Assert
            act.Should().Throw<ArgumentException>();
        }

        [Test]
        public void Remove_TestComponent_RemovesComponentFromComponents()
        {
            //Arrange
            Guid applicableFor = new Guid("069EE06B-C821-4CD6-8C8D-88CED7A1AB07");
            QuestionBase questionBase = new QuestionBase(applicableFor, "Sample Content", Guid.NewGuid());
            Question question = new Question(Guid.NewGuid(), questionBase, Guid.NewGuid().ToString());
            Answer answer = new Answer(Guid.NewGuid(), "Sample Content", applicableFor, true, Guid.NewGuid().ToString());
            question.Add(answer);

            //Act
            question.Remove(answer);

            //Assert
            question.Components.Should().NotContain(answer);
        }
    }
}
