﻿using Examiner.Core.DomainModels;
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
    public class TestTests
    {
        public Test CreateTest()
        {
            return new Test(Guid.NewGuid(), "SampleTest", Guid.NewGuid());
        }

        [Test]
        public void SetName_GivenEmptyString_ThrowsArgumentNullException()
        {
            //Arrange
            Test test = CreateTest();

            //Act
            Action act = () => test.SetName(null);

            //Assert
            act.Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void SetName_GivenString_ChangesName()
        {
            //Arrange
            Test test = CreateTest();

            //Act
            test.SetName("NewName");

            //Assert
            test.Name.Should().Be("NewName");
        }

    }
}
