using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace SDA_Backend_Project.src.Entity
{
    public class User
    {
         public Guid UserId { get; set; }
        public string? Username { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateOnly BirthDate { get; set; }
         public UserRole? Role { get; set; } 
        public string? Password { get ; set ; }
        public byte[]? Salt { get; set; }
        public Guid? CartId { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public enum UserRole
        {
            Admin,
            Customer
        }
    }
}