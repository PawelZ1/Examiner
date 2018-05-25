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
    public class AnswerTests
    {
        public Answer CreateAnswer()
        {
            return new Answer(Guid.NewGuid(), "Sample Content",true, Guid.NewGuid());
        }

        [Test]
        public void SetAnswerContent_GivenEmptyString_ThrowsArgumentNullException()
        {
            //Arrange
            Answer answer = CreateAnswer();

            //Act
            Action act = () => answer.SetAnswerContent(null);

            //Assert
            act.Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void SetAnswerContent_GivenString_ChangesAnswerContent()
        {
            //Arrange
            Answer answer = CreateAnswer();

            //Act
            answer.SetAnswerContent("New sample content");

            //Assert
            answer.AnswerContent.Should().Be("New sample content");
        }

        [Test]
        public void SetIsCorrect_GivenBool_ChangesIsCorrect()
        {
            //Arrange
            Answer answer = CreateAnswer();

            //Act
            answer.SetIsCorrect(false);

            //Assert
            answer.IsCorrect.Should().Be(false);
        }
    }
}
