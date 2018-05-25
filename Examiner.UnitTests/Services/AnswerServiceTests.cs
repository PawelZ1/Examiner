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
    public class AnswerServiceTests
    {
        //[Test]
        //public void AddAnswerAsync_GivenNullAnswerDTO_ThrowsArgumentNullException()
        //{
        //    //Arrange
        //    var repositoryMock = new Mock<IAnswerRepository>();
        //    var mapperMock = new Mock<IMapper>();

        //    AnswerService answerService = new AnswerService(repositoryMock.Object, mapperMock.Object);

        //    //Act
        //    Func<Task> act = async () => await answerService.AddAnswerAsync(null);

        //    //Assert
        //    act.Should().Throw<ArgumentNullException>();
        //}

        //[Test]
        //public async Task AddAnswerAsync_GivenAnswerDTO_InvokesRepositoryGetAsync()
        //{
        //    //Arrange
        //    var repositoryMock = new Mock<IAnswerRepository>();
        //    var mapperMock = new Mock<IMapper>();
        //    Guid answerGuid = Guid.NewGuid();
        //    AnswerDTO answerDTO = new AnswerDTO
        //    {
        //        AnswerId = answerGuid,
        //        AnswerContent = "Sample content",
        //        IsCorrect = false
        //    };

        //    AnswerService answerService = new AnswerService(repositoryMock.Object, mapperMock.Object);
        //    //Act
        //    await answerService.AddAnswerAsync(answerDTO);

        //    //Assert
        //    repositoryMock.Verify(p => p.GetAsync(answerGuid), Times.Once);
        //}

        //[Test]
        //public void AddAnswerAsync_GivenExistingAnswerDTO_ThrowsArgumentException()
        //{
        //    //Arrange
        //    var repositoryMock = new Mock<IAnswerRepository>();
        //    var mapperMock = new Mock<IMapper>();
        //    Guid answerGuid = Guid.NewGuid();
        //    AnswerDTO answerDTO = new AnswerDTO
        //    {
        //        AnswerId = answerGuid,
        //        AnswerContent = "Sample content",
        //        IsCorrect = false,
        //        QuestionId = new Guid()
        //    };
        //    Answer asnwer = new Answer(answerGuid, "Sample content", false, Guid.NewGuid());
        //    repositoryMock.Setup(p => p.GetAsync(It.IsAny<Guid>())).ReturnsAsync(asnwer);

        //    AnswerService answerService = new AnswerService(repositoryMock.Object, mapperMock.Object);

        //    //Act
        //    Func<Task> act = async () => await answerService.AddAnswerAsync(answerDTO);

        //    //Assert
        //    act.Should().Throw<ArgumentException>();
        //}

        //[Test]
        //public async Task AddAnswerAsync_GivenAnswerDTO_InvokesMapperMap()
        //{
        //    //Arrange
        //    var repositoryMock = new Mock<IAnswerRepository>();
        //    var mapperMock = new Mock<IMapper>();
        //    Guid answerGuid = Guid.NewGuid();
        //    AnswerDTO answerDTO = new AnswerDTO
        //    {
        //        AnswerId = answerGuid,
        //        AnswerContent = "Sample content",
        //        IsCorrect = false,
        //        QuestionId = new Guid()
        //    };
        //    Answer asnwer = new Answer(answerGuid, "Sample content", false, Guid.NewGuid());

        //    AnswerService answerService = new AnswerService(repositoryMock.Object, mapperMock.Object);

        //    //Act
        //    await answerService.AddAnswerAsync(answerDTO);
        //    //Assert
        //    mapperMock.Verify(p => p.Map<AnswerDTO, Answer>(answerDTO), Times.Once);
        //}

        //[Test]
        //public async Task AddAnswerAsync_GivenAnswerDTO_InvokesRepositoryAddAsync()
        //{
        //    //Arrange
        //    var repositoryMock = new Mock<IAnswerRepository>();
        //    var mapperMock = new Mock<IMapper>();
        //    Guid answerGuid = Guid.NewGuid();
        //    AnswerDTO answerDTO = new AnswerDTO
        //    {
        //        AnswerId = answerGuid,
        //        AnswerContent = "Sample content",
        //        IsCorrect = false,
        //        QuestionId = new Guid()
        //    };
        //    Answer asnwer = new Answer(answerGuid, "Sample content", false, Guid.NewGuid());
        //    mapperMock.Setup(p => p.Map<AnswerDTO, Answer>(It.IsAny<AnswerDTO>())).Returns(asnwer);

        //    AnswerService answerService = new AnswerService(repositoryMock.Object, mapperMock.Object);

        //    //Act
        //    await answerService.AddAnswerAsync(answerDTO);

        //    //Assert
        //    repositoryMock.Verify(p => p.AddAsync(asnwer), Times.Once);
        //}

        //[Test]
        //public async Task DeleteAnswerAsync_GivenGuid_InvokesRepositoryGetAsync()
        //{
        //    //Arrange
        //    var repositoryMock = new Mock<IAnswerRepository>();
        //    var mapperMock = new Mock<IMapper>();
        //    Guid answerGuid = Guid.NewGuid();
        //    Answer asnwer = new Answer(answerGuid, "Sample content", false, Guid.NewGuid());
        //    repositoryMock.Setup(p => p.GetAsync(It.IsAny<Guid>())).ReturnsAsync(asnwer);

        //    AnswerService answerService = new AnswerService(repositoryMock.Object, mapperMock.Object);

        //    //Act
        //    await answerService.DeleteAnswerAsync(answerGuid);

        //    //Assert
        //    repositoryMock.Verify(p => p.GetAsync(answerGuid), Times.Once);
        //}

        //[Test]
        //public void DeleteAnswerAsync_RepositoryReturnsNull_ThrowsArgumentException()
        //{
        //    //Arrange
        //    var repositoryMock = new Mock<IAnswerRepository>();
        //    var mapperMock = new Mock<IMapper>();
        //    Guid answerGuid = Guid.NewGuid();
        //    Answer asnwer = null;
        //    repositoryMock.Setup(p => p.GetAsync(It.IsAny<Guid>())).ReturnsAsync(asnwer);

        //    AnswerService answerService = new AnswerService(repositoryMock.Object, mapperMock.Object);

        //    //Act
        //    Func<Task> act = async () => await answerService.DeleteAnswerAsync(answerGuid);

        //    //Assert
        //    act.Should().Throw<ArgumentException>();
        //}

        //[Test]
        //public async Task DeleteAnswerAsync_AnswerExists_InvokesRepositoryDeleteAsync()
        //{
        //    //Arrange
        //    var repositoryMock = new Mock<IAnswerRepository>();
        //    var mapperMock = new Mock<IMapper>();
        //    Guid answerGuid = Guid.NewGuid();
        //    Answer asnwer = new Answer(answerGuid, "Sample content", false, Guid.NewGuid());
        //    repositoryMock.Setup(p => p.GetAsync(It.IsAny<Guid>())).ReturnsAsync(asnwer);

        //    AnswerService answerService = new AnswerService(repositoryMock.Object, mapperMock.Object);

        //    //Act
        //    await answerService.DeleteAnswerAsync(answerGuid);

        //    //Assert
        //    repositoryMock.Verify(p => p.DeleteAsync(asnwer), Times.Once);
        //}

        //[Test]
        //public async Task GetAnswerAsync_GivenGuid_InvokesRepositoryGetAsync()
        //{
        //    //Arrange
        //    var repositoryMock = new Mock<IAnswerRepository>();
        //    var mapperMock = new Mock<IMapper>();
        //    Guid answerGuid = Guid.NewGuid();

        //    AnswerService answerService = new AnswerService(repositoryMock.Object, mapperMock.Object);

        //    //Act
        //    await answerService.GetAnswerAsync(answerGuid);

        //    //Assert
        //    repositoryMock.Verify(p => p.GetAsync(answerGuid), Times.Once);
        //}

        //[Test]
        //public async Task GetAnswerAsync_GivenGuid_InvokesMapperMap()
        //{
        //    //Arrange
        //    var repositoryMock = new Mock<IAnswerRepository>();
        //    var mapperMock = new Mock<IMapper>();
        //    Guid answerGuid = Guid.NewGuid();
        //    AnswerDTO answerDTO = new AnswerDTO
        //    {
        //        AnswerId = answerGuid,
        //        AnswerContent = "Sample content",
        //        IsCorrect = false,
        //        QuestionId = new Guid()
        //    };
        //    Answer asnwer = new Answer(answerGuid, "Sample content", false, Guid.NewGuid());
        //    repositoryMock.Setup(p => p.GetAsync(It.IsAny<Guid>())).ReturnsAsync(asnwer);

        //    AnswerService answerService = new AnswerService(repositoryMock.Object, mapperMock.Object);

        //    //Act
        //    await answerService.GetAnswerAsync(answerGuid);

        //    //Assert
        //    mapperMock.Verify(p => p.Map<Answer, AnswerDTO>(asnwer), Times.Once);
        //}

        //[Test]
        //public async Task GetQuestionAnswersAsync_GivenGuid_InvokesRepositoryGetAsync()
        //{
        //    //Arrange
        //    var repositoryMock = new Mock<IAnswerRepository>();
        //    var mapperMock = new Mock<IMapper>();
        //    Guid questionGuid = Guid.NewGuid();

        //    AnswerService answerService = new AnswerService(repositoryMock.Object, mapperMock.Object);
        //    //Act
        //    await answerService.GetQuestionAnswersAsync(questionGuid);

        //    //Assert
        //    repositoryMock.Verify(p => p.GetAllForQuestion(questionGuid), Times.Once);
        //}

        //[Test]
        //public async Task GetQuestionAnswersAsync_GivenGuid_InvokesMapperMap()
        //{
        //    //Arrange
        //    var repositoryMock = new Mock<IAnswerRepository>();
        //    var mapperMock = new Mock<IMapper>();
        //    Guid questionGuid = Guid.NewGuid();
        //    IEnumerable<Answer> asnwers = new List<Answer>
        //    {
        //        new Answer(Guid.NewGuid(), "Sample content", false, questionGuid),
        //        new Answer(Guid.NewGuid(), "Sample content", false, questionGuid),
        //        new Answer(Guid.NewGuid(), "Sample content", false, questionGuid)
        //    };
        //    repositoryMock.Setup(p => p.GetAllForQuestion(It.IsAny<Guid>())).ReturnsAsync(asnwers);

        //    AnswerService answerService = new AnswerService(repositoryMock.Object, mapperMock.Object);
        //    //Act
        //    await answerService.GetQuestionAnswersAsync(questionGuid);

        //    //Assert
        //    mapperMock.Verify(p => p.Map<IEnumerable<Answer>, IEnumerable<AnswerDTO>>(asnwers), Times.Once);
        //}
    }
}
