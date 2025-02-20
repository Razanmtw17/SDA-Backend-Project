using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SDA_Backend_Project.src.Entity;
using SDA_Backend_Project.src.Repository;
using SDA_Backend_Project.src.Utils;
using static SDA_Backend_Project.src.DTO.CartDTO;

namespace SDA_Backend_Project.src.Services.Cart
{
    public class CartService : ICartService
    {
         protected readonly CartRepository _cartRepo;
        protected readonly IMapper _mapper;
        public CartService(CartRepository cartRepo, IMapper mapper)
        {
            _cartRepo = cartRepo;
            _mapper = mapper;
        }

        public async Task<CartReadDto> CreateCartAsync(CartCreateDto createDto)
        {

            var cart = new SDA_Backend_Project.src.Entity.Cart
            {
                UserId = createDto.UserId,
                CartDetails = new List<CartDetails>(),
                CartQuantity = 0,
                TotalPrice = 0
            };
            foreach (var detailsDto in createDto.CartDetails)
            {
                //check if product exists
                var product = await _cartRepo.GetProductByIdForCartAsync(detailsDto.ProductId);

                if (product == null)
                    throw CustomException.NotFound($"Product with ID {detailsDto.ProductId} not found");

                // Create new CartDetails but reference the existing Product
                var cartDetails = new CartDetails
                {
                    Product = product,
                    Quantity = detailsDto.Quantity,
                    CartId = cart.Id
                };
                cart.CartDetails.Add(cartDetails);
            }
            var cartCreated = await _cartRepo.CreateCartAsync(cart);
            return _mapper.Map<SDA_Backend_Project.src.Entity.Cart, CartReadDto>(cartCreated);
        }

        public async Task<bool> DeleteCartByIdAsync(Guid id)
        {
            var foundCart = await _cartRepo.GetCartByIdAsync(id);

            if (foundCart == null)
                throw CustomException.NotFound($"Cart with ID {id} not found");

            bool isDeleted = await _cartRepo.DeleteCartAsync(foundCart);
            return isDeleted;
        }

        public async Task<CartReadDto> GetCartByIdAsync(Guid id)
        {
            var foundCart = await _cartRepo.GetCartByIdAsync(id);

            if (foundCart == null)
                throw CustomException.NotFound($"Cart with ID {id} not found");

            return _mapper.Map<SDA_Backend_Project.src.Entity.Cart, CartReadDto>(foundCart);
        }

        public async Task<List<CartReadDto>> GetCartsAsync()
        {
            var carts = await _cartRepo.GetAllCartsAsync();
            return _mapper.Map<List<SDA_Backend_Project.src.Entity.Cart>, List<CartReadDto>>(carts);
        }

        public async Task<CartReadDto> UpdateCartAsync(Guid id, CartUpdateDto updateDto)
        {

            var foundCart = await _cartRepo.GetCartByIdAsync(id);

            if (foundCart == null)
                throw CustomException.NotFound($"Cart with ID {id} not found");

            foundCart.CartDetails.Clear();


            foreach (var detailsDto in updateDto.CartDetails)
            {

                var product = await _cartRepo.GetProductByIdForCartAsync(detailsDto.ProductId);

                if (product == null)
                    throw CustomException.NotFound($"Product with ID {detailsDto.ProductId} not found");

                var cartDetails = new CartDetails
                {
                    Product = product,
                    Quantity = detailsDto.Quantity,
                    CartId = foundCart.Id
                };
                foundCart.CartDetails.Add(cartDetails);
            }

            //_mapper.Map(updateDto, foundCart); //this line was causing an error

            var updatedCart = await _cartRepo.UpdateCartAsync(foundCart);

            if (updatedCart == null)
                throw CustomException.NotFound($"Cart with ID {id} not found");

            return _mapper.Map<SDA_Backend_Project.src.Entity.Cart, CartReadDto>(updatedCart);
        }


    }
}