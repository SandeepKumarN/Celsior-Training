using LifeInsuranceApplication.Contexts;
using LifeInsuranceApplication.Exceptions;
using LifeInsuranceApplication.Models;
using LifeInsuranceApplication.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeInsuranceTests
{
    public class ClaimTypeRepositoryTest
    {
        DbContextOptions options;
        InsuranceContext context;
        ClaimTypeRepository repository;
        Mock<ILogger<ClaimTypeRepository>> logger;
        [SetUp]
        public void Setup()
        {
            options = new DbContextOptionsBuilder<InsuranceContext>()
              .UseInMemoryDatabase("TestAdd")
              .Options;
            context = new InsuranceContext(options);
            logger = new Mock<ILogger<ClaimTypeRepository>>();
            repository = new ClaimTypeRepository(context, logger.Object);
        }


        [Test]
        [TestCase("Test ClaimName ")]
        public async Task TestAdd(string ClaimName)
        {
            //Arrange
            ClaimType claimType = new ClaimType
            {
                ClaimName = "Accidental"
            };
            //Act
            var result = await repository.Add(claimType);
            //Assert
            Assert.AreEqual(result.ClaimName, claimType.ClaimName);
        }

        //[Test]
        //[TestCase("Test ClaimName ")]

        //public async Task TestAddException(string ClaimName)
        //{
        //    //Arrange
        //    var claimType = new ClaimType
        //    {
        //       // ClaimName = "Accidental"
        //    };

        //    //Assert
        //    Assert.ThrowsAsync<CouldNotAddException>(async () => await repository.Add(claimType));

        //}
    }
}
