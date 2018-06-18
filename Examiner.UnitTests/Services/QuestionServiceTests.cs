using AutoMapper;
using Examiner.Core.DomainModels;
using Examiner.Core.DTOs;
using Examiner.Core.Interfaces.Repositories;
using Examiner.Core.Services;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examiner.UnitTests.Services
{
    [TestFixture]
    public class QuestionServiceTests
    {
        [Test]
        public async Task GetQuestion_GivenGuid_InvokesRepositoryGetAsync()
        {
            //Arrange
            var repositoryMock = new Mock<IQuestionRepository>();
            var mapperMock = new Mock<IMapper>();
            Guid guid = Guid.NewGuid();

            QuestionService service = new QuestionService(repositoryMock.Object, mapperMock.Object);

            //Act
            QuestionDTO question = await service.GetQuestion(guid);

            //Assert
            repositoryMock.Verify(p => p.GetAsync(guid), Times.Once);
        }

        [Test]
        public async Task GetQuestion_GivenGuid_InvokesMapperMap()
        {
            //Arrange
            var repositoryMock = new Mock<IQuestionRepository>();
            Question question = new Question(Guid.NewGuid(), "Sample content", Guid.NewGuid().ToString(), Guid.NewGuid());
            repositoryMock.Setup(p => p.GetAsync(It.IsAny<Guid>())).ReturnsAsync(question);
            var mapperMock = new Mock<IMapper>();

            QuestionService service = new QuestionService(repositoryMock.Object, mapperMock.Object);

            //Act
            QuestionDTO requestedQuestion = await service.GetQuestion(Guid.NewGuid());

            //Assert
            mapperMock.Verify(p => p.Map<Question, QuestionDTO>(question), Times.Once);
        }

        [TestCase("")]
        [TestCase(null)]
        public void GetUserQuestions_GivenEmptyOrNullString_ThrowsArgumentNullException(string id)
        {
            //Arrange
            var repositoryMock = new Mock<IQuestionRepository>();
            var mapperMockMock = new Mock<IMapper>();

            QuestionService service = new QuestionService(repositoryMock.Object, mapperMockMock.Object);

            //Act
            Func<Task> act = async () => await service.GetUserQuestions(id);

            //Assert
            act.Should().Throw<ArgumentNullException>();
        }

        [Test]
        public async Task GetUserQuestions_GivenString_InvokesRepositoryGetAllForUserAsync()
        {
            //Arrange
            var repositoryMock = new Mock<IQuestionRepository>();
            var mapperMockMock = new Mock<IMapper>();
            string userId = Guid.NewGuid().ToString();

            QuestionService service = new QuestionService(repositoryMock.Object, mapperMockMock.Object);

            //Act
            await service.GetUserQuestions(userId);

            //Assert
            repositoryMock.Verify(p => p.GetAllForUserAsync(userId), Times.Once);
        }

        [Test]
        public async Task GetUserQuestions_GivenString_InvokesMapperMap()
        {
            //Arrange
            var repositoryMock = new Mock<IQuestionRepository>();
            var mapperMock = new Mock<IMapper>();
            IEnumerable<Question> questions = new List<Question>
            {
                new Question(Guid.NewGuid(), "Sample content", Guid.NewGuid().ToString(), Guid.NewGuid()),
                new Question(Guid.NewGuid(), "Sample content", Guid.NewGuid().ToString(), Guid.NewGuid()),
                new Question(Guid.NewGuid(), "Sample content", Guid.NewGuid().ToString(), Guid.NewGuid()),
                new Question(Guid.NewGuid(), "Sample content", Guid.NewGuid().ToString(), Guid.NewGuid())
            };
            repositoryMock.Setup(p => p.GetAllForUserAsync(It.IsAny<string>())).ReturnsAsync(questions);

            QuestionService service = new QuestionService(repositoryMock.Object, mapperMock.Object);

            //Act
            await service.GetUserQuestions(Guid.NewGuid().ToString());

            //Assert
            mapperMock.Verify(p => p.Map<IEnumerable<Question>, IEnumerable<QuestionDTO>>(questions), Times.Once);
        }
    }
}
