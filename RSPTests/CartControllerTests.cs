using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Moq;
using RSP.Controllers;
using RSP.Dtos;
using RSP.Models;
using RSP.Repositories;
using Xunit;
using Xunit.Sdk;

namespace RSPTests
{
    public class CartControllerTests
    {
        [Fact]
        public async Task AddItemToCart_ThrowsException_WithNonExistingItem()
        {
            var userMockRepo = GetMockUserManager();
            var itemMockRepo = new Mock<IItemRepository>();
            var cartItemMockRepo = new Mock<ICartItemRepository>();
            itemMockRepo.Setup(repo => repo
                    .GetSingleItem(1))
                .ReturnsAsync((ItemDto)null);

            var cartController = new CartController(
                userMockRepo.Object,
                cartItemMockRepo.Object,
                itemMockRepo.Object
            );

            // Assert
            await Assert.ThrowsAsync<Exception>(() => cartController.AddItemToCart(1, It.IsAny<int>()));
        }

        private static Mock<UserManager<User>> GetMockUserManager()
        {
            var userStoreMock = new Mock<IUserStore<User>>();
            return new Mock<UserManager<User>>(
                userStoreMock.Object, null, null, null, null, null, null, null, null);
        }
    }
}
