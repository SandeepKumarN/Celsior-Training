using AutoMapper;
using EShoppingApp.Contexts;
using EShoppingApp.Controllers;
using EShoppingApp.Interfaces;
using EShoppingApp.Models.DTOs;
using EShoppingApp.Models;
using EShoppingApp.Repositories;
using EShoppingApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShoppingTest
{
    internal class ProductControllerTest
    {
        DbContextOptions options;
        ShoppingContext context;
        ProductRepository repository;
        Mock<ILogger<ProductRepository>> logger;
        private Mock<ILogger<ProductController>> loggerController;
        Mock<IMapper> mapper;
        IProductService productService;
        ProductDTO product;
        Product productEntity;

        [SetUp]
        public void Setup()
        {
            options = new DbContextOptionsBuilder<ShoppingContext>()
              .UseInMemoryDatabase("TestAdd")
              .Options;
            context = new ShoppingContext(options);
            logger = new Mock<ILogger<ProductRepository>>();
            loggerController = new Mock<ILogger<ProductController>>();
            repository = new ProductRepository(context, logger.Object);
            mapper = new Mock<IMapper>();
            productService = new ProductService(repository, mapper.Object);
        }

        [Test]
        public async Task AddProductTest()
        {
            // Arrange
            var product = new ProductDTO
            {
                Name = "laptop",
                Price = 10.0f,
                Quantity = 1,
                BasicImage = "laptop",
                Description = "Description"
            };
            var productEntity = new Product
            {
                Name = "laptop",
                Price = 10.0f,
                Quantity = 1,
                BasicImage = "laptop",
                Description = "Description"
            };
            mapper.Setup(m => m.Map<Product>(product)).Returns(productEntity);//dummying the method to return the result for testing
            var controller = new ProductController(productService, loggerController.Object);
            // Act
            var result = await controller.AddProduct(product);
            Assert.IsNotNull(result);
            var resultObject = result as OkObjectResult;
            // Assert
            Assert.IsNotNull(resultObject);
            Assert.AreEqual(200, resultObject.StatusCode);
        }
    }
}
