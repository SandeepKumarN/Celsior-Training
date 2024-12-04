//using AutoMapper;
//using EShoppingApp.Contexts;
//using EShoppingApp.Controllers;
//using EShoppingApp.Interfaces;
//using EShoppingApp.Models;
//using EShoppingApp.Models.DTOs;
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

//namespace EShoppingTest
//{
//    internal class OrderControllerTest
//    {
//        DbContextOptions options;
//        ShoppingContext context;
//        OrderRepository repository;
//        Mock<ILogger<OrderRepository>> logger;
//        private Mock<ILogger<OrderController>> loggerController;
//        Mock<IMapper> mapper;
//        IOrderService orderService;
//        OrderDTO order;
//        Order orderEntity;

//        [SetUp]
//        public void Setup()
//        {
//            options = new DbContextOptionsBuilder<ShoppingContext>()
//              .UseInMemoryDatabase("TestAdd")
//              .Options;
//            context = new ShoppingContext(options);
//            logger = new Mock<ILogger<OrderRepository>>();
//            loggerController = new Mock<ILogger<OrderController>>();
//            repository = new OrderRepository(context, logger.Object);
//            mapper = new Mock<IMapper>();
//            orderService = new OrderService(repository, mapper.Object);

//        }

//        [Test]
//        public async Task PlaceOrder_ShouldReturnOk_WhenOrderIsPlaced()
//        {
//            // Arrange
//            var orderDto = new OrderDTO
//            {
//                UserId = "TestUser",
//                TotalAmount = 10.0m,
//                OrderStatus = "Pending",
//                OrderDate = DateTime.UtcNow
//            };

//            // Set up AutoMapper mock to map the DTO to the entity
//            var orderEntity = new Order
//            {
//                Id = 1,
//                UserId = "TestUser",
//                TotalAmount = 10.0m,
//                OrderStatus = "Pending",
//                OrderDate = DateTime.UtcNow
//            };
//            mapper.Setup(m => m.Map<Order>(It.IsAny<OrderDTO>())).Returns(orderEntity);

//            var controller = new OrderController(orderService, loggerController.Object);
//            // Act: Call the PlaceOrder method of the controller
//            var result = await controller.PlaceOrder(orderDto);

//            // Assert: Verify that the result is OkObjectResult
//            Assert.IsInstanceOf<OkObjectResult>(result);
//            var okResult = result as OkObjectResult;
//            Assert.AreEqual(200, okResult.StatusCode);
//            Assert.AreEqual("Ok", okResult.Value);
//        }


//        [Test]
//        public async Task GetOrderById_ShouldReturnOk_WhenOrderExists()
//        {
//            var orderId = 1;
//            // Arrange
//            var order = new OrderDTO
//            {
//                // Id = orderId,
//                UserId = "TestUser",
//                TotalAmount = 100.0m,
//                OrderStatus = "Pending",
//                OrderDate = DateTime.UtcNow
//            };

//            var orderEntity = new Order
//            {
//                Id = orderId,
//                UserId = "TestUser",
//                TotalAmount = 10.0m,
//                OrderStatus = "Pending",
//                OrderDate = DateTime.UtcNow
//            };

//            mapper.Setup(m => m.Map<Order>(It.IsAny<OrderDTO>())).Returns(orderEntity);
//            var controller = new OrderController(orderService, loggerController.Object);

//            await controller.PlaceOrder(order);
//            // Act: Call the PlaceOrder method of the controller
//            var result = await controller.GetOrderById(orderId);

//            // Assert: Verify that the result is OkObjectResult
//            Assert.IsNotNull(result);
//            var okResult = result as OkObjectResult;
//            Assert.AreEqual(200, okResult.StatusCode);
//            //Assert.AreEqual("Ok", okResult.Value);
//        }




//        [Test]
//        public async Task DeleteOrder_ShouldReturnNoContent_WhenOrderIsDeleted()
//        {
//            // Arrange
//            var orderId = 1;
//            var orderEntity = new Order
//            {
//                Id = orderId,
//                UserId = "TestUser",
//                TotalAmount = 10.0m,
//                OrderStatus = "Pending",
//                OrderDate = DateTime.UtcNow
//            };

