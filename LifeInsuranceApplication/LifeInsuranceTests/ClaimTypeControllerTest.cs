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
    public class ClaimTypeControllerTest
    {
        DbContextOptions options;
        InsuranceContext context;
        ClaimTypeRepository repository;
        Mock<ILogger<ClaimTypeRepository>> logger;
        private Mock<ILogger<ClaimTypeController>> loggerController;
        Mock<IMapper> mapper;
        IClaimTypeService claimTypeService;
        ClaimTypeDTO claimType;
        ClaimType claimTypeEntity;

        [SetUp]
        public void Setup()
        {
            options = new DbContextOptionsBuilder<InsuranceContext>()
              .UseInMemoryDatabase("TestAdd")
              .Options;
            context = new InsuranceContext(options);
            logger = new Mock<ILogger<ClaimTypeRepository>>();
            loggerController = new Mock<ILogger<ClaimTypeController>>();
            repository = new ClaimTypeRepository(context, logger.Object);
            mapper = new Mock<IMapper>();
            claimTypeService = new ClaimTypeService(repository, mapper.Object);
        }

        [Test]
        public async Task AddClaimTypeTest()
        {
            // Arrange
            var claimType = new ClaimTypeDTO
            {
                ClaimName = "Accidental"
            };
            var claimTypeEntity = new ClaimType
            {
                ClaimName = "Accidental"
            };
            mapper.Setup(m => m.Map<ClaimType>(claimType)).Returns(claimTypeEntity);//dummying the method to return the result for testing
            var controller = new ClaimTypeController(claimTypeService);
            // Act
            var result = await controller.CreateNewClaimTypes(claimType);
            Assert.IsNotNull(result);
            var resultObject = result as OkObjectResult;
            // Assert
            Assert.IsNotNull(resultObject);
            Assert.AreEqual(200, resultObject.StatusCode);
        }
    }
}
