using EShoppingApp.Contexts;
using EShoppingApp.Exceptions;
using EShoppingApp.Interfaces;
using EShoppingApp.Models;
using EShoppingApp.Repositories;
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
    internal class OrderRepositoryTest
    {
        DbContextOptions options;
        ShoppingContext context;
        OrderRepository repository;
        Mock<ILogger<OrderRepository>> logger;

        [SetUp]
        public void Setup()
        {
            options = new DbContextOptionsBuilder<ShoppingContext>()
              .UseInMemoryDatabase("TestAdd")
              .Options;
            context = new ShoppingContext(options);
            logger = new Mock<ILogger<OrderRepository>>();
            repository = new OrderRepository(context, logger.Object);
        }


        [Test]
        public async Task TestAddOrder()
        {
            // Arrange
            var order = new Order
            {
                TotalAmount = 100,
                OrderDate = DateTime.Now
            };

            // Act
            var result = await repository.Add(order);

            // Assert
            Assert.AreNotEqual(0, result.Id);
            Assert.AreEqual(order.CustomerId, result.CustomerId);
            Assert.AreEqual(order.TotalAmount, result.TotalAmount);

            var addedOrder = await context.orders.FindAsync(result.Id);
            Assert.IsNotNull(addedOrder);
            Assert.AreEqual(order.CustomerId, addedOrder.CustomerId);
            Assert.AreEqual(order.TotalAmount, addedOrder.TotalAmount);
        }

        [Test]
        public async Task TestGetOrder()
        {
            // Arrange
            var order = new Order
            {
                TotalAmount = 100,
                OrderDate = DateTime.Now
            };
            var addedOrder = await repository.Add(order);

            // Act
            var result = await repository.Get(addedOrder.Id);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(addedOrder.Id, result.Id);
        }

        [Test]
        public async Task TestGetOrder_NotFound()
        {
            // Act & Assert
            Assert.ThrowsAsync<NotFoundException>(async () => await repository.Get(999)); // ID that doesn't exist

        }

        [Test]
        public async Task TestDeleteOrder()
        {
            // Arrange
            var order = new Order
            {
                TotalAmount = 100,
                OrderDate = DateTime.Now
            };
            var addedOrder = await repository.Add(order);

            // Act
            var result = await repository.Delete(addedOrder.Id);

            // Assert
            Assert.AreEqual(addedOrder.Id, result.Id);
            Assert.IsNull(await context.orders.FindAsync(addedOrder.Id));
        }

        [Test]
        public async Task TestDeleteOrder_NotFound()
        {
            // Act & Assert
            Assert.ThrowsAsync<NotFoundException>(async () => await repository.Delete(999));
        }
    }
}
