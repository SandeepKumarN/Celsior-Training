//using EShoppingApp.Contexts;
//using EShoppingApp.Controllers;
//using EShoppingApp.Interfaces;
//using EShoppingApp.Models.DTOs;
//using EShoppingApp.Models;
//using EShoppingApp.Repositories;
//using EShoppingApp.Services;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Logging;
//using Moq;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using EFCoreFirstAPI.Repositories;
//using System.ComponentModel.DataAnnotations;
//using Castle.Core.Smtp;

//namespace EShoppingTest
//{
//    internal class UserControllerTest
//    {
//        DbContextOptions options;
//        ShoppingContext context;
//        UserRepository repository;
//        UserService service;
//        UserController controller;
//        Mock<ILogger<UserRepository>> logger;
//        Mock<IEmailSender> mockEmailSender;
//        Mock<ILogger<UserController>> loggerController;
//        Mock<ILogger<UserService>> loggerService;
//        Mock<ITokenService> tokenService;

//        [SetUp]
//        public void Setup()
//        {
//            options = new DbContextOptionsBuilder<ShoppingContext>()
//            .UseInMemoryDatabase("TestAdd")
//              .Options;
//            context = new ShoppingContext(options);
//            logger = new Mock<ILogger<UserRepository>>();
//            loggerService = new Mock<ILogger<UserService>>();
//            loggerController = new Mock<ILogger<UserController>>();
//            repository = new UserRepository(context, logger.Object);
//            tokenService = new Mock<ITokenService>();
//            Mock<IEmailSender> mockEmailSender;
//            service = new UserService(repository, tokenService.Object, loggerService.Object);
//            controller = new UserController(service, loggerController.Object);
//        }

//        [Test]
//        [TestCase("sandeep", "common", "john@gmail.com", Roles.Admin)]
//        public async Task TestRegister(string name, string password, string email, Roles roles)
//        {
//            UserCreateDTO user = new UserCreateDTO
//            {
//                Username = name,
//                Password = password,
//                Email = email,
//                Role = roles
//            };

//            //var responseDTO = await controller.RegisterUser(user);
//            var result = await controller.RegisterUser(user);
//            Assert.IsNotNull(result);
//            var resultObject = result.Result as OkObjectResult;

//            // Assert
//            Assert.IsNotNull(resultObject);
//            Assert.AreEqual(200, resultObject.StatusCode);
//        }
//    }
//}
