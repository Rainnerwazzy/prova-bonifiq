using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ProvaPub.Infrastructure;
using ProvaPub.Interfaces;
using ProvaPub.Models;
using ProvaPub.Services;

namespace ProvaPub.Tests
{
    [TestClass]
    public class CustomerServiceTests
    {
        [TestMethod]
        public async Task CanPurchaseAsync_ValidCustomerAndPurchaseValue_ReturnsTrue()
        {
            
            var dbContextMock = new Mock<TestDbContext>();
            var paginationServiceMock = new Mock<IPaginationService>();

            dbContextMock.Setup(db => db.Customers.FindAsync(It.IsAny<int>()))
                .ReturnsAsync(new Customer()); 

            var customerService = new CustomerService(dbContextMock.Object, paginationServiceMock.Object);
            
            var result = await customerService.CanPurchaseAsync(1, 50);           
            Assert.IsTrue(result);
        }

        [TestMethod]
        public async Task CanPurchaseAsync_InvalidCustomerId_ThrowsException()
        {
          
            var dbContextMock = new Mock<TestDbContext>();
            var paginationServiceMock = new Mock<IPaginationService>();

            var customerService = new CustomerService(dbContextMock.Object, paginationServiceMock.Object);

            
            await Assert.ThrowsExceptionAsync<ArgumentOutOfRangeException>(async () =>
            {
                await customerService.CanPurchaseAsync(0, 50);
            });
        }

        [TestMethod]
        public async Task CanPurchaseAsync_InvalidPurchaseValue_ThrowsException()
        {
            
            var dbContextMock = new Mock<TestDbContext>();
            var paginationServiceMock = new Mock<IPaginationService>();

            var customerService = new CustomerService(dbContextMock.Object, paginationServiceMock.Object);
            
            await Assert.ThrowsExceptionAsync<ArgumentOutOfRangeException>(async () =>
            {
                await customerService.CanPurchaseAsync(1, -10); 
            });
        }

        [TestMethod]
        public async Task CanPurchaseAsync_CustomerNotRegistered_ReturnsFalse()
        {
           
            var dbContextMock = new Mock<TestDbContext>();
            var paginationServiceMock = new Mock<IPaginationService>();

            dbContextMock.Setup(db => db.Customers.FindAsync(It.IsAny<int>()))
                .ReturnsAsync((Customer)null); 

            var customerService = new CustomerService(dbContextMock.Object, paginationServiceMock.Object);
            var result = await customerService.CanPurchaseAsync(1, 50);
            Assert.IsFalse(result);
        }

    }
}
