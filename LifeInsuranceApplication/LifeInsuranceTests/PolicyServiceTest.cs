using AutoMapper;
using LifeInsuranceApplication.Contexts;
using LifeInsuranceApplication.Interfaces;
using LifeInsuranceApplication.Models;
using LifeInsuranceApplication.Models.DTO;
using LifeInsuranceApplication.Repositories;
using LifeInsuranceApplication.Services;
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
    public class PolicyServiceTest
    {
        DbContextOptions options;
        InsuranceContext context;
        PolicyRepository repository;
        Mock<ILogger<PolicyRepository>> logger;
        Mock<IMapper> mapper;


        [SetUp]
        public void Setup()
        {
            options = new DbContextOptionsBuilder<InsuranceContext>()
              .UseInMemoryDatabase("TestAdd")
              .Options;
            context = new InsuranceContext(options);
            logger = new Mock<ILogger<PolicyRepository>>();
            repository = new PolicyRepository(context, logger.Object);
            mapper = new Mock<IMapper>();
        }

        [Test]
        public async Task AddNewPolicyTest()
        {
            // Arrange
            var policy = new PolicyDTO
            {
                PolicyNumber = "POL - 20231023123045 - 1234"

            };
            var policyEntity = new Policy
            {
                PolicyNumber = "POL - 20231023123045 - 1234"
            };
            mapper.Setup(m => m.Map<Policy>(policy)).Returns(policyEntity);//dummying the method to return the result for testing
            IPolicyService policyService = new PolicyService(repository, mapper.Object);
            // Act
            var result = await policyService.CreateNewPolicies(policy);

            // Assert
            Assert.AreEqual(result, 3);
        } 
    }
}
