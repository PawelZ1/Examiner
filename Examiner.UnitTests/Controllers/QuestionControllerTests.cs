using AutoMapper;
using Examiner.Core.DTOs;
using Examiner.Core.Interfaces.Services;
using Examiner.MvcClient.Controllers;
using Examiner.MvcClient.Models;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Examiner.UnitTests.Controllers
{
    [TestFixture]
    public class QuestionControllerTests
    {
        [Test]
        public async Task GetQuestionDetails_GivenGuid_InvokesServiceGetQuestion()
        {
            //Arrange
            var serviceMock = new Mock<IQuestionService>();
            QuestionDTO question = new QuestionDTO
            {
                UserId = Guid.NewGuid().ToString()
            };
            serviceMock.Setup(p => p.GetQuestion(It.IsAny<Guid>())).ReturnsAsync(question);
            var mapperMock = new Mock<IMapper>();
            Guid guid = Guid.NewGuid();

            QuestionController controller = new QuestionController(serviceMock.Object, mapperMock.Object)
            {
                GetUserId = () => Guid.NewGuid().ToString()
            };

            //Act
            await controller.GetQuestionDetails(guid);

            //Assert
            serviceMock.Verify(p => p.GetQuestion(guid), Times.Once);
        }

        [Test]
        public async Task GetQuestionDetails_GivenNotUserQuestionGuid_ReturnsHttpStatusCodeForbidden()
        {
            //Arrange
            var serviceMock = new Mock<IQuestionService>();
            string userId = Guid.NewGuid().ToString();
            QuestionDTO question = new QuestionDTO
            {
                UserId = Guid.NewGuid().ToString()
        };
            serviceMock.Setup(p => p.GetQuestion(It.IsAny<Guid>())).ReturnsAsync(question);
            var mapperMock = new Mock<IMapper>();

            QuestionController controller = new QuestionController(serviceMock.Object, mapperMock.Object)
            {
                GetUserId = () => userId
            };


            //Act
            var result = (HttpStatusCodeResult) await controller.GetQuestionDetails(Guid.NewGuid());

            //Assert
            result.StatusCode.Should().Be(401);
        }

        [Test]
        public async Task GetQuestionDetails_GivenUserQuestionGuid_InvokesMapperMap()
        {
            //Arrange
            string userId = Guid.NewGuid().ToString();
            var serviceMock = new Mock<IQuestionService>();
            QuestionDTO question = new QuestionDTO
            {
                UserId = userId
            };
            serviceMock.Setup(p => p.GetQuestion(It.IsAny<Guid>())).ReturnsAsync(question);
            var mapperMock = new Mock<IMapper>();

            QuestionController controller = new QuestionController(serviceMock.Object, mapperMock.Object)
            {
                GetUserId = () => userId
            };

            //Act
            await controller.GetQuestionDetails(Guid.NewGuid());

            //Assert
            mapperMock.Verify(p => p.Map<QuestionDTO, QuestionViewModel>(question), Times.Once);
        }

        [Test]
        public async Task GetQuestionDetails_GivenUserQuestionGuid_ReturnsView()
        {
            //Arrange
            string userId = Guid.NewGuid().ToString();
            var serviceMock = new Mock<IQuestionService>();
            QuestionDTO question = new QuestionDTO
            {
                UserId = userId
            };
            serviceMock.Setup(p => p.GetQuestion(It.IsAny<Guid>())).ReturnsAsync(question);
            var mapperMock = new Mock<IMapper>();

            QuestionController controller = new QuestionController(serviceMock.Object, mapperMock.Object)
            {
                GetUserId = () => userId
            };

            //Act
            var result = (ViewResult) await controller.GetQuestionDetails(Guid.NewGuid());

            //Assert
            result.ViewName.Should().Be("");
        }
    }
}
