using LifeInsuranceApplication.Contexts;
using LifeInsuranceApplication.Exceptions;
using LifeInsuranceApplication.Migrations;
using LifeInsuranceApplication.Models;
using LifeInsuranceApplication.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LifeInsuranceTests
{
    public class ClaimRepositoryTest
    {
        DbContextOptions options;
        InsuranceContext context;
        ClaimRepository repository;
        Mock<ILogger<ClaimRepository>> logger;
        [SetUp]
        public void Setup()
        {
            options = new DbContextOptionsBuilder<InsuranceContext>()
              .UseInMemoryDatabase("TestAdd")
              .Options;
            context = new InsuranceContext(options);
            logger = new Mock<ILogger<ClaimRepository>>();
            repository = new ClaimRepository(context, logger.Object);
        }


        [Test]
        [TestCase(1, 1, "rohit@gmail.com", "9876543210")]
        public async Task TestAdd(int policyId, int claimTypeId, string email, string phone)
        {
            //Arrange
            var claim = new LifeInsuranceApplication.Models.Claim
            {
                PolicyId = policyId,
                ClaimTypeId = claimTypeId,
                Email = email,
                Phone = phone
            };
            //Act
            var result = await repository.Add(claim);
            //Assert
            Assert.AreEqual(claim.Email, result.Email);
        }

        //[Test]
        //[TestCase(1, 1, "rohit@gmail.com", "9876543210")]

        //public async Task TestAddException(int policyId, int claimTypeId, string email, string phone)
        //{
        //    //Arrange
        //    var claim = new LifeInsuranceApplication.Models.Claim
        //    {
        //        PolicyId = policyId,
        //        ClaimTypeId = claimTypeId,
        //        Email = email,
        //        Phone = phone
        //    };

        //    //Assert
        //    Assert.ThrowsAsync<CouldNotAddException>(async () => await repository.Add(claim));

        //}
    }
}
