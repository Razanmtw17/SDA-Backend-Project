using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static SDA_Backend_Project.src.DTO.UserDTO;

namespace SDA_Backend_Project.src.Services.user
{
    public interface IUserService
    {
        Task<UserReadDto> CreateOneAsync(UserCreateDto createDto);
        // get all
        Task<List<UserReadDto>> GetAllAsync();
        // get by id
        Task<UserReadDto> GetByIdAsync(Guid id);
        // delete 
        Task<bool> DeleteOneAsync(Guid id);
        // update
        Task<bool> UpdateOneAsync(Guid id , UserUpdateDto updateDto);
        Task<string> SignInAsync(UserCreateDto createDto);

    }
}