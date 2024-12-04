//using AutoMapper;
//using EShoppingApp.Contexts;
//using EShoppingApp.Exceptions;
//using EShoppingApp.Interfaces;

//using EShoppingApp.Models;
//using EShoppingApp.Models.DTOs;
//using EShoppingApp.Repositories;
//using EShoppingApp.Services;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Logging;
//using Moq;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace EShoppingTest
//{
//    internal class OrderServiceTest
//    {
//        DbContextOptions options;
//        ShoppingContext context;
//        OrderRepository repository;
//        OrderService orderService;
//        Mock<ILogger<OrderRepository>> logger;
//        Mock<IMapper> mapper;

//        [SetUp]
//        public void Setup()
//        {
//            options = new DbContextOptionsBuilder<ShoppingContext>()
//              .UseInMemoryDatabase("TestAdd")
//              .Options;
//            context = new ShoppingContext(options);
//            logger = new Mock<ILogger<OrderRepository>>();
//            repository = new OrderRepository(context, logger.Object);
//            mapper = new Mock<IMapper>();

//        }

//        [Test]
//        public async Task PlaceOrder()
//        {
//            // Arrange
//            var orderDto = new OrderDTO
//            {
//                //UserId = "user123",
//                TotalAmount = 100,
//                OrderDate = DateTime.Now
//            };
//            var order = new Order
//            {
//                //UserId = "user123",
//                TotalAmount = 100,
//                OrderDate = DateTime.Now
//            };

//            mapper.Setup(m => m.Map<Order>(orderDto)).Returns(order);
//            mapper.Setup(m => m.Map<OrderDTO>(It.IsAny<Order>())).Returns(orderDto);
//            orderService = new OrderService(repository, mapper.Object);
//            // Act
//            var result = await orderService.PlaceOrderAsync(orderDto);

//            // Assert
//            Assert.IsNotNull(result);
//            //Assert.AreEqual(orderDto.UserId, result.UserId);
//            //Assert.AreEqual(orderDto.TotalAmount, result.TotalAmount);
//        }



//        [Test]
//        public async Task GetOrderByIdAsync_ShouldReturnOrder()
//        {
//            // Arrange
//            var orderId = 1;
//            var order = new Order
//            {
//                Id = orderId,
//                TotalAmount = 100,
//                OrderDate = DateTime.UtcNow
//            };

//            var orderDto = new OrderDTO
//            {
//                Id = orderId,
//                TotalAmount = 100,
//                OrderDate = order.OrderDate
//            };

//            // Add the order to the in-memory database
//            await context.orders.AddAsync(order);
//            await context.SaveChangesAsync();

//            // Set up the mapper mock to map Order to OrderDTO
//            mapper.Setup(m => m.Map<OrderDTO>(It.IsAny<Order>())).Returns(orderDto);

//            orderService = new OrderService(repository, mapper.Object);
//            // Act
//            var result = await orderService.GetOrderByIdAsync(orderId);

//            // Assert
//            Assert.IsNotNull(result);
//            Assert.AreEqual(orderId, result.Id);
//            Assert.AreEqual(order.TotalAmount, result.TotalAmount);
//            Assert.AreEqual(order.OrderDate, result.OrderDate);
//        }


//        [Test]
//        public async Task UpdateOrderAsync_ShouldUpdateOrder()
//        {
//            // Arrange
//            int orderId = 1;

//            // Create a valid OrderDTO to update the order
//            var orderDto = new OrderDTO
//            {
//                Id = orderId,  // Make sure this is set
//                //UserId = "user1",
//                // Add other properties as necessary
//            };

//            // Create an Order that exists in the database
//            var existingOrder = new Order
//            {
//                Id = orderId,
//                //Id = "user1",
//                // Populate other properties as necessary to match expected DTO
//            };

//            // Set up the mapper to map between Order and OrderDTO
//            mapper.Setup(m => m.Map<Order>(orderDto)).Returns(existingOrder);
//            mapper.Setup(m => m.Map<OrderDTO>(existingOrder)).Returns(orderDto);

//            // Add the existing order to the in-memory database
//            context.orders.Add(existingOrder);
//            await context.SaveChangesAsync();


//            orderService = new OrderService(repository, mapper.Object);
//            // Act
//            var result = await orderService.UpdateOrderAsync(orderId, orderDto);

//            // Assert
//            Assert.NotNull(result);
//            Assert.AreEqual(orderId, result.Id); // Ensure the correct order ID is returned

//        }


//        [Test]
//        public async Task DeleteOrderAsync_ShouldReturnTrue()
//        {
//            // Arrange
//            var orderId = 1;

//            // Add an existing order to the context
//            var existingOrder = new Order { Id = orderId };
//            context.orders.Add(existingOrder);
//            await context.SaveChangesAsync();

//            // Setup mapper to simulate deletion
//            mapper.Setup(m => m.Map<Order>(It.IsAny<OrderDTO>())).Returns(existingOrder);

//            // You could also set up a method on the mapper to simulate returning the order for deletion
//            // This is hypothetical, as mappers typically don’t delete
//            // Here we simulate a scenario of "fetching" for deletion
//            mapper.Setup(m => m.Map<OrderDTO>(existingOrder)).Returns(new OrderDTO { Id = orderId });

//            // Since you mentioned you aren't using the repository, we simulate the deletion logic
//            // Assume DeleteOrderAsync in OrderService directly checks the context
//            orderService = new OrderService(repository, mapper.Object);

//            // Act
//            var result = await orderService.DeleteOrderAsync(orderId);

//            // Assert
//            Assert.IsTrue(result);
//        }

//        [Test]
//        public async Task GetOrdersByUserIdAsync_ShouldReturnUserOrders()
//        {
//            // Arrange
//            var userId = "user123";
//            var orders = new List<Order>
//    {
//            new Order { Id = 1, TotalAmount = 100, OrderDate = DateTime.Now },
//            new Order { Id = 2, TotalAmount = 200, OrderDate = DateTime.Now }
//    };

//            // Set up the context with the orders
//            context.orders.AddRange(orders);
//            await context.SaveChangesAsync();

//            // Mock the mapper to return the correct orders for the user
//            mapper.Setup(m => m.Map<ICollection<OrderDTO>>(It.IsAny<IEnumerable<Order>>()))
//                  .Returns(orders.Select(o => new OrderDTO
//                  {
//                      Id = o.Id,
//                      TotalAmount = o.TotalAmount,
//                      OrderDate = o.OrderDate
//                  }).ToList());

//            // Create the OrderService with the actual repository
//            orderService = new OrderService(repository, mapper.Object);

//            // Act
//            var result = await orderService.GetOrdersByUserIdAsync(orders);

//            // Assert
//            Assert.IsNotNull(result);
//            Assert.AreEqual(2, result.Count);
//            Assert.AreEqual(userId, result.First().UserId);
//        }

//    }
//}
