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
    public class ClaimTypeSeviceTest
    {
        DbContextOptions options;
        InsuranceContext context;
        ClaimTypeRepository repository;
        Mock<ILogger<ClaimTypeRepository>> logger;
        Mock<IMapper> mapper;


        [SetUp]
        public void Setup()
        {
            options = new DbContextOptionsBuilder<InsuranceContext>()
              .UseInMemoryDatabase("TestAdd")
              .Options;
            context = new InsuranceContext(options);
            logger = new Mock<ILogger<ClaimTypeRepository>>();
            repository = new ClaimTypeRepository(context, logger.Object);
            mapper = new Mock<IMapper>();
        }

        [Test]
        public async Task AddNewClaimTypeTest()
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
            IClaimTypeService claimTypeService = new ClaimTypeService(repository, mapper.Object);
            // Act
            var result = await claimTypeService.CreateNewClaimTypes(claimType);

            // Assert
            Assert.AreEqual(result, 3);
        }
    }
}
