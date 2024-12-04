using LifeInsuranceApplication.Contexts;
using LifeInsuranceApplication.Exceptions;
using LifeInsuranceApplication.Models;
using LifeInsuranceApplication.Models.DTO;
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
    public class PolicyRepositoryTest
    {
        DbContextOptions options;
        InsuranceContext context;
        PolicyRepository repository;
        Mock<ILogger<PolicyRepository>> logger;
        [SetUp]
        public void Setup()
        {
            options = new DbContextOptionsBuilder<InsuranceContext>()
              .UseInMemoryDatabase("TestAdd")
              .Options;
            context = new InsuranceContext(options);
            logger = new Mock<ILogger<PolicyRepository>>();
            repository = new PolicyRepository(context, logger.Object);
        }


        [Test]
        [TestCase("Test PolicyNumber ")]
        public async Task TestAdd(string PolicyNumber)
        {
            //Arrange
            Policy policy = new Policy
            {
                PolicyNumber = "POL - 20231023123045 - 1234"
            };
            //Act
            var result = await repository.Add(policy);
            //Assert
            Assert.AreEqual(result.PolicyNumber, policy.PolicyNumber);
        }

        //[Test]
        //[TestCase("Test PolicyNumber ")]

        //public async Task TestAddException(string PolicyNumber)
        //{
        //    //Arrange
        //    var policy = new Policy
        //    {
                
        //    };
            
        //    //Assert
        //    Assert.ThrowsAsync<CouldNotAddException>(async () => await repository.Add(policy));

        //}
    }
}
