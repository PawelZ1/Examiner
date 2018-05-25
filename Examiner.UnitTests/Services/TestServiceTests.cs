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
    public class TestServiceTests
    {
        //#region AddTestAsync
        //[Test]
        //public void AddTestAsync_GivenNull_ThrowsException()
        //{
        //    //Arrange
        //    var repositoryMock = new Mock<ITestRepository>();
        //    var mapperMock = new Mock<IMapper>();
        //    var service = new TestService(repositoryMock.Object, mapperMock.Object);

        //    //Act
        //    Func<Task> act = async () => await service.AddTestAsync(null);

        //    //Assert
        //    act.Should().Throw<ArgumentNullException>();
        //}

        //[Test]
        //public void AddTestAsync_GivenExistingTest_ThrowsException()
        //{
        //    //Arrange
        //    Guid sampleGuid = Guid.NewGuid();
        //    Test expectedTest = new Test(sampleGuid, "Expected test", "Sample category", "1111");
        //    var repositoryMock = new Mock<ITestRepository>();
        //    repositoryMock.Setup(p => p.GetAsync(expectedTest.TestId)).ReturnsAsync(expectedTest);

        //    var mapperMock = new Mock<IMapper>();
        //    TestDTO addedTestDTO = new TestDTO
        //    {
        //        TestId = sampleGuid,
        //        Name = "Expected test",
        //        Category = "Sample category",
        //        UserId = "1111"
        //    };

        //    var service = new TestService(repositoryMock.Object, mapperMock.Object);

        //    //Act
        //    Func<Task> act = async () => await service.AddTestAsync(addedTestDTO);

        //    //Assert
        //    act.Should().Throw<ArgumentException>();
        //}

        //[Test]
        //public async Task AddTestAsync_GivenTestDTO_InvokesMapperMap()
        //{
        //    //Arrange
        //    var repositoryMock = new Mock<ITestRepository>();

        //    var mapperMock = new Mock<IMapper>();
        //    TestDTO TestDTO = new TestDTO
        //    {
        //        TestId = Guid.NewGuid(),
        //        Name = "Expected test",
        //        Category = "Sample category",
        //        UserId = "1111"
        //    };

        //    var testService = new TestService(repositoryMock.Object, mapperMock.Object);

        //    //Act
        //    await testService.AddTestAsync(TestDTO);

        //    //Assert
        //    mapperMock.Verify(p => p.Map<TestDTO, Test>(TestDTO), Times.Once);
        //}

        //[Test]
        //public async Task AddTestAsync_GivenTestDTO_InvokesRepositoryAddAsync()
        //{
        //    //Arrange
        //    var repositoryMock = new Mock<ITestRepository>();
        //    TestDTO testDTO = new TestDTO
        //    {
        //        TestId = Guid.NewGuid(),
        //        Name = "Expected test",
        //        Category = "Sample category",
        //        UserId = "1111"
        //    };

        //    var mapperMock = new Mock<IMapper>();
        //    Test test = new Test(Guid.NewGuid(), "Expected test", "Sample category", "1111");
        //    mapperMock.Setup(p => p.Map<TestDTO, Test>(It.IsAny<TestDTO>())).Returns(test);
        //    var testService = new TestService(repositoryMock.Object, mapperMock.Object);

        //    //Act
        //    await testService.AddTestAsync(testDTO);

        //    //Assert
        //    repositoryMock.Verify(p => p.AddAsync(test), Times.Once);
        //}
        //#endregion

        //#region  DeleteTestAsync
        //[Test]
        //public async Task DeleteTestAsync_GivenGuid_InvokesRepositoryGetAsync()
        //{
        //    //Arrange
        //    var repositoryMock = new Mock<ITestRepository>();
        //    var mapperMock = new Mock<IMapper>();
        //    Guid sampleGuid = Guid.NewGuid();
        //    Test test = new Test(sampleGuid, "Example Test", "Example Category", "1111");
        //    repositoryMock.Setup(p => p.GetAsync(It.IsAny<Guid>())).ReturnsAsync(test);

        //    TestService testService = new TestService(repositoryMock.Object, mapperMock.Object);

        //    //Act
        //    await testService.DeleteTestAsync(sampleGuid);

        //    //Assert
        //    repositoryMock.Verify(p => p.GetAsync(sampleGuid), Times.Once);
        //}

        //[Test]
        //public void DeleteTestAsync_NoTestInDB_ThrowsException()
        //{
        //    //Arrange
        //    var repositoryMock = new Mock<ITestRepository>();
        //    var mapperMock = new Mock<IMapper>();
        //    Test test = null;
        //    repositoryMock.Setup(p => p.GetAsync(It.IsAny<Guid>())).ReturnsAsync(test);

        //    TestService testService = new TestService(repositoryMock.Object, mapperMock.Object);

        //    //Act
        //    Func<Task> act = async () => await testService.DeleteTestAsync(Guid.NewGuid());

        //    //Assert
        //    act.Should().Throw<ArgumentException>();
        //}

        //[Test]
        //public async Task DeleteTestAsync_TestExistsInDB_InvokesRepositoryDeleteAsync()
        //{
        //    //Arrange
        //    var repositoryMock = new Mock<ITestRepository>();
        //    var mapperMock = new Mock<IMapper>();
        //    Guid sampleGuid = Guid.NewGuid();
        //    Test test = new Test(sampleGuid, "Example Test", "Example Category", "1111");
        //    repositoryMock.Setup(p => p.GetAsync(It.IsAny<Guid>())).ReturnsAsync(test);

        //    TestService testService = new TestService(repositoryMock.Object, mapperMock.Object);

        //    //Act
        //    await testService.DeleteTestAsync(sampleGuid);

        //    //Assert
        //    repositoryMock.Verify(p => p.DeleteAsync(test), Times.Once);
        //}
        //#endregion

        //[Test]
        //public async Task GetTestAsync_GivenGuid_InvokesRepositoryGetAsync()
        //{
        //    //Arrange
        //    var repositoryMock = new Mock<ITestRepository>();
        //    var mapperMock = new Mock<IMapper>();
        //    Guid sampleGuid = Guid.NewGuid();
        //    TestService testService = new TestService(repositoryMock.Object, mapperMock.Object);

        //    //Act
        //    await testService.GetTestAsync(sampleGuid);

        //    //Assert
        //    repositoryMock.Verify(p => p.GetAsync(sampleGuid), Times.Once);
        //}

        //[Test]
        //public async Task GetTestAsync_GivenGuid_InvokesMapperMap()
        //{
        //    //Arrange
        //    var repositoryMock = new Mock<ITestRepository>();
        //    var mapperMock = new Mock<IMapper>();
        //    Guid sampleGuid = Guid.NewGuid();
        //    Test test = new Test(sampleGuid, "Example Test", "Example Category", "1111");
        //    TestService testService = new TestService(repositoryMock.Object, mapperMock.Object);
        //    repositoryMock.Setup(p => p.GetAsync(sampleGuid)).ReturnsAsync(test);

        //    //Act
        //    await testService.GetTestAsync(sampleGuid);

        //    //Assert
        //    mapperMock.Verify(p => p.Map<Test, TestDTO>(test), Times.Once);
        //}

        //[Test]
        //public void GetUserTestsAsync_GivenNullString_ThrowsArgumentNullException()
        //{
        //    //Arrange
        //    var repositoryMock = new Mock<ITestRepository>();
        //    var mapperMock = new Mock<IMapper>();
        //    TestService testService = new TestService(repositoryMock.Object, mapperMock.Object);

        //    //Act
        //    Func<Task> act = async () => await testService.GetUserTestsAsync(null);

        //    //Assert
        //    act.Should().Throw<ArgumentNullException>();
        //}

        //[Test]
        //public async Task GetUserTestsAsync_GivenString_InvokesRepositoryGetAllForUserAsync()
        //{
        //    //Arrange
        //    var repositoryMock = new Mock<ITestRepository>();
        //    var mapperMock = new Mock<IMapper>();
        //    string userId = "1111";
        //    TestService testService = new TestService(repositoryMock.Object, mapperMock.Object);

        //    //Act
        //    await testService.GetUserTestsAsync(userId);

        //    //Assert
        //    repositoryMock.Verify(p => p.GetAllForUserAsync(userId), Times.Once);
        //}

        //[Test]
        //public async Task GetUserTestsAsync_GivenString_InvokesMapperMap()
        //{
        //    //Arrange
        //    var repositoryMock = new Mock<ITestRepository>();
        //    var mapperMock = new Mock<IMapper>();
        //    string userId = "1111";
        //    IEnumerable<Test> tests = new List<Test>
        //    {
        //        new Test(Guid.NewGuid(), "Example Test1", "Example Category", "1111"),
        //        new Test(Guid.NewGuid(), "Example Test2", "Example Category", "1111")
        //     };
        //    TestService testService = new TestService(repositoryMock.Object, mapperMock.Object);
        //    repositoryMock.Setup(p => p.GetAllForUserAsync(userId)).ReturnsAsync(tests);

        //    //Act
        //    await testService.GetUserTestsAsync(userId);

        //    //Assert
        //    mapperMock.Verify(p => p.Map<IEnumerable<Test>, IEnumerable<TestDTO>>(tests), Times.Once);
        //}
    }
}
