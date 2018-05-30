using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
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
            var userMockRepo = new Mock<FakeUserManager>();
            var itemMockRepo = new Mock<IItemRepository>();
            var cartItemMockRepo = new Mock<ICartItemRepository>();

            userMockRepo.Setup(repo => repo
                .FindByNameAsync("abc"))
                .ReturnsAsync(new User { Id = "abc" });
            itemMockRepo.Setup(repo => repo
                .GetSingleItem(1))
                .ReturnsAsync((ItemDto)null);

            var cartController = new CartController(
                userMockRepo.Object,
                cartItemMockRepo.Object,
                itemMockRepo.Object
            )
            {
                GetUserName = () => "abc"
            };

            // Assert
            await Assert.ThrowsAsync<Exception>(() => cartController.AddItemToCart(1, It.IsAny<int>()));
        }

        [Fact]
        public async Task AddItemToCart_ReturnsView_ExistingItem()
        {
            var userMockRepo = new Mock<FakeUserManager>();
            var itemMockRepo = new Mock<IItemRepository>();
            var cartItemMockRepo = new Mock<ICartItemRepository>();

            userMockRepo.Setup(repo => repo
                .FindByNameAsync("abc"))
                .ReturnsAsync(new User{ Id = "abc" });
            itemMockRepo.Setup(repo => repo
                .GetSingleItem(1))
                .ReturnsAsync(new ItemDto());
            cartItemMockRepo.Setup(repo => repo
                .GetCartItem(It.IsAny<int>(), It.IsAny<string>()))
                .ReturnsAsync(new CartItemDto());

            var cartController = new CartController(
                userMockRepo.Object,
                cartItemMockRepo.Object,
                itemMockRepo.Object
            )
            {
                GetUserName = () => "abc"
            };

            var result = await cartController.AddItemToCart(1, It.IsAny<int>());

            // Assert
            Assert.Equal("ItemDetails", result.ActionName);
        }

        [Fact]
        public async Task AddItemToCart_CallsCreateOnce_NoItemFound()
        {
            var userMockRepo = new Mock<FakeUserManager>();
            var itemMockRepo = new Mock<IItemRepository>();
            var cartItemMockRepo = new Mock<ICartItemRepository>();

            userMockRepo.Setup(repo => repo
                .FindByNameAsync("abc"))
                .ReturnsAsync(new User { Id = "abc" });
            itemMockRepo.Setup(repo => repo
                .GetSingleItem(1))
                .ReturnsAsync(new ItemDto());
            cartItemMockRepo.Setup(repo => repo
                .GetCartItem(It.IsAny<int>(), It.IsAny<string>()))
                .ReturnsAsync((CartItemDto)null);
            var cartController = new CartController(
                userMockRepo.Object,
                cartItemMockRepo.Object,
                itemMockRepo.Object
            )
            {
                GetUserName = () => "abc"
            };

            await cartController.AddItemToCart(1, It.IsAny<int>());
            cartItemMockRepo.Verify(mock => mock.Create(It.IsAny<Cart_Item>()), Times.Once());
        }

        [Fact]
        public async Task AddItemToCart_CallsEditOnce_ExistingItem()
        {
            var userMockRepo = new Mock<FakeUserManager>();
            var itemMockRepo = new Mock<IItemRepository>();
            var cartItemMockRepo = new Mock<ICartItemRepository>();

            userMockRepo.Setup(repo => repo
                    .FindByNameAsync("abc"))
                .ReturnsAsync(new User { Id = "abc" });
            itemMockRepo.Setup(repo => repo
                    .GetSingleItem(1))
                .ReturnsAsync(new ItemDto());
            cartItemMockRepo.Setup(repo => repo
                    .GetCartItem(It.IsAny<int>(), It.IsAny<string>()))
                .ReturnsAsync(new CartItemDto());
            var cartController = new CartController(
                userMockRepo.Object,
                cartItemMockRepo.Object,
                itemMockRepo.Object
            )
            {
                GetUserName = () => "abc"
            };

            await cartController.AddItemToCart(1, It.IsAny<int>());
            cartItemMockRepo.Verify(mock => mock.EditCartItem(It.IsAny<int>(), It.IsAny<int>()), Times.Once());
        }
    }
}
