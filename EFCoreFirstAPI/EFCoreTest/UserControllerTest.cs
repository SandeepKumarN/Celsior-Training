using EFCoreFirstAPI.Contexts;
using EFCoreFirstAPI.Controllers;
using EFCoreFirstAPI.Interfaces;
using EFCoreFirstAPI.Models;
using EFCoreFirstAPI.Models.DTOs;
using EFCoreFirstAPI.Repositories;
using EFCoreFirstAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreTest
{
    class UserControllerTest
    {
        DbContextOptions options;
        ShoppingContext context;
        UserRepository repository;
        UserService service;
        UserController controller;
        Mock<ILogger<UserRepository>> logger;
        Mock<ILogger<UserController>> loggerController;
        Mock<ILogger<UserService>> loggerService;
        Mock<ITokenService> tokenService;

        [SetUp]
        public void Setup()
        {
            options = new DbContextOptionsBuilder<ShoppingContext>()
            .UseInMemoryDatabase("TestAdd")
              .Options;
            context = new ShoppingContext(options);
            logger = new Mock<ILogger<UserRepository>>();
            loggerService= new Mock<ILogger<UserService>>();
            loggerController= new Mock<ILogger<UserController>>();
            repository = new UserRepository(context, logger.Object);
            tokenService = new Mock<ITokenService>();
            service = new UserService(repository, tokenService.Object, loggerService.Object);
            controller = new UserController(service, loggerController.Object);
        }

        [Test]
        [TestCase("sandeep", "common" ,Roles.Admin)]
        public async Task TestRegister(string name, string password,Roles roles)
        {
            UserCreateDTO user = new UserCreateDTO
            {
                Username = name,
                Password = password,
                Role = roles
            };

            //var responseDTO = await controller.RegisterUser(user);
            var result = await controller.RegisterUser(user);
            Assert.IsNotNull(result);
            var resultObject = result.Result as OkObjectResult;

            // Assert
            Assert.IsNotNull(resultObject);
            Assert.AreEqual(200, resultObject.StatusCode);
        }
    }
}
