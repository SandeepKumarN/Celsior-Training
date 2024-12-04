using AutoMapper;
using LifeInsuranceApplication.Contexts;
using LifeInsuranceApplication.Interfaces;
using LifeInsuranceApplication.Models.DTO;
using LifeInsuranceApplication.Models;
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
    public class ClaimServiceTest
    {
        DbContextOptions options;
        InsuranceContext context;
        ClaimRepository repository;
        Mock<ILogger<ClaimRepository>> logger;
        Mock<IMapper> mapper;


        [SetUp]
        public void Setup()
        {
            options = new DbContextOptionsBuilder<InsuranceContext>()
              .UseInMemoryDatabase("TestAdd")
              .Options;
            context = new InsuranceContext(options);
            logger = new Mock<ILogger<ClaimRepository>>();
            repository = new ClaimRepository(context, logger.Object);
            mapper = new Mock<IMapper>();
        }

        [Test]
        public async Task AddNewClaimTest()
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
                PolicyId = 1,
                ClaimTypeId = 1,
                Email = "rohit@gmail.com",
                Phone = "9876543210"
            };
            mapper.Setup(m => m.Map<Claim>(claim)).Returns(claimEntity);//dummying the method to return the result for testing
            IClaimService claimService = new ClaimService(repository, "mapper.Object");
            // Act
            var result = await claimService.CreateNewClaims(claim);

            // Assert
            Assert.AreEqual(result, 3);
        }
    }
}
