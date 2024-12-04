//using AutoMapper;
//using EShoppingApp.Contexts;
//using EShoppingApp.Controllers;
//using EShoppingApp.Interfaces;
//using EShoppingApp.Models;
//using EShoppingApp.Models.DTOs;
//using EShoppingApp.Repositories;
//using EShoppingApp.Services;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Infrastructure;
//using Microsoft.Extensions.Logging;
//using Moq;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace EShoppingTest
//{
//    internal class CustomerRepositoryTest
//    {
//        DbContextOptions options;
//        ShoppingContext context;
//        CustomerRepository repository;
//        Mock<ILogger<CustomerRepository>> logger;

//        [SetUp]
//        public void Setup()
//        {
//            options = new DbContextOptionsBuilder<ShoppingContext>()
//              .UseInMemoryDatabase("TestAdd")
//              .Options;
//            context = new ShoppingContext(options);
//            logger = new Mock<ILogger<CustomerRepository>>();
//            repository = new CustomerRepository(context, logger.Object);
//        }

//        [Test]
//        public async Task Add_ShouldAddCustomer()
//        {
//            // Arrange
//            var customer = new Customer
//            {
//                Name = "John Doe",
//                Address = "123 Main St",
//                Phone = "123-456-7890"
//            };


//            // Act
//            var result = await repository.Add(customer);

//            // Assert
//            Assert.IsNotNull(result);
//            Assert.AreEqual(customer.Name, result.Name);
//            Assert.AreEqual(customer.Address, result.Address);
//            Assert.AreEqual(customer.Phone, result.Phone);

//        }

//        //public async Task GetAll_ShouldReturnAllCustomers()
//        //{
//        //    // Arrange
//        //    var customer = new CustomerDTO
//        //    {
//        //        Id = 1,
//        //        Name = "John Doe",
//        //        Address = "123 Main St",
//        //        Phone = "123-456-7890"
//        //    };
//        //    var customerEntity = new Customer 
//        //    {
//        //        Id = 1,
//        //        Name = "Jane Smith",
//        //        Address = "456 Elm St",
//        //        Phone = "987-654-3210"
//        //    };

//        //    var context = new ShoppingContext(customers);
//        //    context.customers.AddRange(customer1, customer2);
//        //    await context.SaveChangesAsync();

//        //    // Act
//        //    var result = await repository.GetAll();

//        //    // Assert
//        //    Assert.NotNull(result);
//        //    Assert.AreEqual(2, result.Count());
//        //}
//    }
//}