//            var order = new OrderDTO
//            {
//                //Id = orderId,
//                UserId = "TestUser",
//                TotalAmount = 100.0m,
//                OrderStatus = "Pending",
//                OrderDate = DateTime.UtcNow
//            };

//            mapper.Setup(m => m.Map<Order>(It.IsAny<OrderDTO>())).Returns(orderEntity);
//            // Simulate finding the order in the repository
//            //repository.GetOrderByIdAsync(orderId).ReturnsAsync(orderEntity);

//            // Create controller
//            var controller = new OrderController(orderService, loggerController.Object);
//            await controller.PlaceOrder(order);

//            // Act: Call the DeleteOrder method
//            var result = await controller.DeleteOrder(orderId);

//            // Assert
//            Assert.IsNotNull(result);
//            var okResult = result as OkObjectResult;
//            Assert.AreEqual(200, okResult.StatusCode);
//            //Assert.AreEqual("Ok", okResult.Value);
//        }

//        [Test]
//        public async Task UpdateOrder_ShouldReturnOk_WhenOrderIsUpdated()
//        {
//            // Arrange
//            var orderId = 1;
//            var orderDto = new OrderDTO
//            {
//                UserId = "UpdatedUser",
//                TotalAmount = 20.0m,
//                OrderStatus = "Shipped",
//                OrderDate = DateTime.UtcNow
//            };

//            var updatedOrderEntity = new Order
//            {
//                UserId = "UpdatedUser",
//                TotalAmount = 20.0m,
//                OrderStatus = "Shipped",
//                OrderDate = DateTime.UtcNow
//            };

//            // Setup AutoMapper to map OrderDTO to Order
//            mapper.Setup(m => m.Map<Order>(It.IsAny<OrderDTO>())).Returns(updatedOrderEntity);

//            // Simulate updating the order and returning the updated order
//            //repository.UpdateOrderAsync(orderId, It.IsAny<OrderDTO>()).ReturnsAsync(updatedOrderEntity);

//            // Create controller
//            var controller = new OrderController(orderService, loggerController.Object);

//            await controller.PlaceOrder(orderDto);

//            // Act: Call the UpdateOrder method
//            var result = await controller.UpdateOrder(orderId, orderDto);

//            // Assert
//            //Assert.IsInstanceOf<OkObjectResult>(result);
//            Assert.IsNotNull(result);
//            var okResult = result as OkObjectResult;
//            Assert.AreEqual(200, okResult.StatusCode);
//            //Assert.AreEqual(updatedOrderEntity, okResult.Value);
//        }

//        [Test]
//        public async Task GetOrdersByUserId_ShouldReturnOk_WhenOrdersExist()
//        {
//            var userId = "TestUser";
//            // Arrange
//            var orderDto = new OrderDTO
//            {
//                UserId = userId,
//                TotalAmount = 10.0m,
//                OrderStatus = "Pending",
//                OrderDate = DateTime.UtcNow
//            };

//            // Set up AutoMapper mock to map the DTO to the entity
//            var orderEntity = new Order
//            {
//                Id = 1,
//                UserId = userId,
//                TotalAmount = 10.0m,
//                OrderStatus = "Pending",
//                OrderDate = DateTime.UtcNow
//            };
//            mapper.Setup(m => m.Map<Order>(It.IsAny<OrderDTO>())).Returns(orderEntity);


//            // Simulate fetching orders by userId
//            //repository.GetOrdersByUserIdAsync(userId).ReturnsAsync(orders);

//            // Create controller
//            var controller = new OrderController(orderService, loggerController.Object);
//            await controller.PlaceOrder(orderDto);
//            // Act: Call the GetOrdersByUserId method
//            var result = await controller.GetOrdersByUserId(userId);

//            // Assert
//            Assert.IsNotNull(result);
//            //Assert.IsInstanceOf<OkObjectResult>(result);
//            var okResult = result as OkObjectResult;
//            //Assert.AreEqual(200, okResult.StatusCode);
//            //Assert.AreEqual(orders, okResult.Value);
//        }
//    }
//}
