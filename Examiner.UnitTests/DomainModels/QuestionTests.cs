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
    public class QuestionTests
    {
        public Question CreateQuestion()
        {
            return new Question(Guid.NewGuid(), "Sample Content", Guid.NewGuid());
        }

        [Test]
        public void SetQuestionContent_GivenEmptyString_ThrowsArgumentNullException()
        {
            //Arrange
            Question question = CreateQuestion();

            //Act
            Action act = () => question.SetQuestionContent(null);

            //Assert
            act.Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void SetQuestionContent_GivenString_ChangesQuestionContent()
        {
            //Arange
            Question question = CreateQuestion();

            //Act
            question.SetQuestionContent("Question Content Changed");

            //Assert
            question.QuestionContent.Should().Be("Question Content Changed");
        }
    }
}
