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
    public class QuestionBasesUnitTests
    {
        public QuestionBase CreateQuestionBase()
        {
            return new QuestionBase(Guid.NewGuid(), "Example Content", Guid.NewGuid());
        }

        [Test]
        public void SetContent_GivenEmptyString_ThrowsArgumentNullException()
        {
            //Arrange
            var questionBase = CreateQuestionBase();

            //Act
            Action act = () => questionBase.SetContent("");

            //Assert
            act.Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void SetContent_GivenString_ChangesContent()
        {
            //Arrange
            var questionBase = CreateQuestionBase();

            //Act
            questionBase.SetContent("Changed content");

            //Assert
            questionBase.Content.Should().Be("Changed content");
        }
    }
}
