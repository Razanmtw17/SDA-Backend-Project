using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static SDA_Backend_Project.src.Entity.User;

namespace SDA_Backend_Project.src.DTO
{
    public class UserDTO
    {

        public class UserCreateDto
        {
            public string? Username { get; set; }
            public string? FirstName { get; set; }
            public string? LastName { get; set; }
            public string? Email { get; set; }
            public string? PhoneNumber { get; set; }
            public DateOnly? BirthDate { get; set; }
            public string? Password { get ; set ; }
            public UserRole? Role { get; internal set; }
            public Guid? CartId { get; set; }

            public static implicit operator UserCreateDto(string v)
            {
                throw new NotImplementedException();
            }
        }
        public class UserReadDto
        {
            public Guid UserId { get; set; }
            public string? Username { get; set; }
            public string? FirstName { get; set; }
            public string? LastName { get; set; }
            public string? Email { get; set; }
            public string? PhoneNumber { get; set; }
            public DateOnly BirthDate { get; set; }
            public UserRole Role { get; set; }
            public Guid CartId { get; set; }
             public string? Password { get ; set ; }
        }
        public class UserUpdateDto
        {
            public string? Username { get; set; }
            public string? FirstName { get; set; }
            public string? LastName { get; set; }
            public string? Email { get; set; }
            public string? PhoneNumber { get; set; }
            public DateOnly BirthDate { get; set; }
            public UserRole Role { get; set; }
            public string? Password { get ; set ; }
            public Guid? CartId { get; set; }
        }
    }
}