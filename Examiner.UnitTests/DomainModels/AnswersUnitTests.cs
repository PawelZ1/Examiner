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
    public class AnswersUnitTests
    {
        [Test]
        public void GetContent_ReturnsContent()
        {
            //Arrange
            string content = "Sample Content";
            Answer answer = new Answer(Guid.NewGuid(), content, Guid.NewGuid(), true, Guid.NewGuid().ToString());

            //Act
            var result = answer.GetContent();

            //Assert
            result.Should().Be(content);
        }

        [Test]
        public void GetApplicableFor_ReturnsApplicableFor()
        {
            //Arrange
            Guid applicableFor = Guid.NewGuid();
            Answer answer = new Answer(Guid.NewGuid(), "Sample Content", applicableFor, true, Guid.NewGuid().ToString());

            //Act
            var result = answer.GetApplicableFor();

            //Assert
            result.Should().Be(applicableFor);
        }

        [Test]
        public void SetContent_GivenEmptyString_ThrowsArgunemtNullException()
        {
            //Arrange
            Answer answer = new Answer(Guid.NewGuid(), "Sample Content", Guid.NewGuid(), true, Guid.NewGuid().ToString());

            //Act
            Action act = () => answer.SetContent("");

            //Assert
            act.Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void SetContent_GivenString_ChangesContent()
        {
            //Arrange
            string changedContent = "Changed content";
            Answer answer = new Answer(Guid.NewGuid(), "Sample Content", Guid.NewGuid(), true, Guid.NewGuid().ToString());

            //Act
            answer.SetContent(changedContent);

            //Assert
            answer.Content.Should().Be(changedContent);
        }

        [Test]
        public void SetIsCorrect_ChangesIsCorrect()
        {
            //Arrange
            bool isCorrectFalse = false;
            Answer answer = new Answer(Guid.NewGuid(), "Sample Content", Guid.NewGuid(), true, Guid.NewGuid().ToString());

            //Act
            answer.SetIsCorrect(isCorrectFalse);

            //Assert
            answer.IsCorrect.Should().Be(isCorrectFalse);
        }
    }
}
