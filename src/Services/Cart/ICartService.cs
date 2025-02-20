using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static SDA_Backend_Project.src.DTO.CartDTO;

namespace SDA_Backend_Project.src.Services.Cart
{
    public interface ICartService
    {
         //create new cart
        Task<CartReadDto> CreateCartAsync(CartCreateDto createDto);

        //get all carts
        Task<List<CartReadDto>> GetCartsAsync();

        //get cart by id
        Task<CartReadDto> GetCartByIdAsync(Guid id);

        //delete cart
        Task<bool> DeleteCartByIdAsync(Guid id);

        //update cart
        Task<CartReadDto> UpdateCartAsync(Guid id, CartUpdateDto updateDto);
    }
}