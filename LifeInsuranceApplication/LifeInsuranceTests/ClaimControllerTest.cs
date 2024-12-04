using AutoMapper;
using LifeInsuranceApplication.Contexts;
using LifeInsuranceApplication.Controllers;
using LifeInsuranceApplication.Interfaces;
using LifeInsuranceApplication.Models.DTO;
using LifeInsuranceApplication.Models;
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
    public class ClaimControllerTest
    {
        DbContextOptions options;
        InsuranceContext context;
        ClaimRepository repository;
        Mock<ILogger<ClaimRepository>> logger;
        private Mock<ILogger<ClaimController>> loggerController;
        Mock<IMapper> mapper;
        IClaimService claimService;
        ClaimDTO claim;
        Claim claimEntity;

        [SetUp]
        public void Setup()
        {
            options = new DbContextOptionsBuilder<InsuranceContext>()
              .UseInMemoryDatabase("TestAdd")
              .Options;
            context = new InsuranceContext(options);
            logger = new Mock<ILogger<ClaimRepository>>();
            loggerController = new Mock<ILogger<ClaimController>>();
            repository = new ClaimRepository(context, logger.Object);
            mapper = new Mock<IMapper>();
            claimService = new ClaimService(repository, "Ok");
        }

        [Test]
        public async Task AddClaimTest()
        {
            // Arrange
            var claim = new ClaimDTO
            {
                PolicyId = 1,
                ClaimTypeId = 1,
                Email = "rohit@gmail.com",
                Phone = "9876543210"

            };
            var claimEntity = new Claim
            {
                Id = 1,
                ClaimTypeId = 1,
                Email = "rohit@gmail.com",
                Phone = "9876543210"
            };
            mapper.Setup(m => m.Map<Claim>(claim)).Returns(claimEntity);//dummying the method to return the result for testing
            var controller = new ClaimController(claimService);
            // Act
            var result = await controller.CreateNewClaims(claim);
            Assert.IsNotNull(result);
            var resultObject = result as OkObjectResult;
            // Assert
            Assert.IsNotNull(resultObject);
            Assert.AreEqual(200, resultObject.StatusCode);
        }
    }
}
