using AutoMapper;
using Examiner.Core.DomainModels;
using Examiner.Core.DTOs;
using Examiner.Core.Interfaces;
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
        public void  AddQuestionAsync_GivenNull_ThrowsArgumentNullException()
        {
            //Arrange
            var repositoryMock = new Mock<IQuestionRepository>();
            var mapperMock = new Mock<IMapper>();

            var questionService = new QuestionService(repositoryMock.Object, mapperMock.Object);

            //Act
            Func<Task> act = async () => await questionService.AddQuestionAsync(null);

            //Assert
            act.Should().Throw<ArgumentNullException>();
        }

        [Test]
        public async Task AddQuestionAsync_GivenQuestionDTO_InvokesRepositoryGetAsync()
        {
            //Arrange
            var repositoryMock = new Mock<IQuestionRepository>();
            var mapperMock = new Mock<IMapper>();
            Guid questionGuid = new Guid();
            QuestionDTO questionDTO = new QuestionDTO
            {
                QuestionId = questionGuid,
                QuestionContent = "Sample content",
                TestId = new Guid(),
                UserId = "1111"
            };

            var questionService = new QuestionService(repositoryMock.Object, mapperMock.Object);
            //Act
            await questionService.AddQuestionAsync(questionDTO);

            //Assert
            repositoryMock.Verify(p => p.GetAsync(questionDTO.QuestionId));
        }

        [Test]
        public void AddQuestionAsync_GivenExistingQuestion_ThrowsArgumentException()
        {
            //Arrange
            var repositoryMock = new Mock<IQuestionRepository>();
            var mapperMock = new Mock<IMapper>();
            Guid questionGuid = new Guid();
            QuestionDTO questionDTO = new QuestionDTO
            {
                QuestionId = questionGuid,
                QuestionContent = "Sample content",
                TestId = new Guid(),
                UserId = "1111"
            };
            Question question = new Question(questionGuid, "Sample Content", "1111");
            repositoryMock.Setup(p => p.GetAsync(questionGuid)).ReturnsAsync(question);

            var questionService = new QuestionService(repositoryMock.Object, mapperMock.Object);

            //Act
            Func<Task> act = async () => await questionService.AddQuestionAsync(questionDTO);

            //Assert
            act.Should().Throw<ArgumentException>();
        }

        [Test]
        public async Task AddQuestionAsync_GivenQuestionDTO_InvokesMapperMap()
        {
            //Arrange
            var repositoryMock = new Mock<IQuestionRepository>();
            var mapperMock = new Mock<IMapper>();
            Guid questionGuid = new Guid();
            QuestionDTO questionDTO = new QuestionDTO
            {
                QuestionId = questionGuid,
                QuestionContent = "Sample content",
                TestId = new Guid(),
                UserId = "1111"
            };
            Question question = new Question(questionGuid, "Sample Content", "1111");

            var questionService = new QuestionService(repositoryMock.Object, mapperMock.Object);

            //Act
            await questionService.AddQuestionAsync(questionDTO);

            //Assert
            mapperMock.Verify(p => p.Map<QuestionDTO, Question>(questionDTO), Times.Once);
        }

        [Test]
        public async Task AddQuestionAsync_GivenQuestionDTO_InvokesRepositoryAddAsync()
        {
            //Arrange
            var repositoryMock = new Mock<IQuestionRepository>();
            var mapperMock = new Mock<IMapper>();
            Guid questionGuid = new Guid();
            QuestionDTO questionDTO = new QuestionDTO
            {
                QuestionId = questionGuid,
                QuestionContent = "Sample content",
                TestId = new Guid(),
                UserId = "1111"
            };
            Question question = new Question(questionGuid, "Sample Content", "1111");
            mapperMock.Setup(p => p.Map<QuestionDTO, Question>(questionDTO)).Returns(question);

            var questionService = new QuestionService(repositoryMock.Object, mapperMock.Object);

            //Act
            await questionService.AddQuestionAsync(questionDTO);

            //Assert
            repositoryMock.Verify(p => p.AddAsync(question), Times.Once);
        }

        [Test]
        public async Task DeleteQuestionAsync_GivenGuid_InvokesRepositoryGetAsync()
        {
            //Arrange
            var repositoryMock = new Mock<IQuestionRepository>();
            var mapperMock = new Mock<IMapper>();
            Guid questionGuid = new Guid("f0d2b8c4-9b33-49f2-8b99-c4a8b5366db2");
            Question question = new Question(questionGuid, "Sample Content", "1111");
            repositoryMock.Setup(p => p.GetAsync(It.IsAny<Guid>())).ReturnsAsync(question);

            var questionService = new QuestionService(repositoryMock.Object, mapperMock.Object);

            //Act
            await questionService.DeleteQuestionAsync(questionGuid);

            //Assert
            repositoryMock.Verify(p => p.GetAsync(questionGuid), Times.Once);
        }

        [Test]
        public void DeleteQuestionAsync_GivenNotExistingQuestionGuid_ThrowsArgumentException()
        {
            //Arrange
            var repositoryMock = new Mock<IQuestionRepository>();
            var mapperMock = new Mock<IMapper>();
            Question question = null;
            repositoryMock.Setup(p => p.GetAsync(It.IsAny<Guid>())).ReturnsAsync(question);

            var questionService = new QuestionService(repositoryMock.Object, mapperMock.Object);

            //Act
            Func<Task> act = async () => await questionService.DeleteQuestionAsync(new Guid("f0d2b8c4-9b33-49f2-8b99-c4a8b5366db2"));

            //Assert
            act.Should().Throw<ArgumentException>();
        }

        [Test]
        public async Task DeleteQuestionAsync_GivenExistingQuestionGuid_InvokesRepositoryDeleteAsync()
        {
            //Arrange
            var repositoryMock = new Mock<IQuestionRepository>();
            var mapperMock = new Mock<IMapper>();
            Guid questionGuid = new Guid();
            Question question = new Question(questionGuid, "Sample Content", "1111");
            repositoryMock.Setup(p => p.GetAsync(It.IsAny<Guid>())).ReturnsAsync(question);

            var questionService = new QuestionService(repositoryMock.Object, mapperMock.Object);

            //Act
            await questionService.DeleteQuestionAsync(questionGuid);

            //Assert
            repositoryMock.Verify(p => p.DeleteAsync(question), Times.Once);
        }

        [Test]
        public async Task GetQuestionAsync_GivenGuid_InvokesRepositoryGetAsync()
        {
            //Arrange
            var repositoryMock = new Mock<IQuestionRepository>();
            var mapperMock = new Mock<IMapper>();
            Guid questionGuid = new Guid();

            var questionService = new QuestionService(repositoryMock.Object, mapperMock.Object);

            //Act
            await questionService.GetQuestionAsync(questionGuid);

            //Assert
            repositoryMock.Verify(p => p.GetAsync(questionGuid), Times.Once);
        }

        [Test]
        public async Task GetQuestionAsync_GivenGuid_InvokesMapperMap()
        {
            //Arrange
            var repositoryMock = new Mock<IQuestionRepository>();
            var mapperMock = new Mock<IMapper>();
            Guid questionGuid = new Guid();
            Question question = new Question(questionGuid, "Sample Content", "1111");
            repositoryMock.Setup(p => p.GetAsync(It.IsAny<Guid>())).ReturnsAsync(question);

            var questionService = new QuestionService(repositoryMock.Object, mapperMock.Object);
            //Act
            await questionService.GetQuestionAsync(questionGuid);

            //Assert
            mapperMock.Verify(p => p.Map<Question, QuestionDTO>(question), Times.Once);
        }

        [Test]
        public void GetUserQuestionsAsync_GivenNullString_ThrowsArgumentNullException()
        {
            //Arrange
            var repositoryMock = new Mock<IQuestionRepository>();
            var mapperMock = new Mock<IMapper>();

            var questionService = new QuestionService(repositoryMock.Object, mapperMock.Object);

            //Act
            Func<Task> act = async () => await questionService.GetUserQuestionsAsync(null);

            //Assert
            act.Should().Throw<ArgumentNullException>();
        }

        [Test]
        public async Task GetUserQuestionsAsync_GivenString_InvokesRepositoryGetAllForUserAsync()
        {
            //Arrange
            var repositoryMock = new Mock<IQuestionRepository>();
            var mapperMock = new Mock<IMapper>();
            string userId = "1111";

            var questionService = new QuestionService(repositoryMock.Object, mapperMock.Object);
            //Act
            await questionService.GetUserQuestionsAsync(userId);

            //Assert
            repositoryMock.Verify(p => p.GetAllForUserAsync(userId), Times.Once);
        }

        [Test]
        public async Task GetUserQuestionsAsync_GivenString_InvokesMapperMap()
        {
            //Arrange
            var repositoryMock = new Mock<IQuestionRepository>();
            var mapperMock = new Mock<IMapper>();
            string userId = "1111";
            IEnumerable<Question> questions = new List<Question>
            {
                new Question(new Guid(), "Sample Content", "1111"),
                new Question(new Guid(), "Sample Content", "1111"),
            };
            repositoryMock.Setup(p => p.GetAllForUserAsync(It.IsAny<string>())).ReturnsAsync(questions);

            var questionService = new QuestionService(repositoryMock.Object, mapperMock.Object);
            //Act
            await questionService.GetUserQuestionsAsync(userId);

            //Assert
            mapperMock.Verify(p => p.Map<IEnumerable<Question>, IEnumerable<QuestionDTO>>(questions), Times.Once);
        }
    }
}
