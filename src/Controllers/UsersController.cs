using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SDA_Backend_Project.src.Services.user;
using SDA_Backend_Project.src.Utils;
using static SDA_Backend_Project.src.DTO.UserDTO;

namespace SDA_Backend_Project.src.Controllers
{  
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UsersController  : ControllerBase
    {
         protected readonly IUserService _userService;

        public UsersController(IUserService service)
        {
            _userService = service;
        }
        // create user
        [HttpPost("register")]
        public async Task<ActionResult<UserReadDto>> CreateOne(UserCreateDto createDto)
        {
            var userCreated = await _userService.CreateOneAsync(createDto);
            return Ok(userCreated);
        }
        
        // log in
        [HttpPost("signIn")]
        public async Task<ActionResult<string>> SignInUser([FromBody] UserCreateDto createDto)
        {
            var token = await _userService.SignInAsync(createDto);
            return Ok(token);
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<UserReadDto>>> GetAllUsers()
        {
            var userList = await _userService.GetAllAsync();
           
                return Ok(userList);
            
        }
        [HttpGet("{userId}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<UserReadDto>> GetOrderById([FromRoute] Guid userId)
        {
            var foundUser = await _userService.GetByIdAsync(userId);
            if (foundUser == null)
            {
                throw CustomException.BadRequest("User not found");
            }
            return Ok(foundUser);
        }
        [HttpDelete("{userId}")]
        public async Task<ActionResult> DeleteUser(Guid userId)
        {
            var foundUser = await _userService.GetByIdAsync(userId);
            if (foundUser == null)
                throw CustomException.UnAuthorized($"user with {userId}  doesnt exist");

            var isDeleted = await _userService.DeleteOneAsync(userId);
            return isDeleted ? Ok("user deleted seccsufully") : StatusCode(500);
        }
         
        [HttpPut("{userId}")]
        public async Task<ActionResult<UserReadDto>> UpdateUser(Guid userId, UserUpdateDto updateDto)
        {
            var userRead = await _userService.UpdateOneAsync(userId, updateDto);
            return Ok($"{userRead} Updated seccussfuly");
        }
        [HttpGet("auth")]
        [Authorize]
        public async Task<ActionResult<UserReadDto>> CheckAuthAsync()
        {
            var authenticatedClaims = HttpContext.User;
            var userId = authenticatedClaims.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!.Value;
            var userGuid = new Guid(userId);
            var user = await _userService.GetByIdAsync(userGuid);
            return Ok(user);
        }
        
    }

    
}