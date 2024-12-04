using AutoMapper;
using LifeInsuranceApplication.Contexts;
using LifeInsuranceApplication.Controllers;
using LifeInsuranceApplication.Interfaces;
using LifeInsuranceApplication.Models;
using LifeInsuranceApplication.Models.DTO;
using LifeInsuranceApplication.Repositories;
using LifeInsuranceApplication.Services;
using Microsoft.AspNetCore.Mvc;
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
    public class PolicyControllerTest
    {
        DbContextOptions options;
        InsuranceContext context;
        PolicyRepository repository;
        Mock<ILogger<PolicyRepository>> logger;
        private Mock<ILogger<PolicyController>> loggerController;
        Mock<IMapper> mapper;
        IPolicyService policyService;
        PolicyDTO policy;
        Policy policyEntity;

        [SetUp]
        public void Setup()
        {
            options = new DbContextOptionsBuilder<InsuranceContext>()
              .UseInMemoryDatabase("TestAdd")
              .Options;
            context = new InsuranceContext(options);
            logger = new Mock<ILogger<PolicyRepository>>();
            loggerController = new Mock<ILogger<PolicyController>>();
            repository = new PolicyRepository(context, logger.Object);
            mapper = new Mock<IMapper>();
            policyService = new PolicyService(repository, mapper.Object);
        }

        [Test]
        public async Task AddPolicyTest()
        {
            // Arrange
            var policy = new PolicyDTO
            {
                PolicyNumber = "POL-20231023123045-1234"
            };
            var policyEntity = new Policy
            {
                PolicyNumber = "POL-20231023123045-1234"
            };
            mapper.Setup(m => m.Map<Policy>(policy)).Returns(policyEntity);//dummying the method to return the result for testing
            var controller = new PolicyController(policyService, loggerController.Object);
            // Act
            var result = await controller.CreateNewPolicies(policy);
            Assert.IsNotNull(result);
            var resultObject = result as OkObjectResult;
            // Assert
            Assert.IsNotNull(resultObject);
            Assert.AreEqual(200, resultObject.StatusCode);
        }
    }
}
