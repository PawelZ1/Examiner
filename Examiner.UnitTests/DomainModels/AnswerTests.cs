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
            return new Answer(Guid.NewGuid(), "Sample Content", true, Guid.NewGuid());
        }

        [Test]
        public void SetAnswerContent_GivenEmptyString_ThrowsArgumentException()
        {
            Answer answer = CreateAnswer();

            Assert.Throws<ArgumentException>(() => answer.SetAnswerContent(""));
        }

        [Test]
        public void SetAnswerContent_GivenString_ChangesAnswerContent()
        {
            Answer answer = CreateAnswer();

            answer.SetAnswerContent("New sample content");

            answer.AnswerContent.Should().Be("New sample content");
        }

        [Test]
        public void SetIsCorrect_GivenBool_ChangesIsCorrect()
        {
            Answer answer = CreateAnswer();

            answer.SetIsCorrect(false);

            answer.IsCorrect.Should().Be(false);
        }
    }
}
