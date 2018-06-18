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
    public class QuestionUnitTests
    {
        public Question CreateQuestion()
        {
            return new Question(Guid.NewGuid(), "Example Content", Guid.NewGuid().ToString(), Guid.NewGuid());
        }

        [Test]
        public void SetContent_GivenEmptyString_ThrowsArgumentNullException()
        {
            //Arrange
            var question = CreateQuestion();

            //Act
            Action act = () => question.SetContent("");

            //Assert
            act.Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void SetContent_GivenString_ChangesContent()
        {
            //Arrange
            var question = CreateQuestion();

            //Act
            question.SetContent("Changed content");

            //Assert
            question.Content.Should().Be("Changed content");
        }
    }
}
