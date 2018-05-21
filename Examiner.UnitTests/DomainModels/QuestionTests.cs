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
            return new Question(Guid.NewGuid(), "Sample Content", "user1");
        }

        [Test]
        public void SetQuestionContent_GivenEmptyString_ThrowsArgumentException()
        {
            Question question = CreateQuestion();

            Assert.Throws<ArgumentException>(() => question.SetQuestionContent(""));
        }

        [Test]
        public void SetQuestionContent_GivenString_ChangesQuestionContent()
        {
            Question question = CreateQuestion();

            question.SetQuestionContent("Question Content Changed");

            question.QuestionContent.Should().Be("Question Content Changed");
        }

        [Test]
        public void SetTestId_GivenGuid_ChangesTestId()
        {
            Guid newTestId = Guid.NewGuid();
            Question question = CreateQuestion();

            question.SetTestId(newTestId);

            question.TestId.Should().Be(newTestId);
        }
    }
}
