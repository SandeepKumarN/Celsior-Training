using AutoMapper;
using EShoppingApp.Contexts;
using EShoppingApp.Interfaces;
using EShoppingApp.Models;
using EShoppingApp.Models.DTOs;
using EShoppingApp.Repositories;
using EShoppingApp.Services;
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
    public class ProductServiceTest
    {
        DbContextOptions options;
        ShoppingContext context;
        ProductRepository repository;
        Mock<ILogger<ProductRepository>> logger;
        Mock<IMapper> mapper;


        [SetUp]
        public void Setup()
        {
            options = new DbContextOptionsBuilder<ShoppingContext>()
              .UseInMemoryDatabase("TestAdd")
              .Options;
            context = new ShoppingContext(options);
            logger = new Mock<ILogger<ProductRepository>>();
            repository = new ProductRepository(context, logger.Object);
            mapper = new Mock<IMapper>();
        }

        [Test]
        public async Task AddNewProductTest()
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
            mapper.Setup(m => m.Map<Product>(product)).Returns(productEntity);
            IProductService productService = new ProductService(repository, mapper.Object);
            // Act
            var result = await productService.AddNewProduct(product);

            // Assert
            Assert.IsTrue(result);
        }
    }
}
