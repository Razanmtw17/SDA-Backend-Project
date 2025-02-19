using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;

namespace SDA_Backend_Project.src.Utils
{
    public class PasswordUtils
    {
        public static void HashPassword(string originalPassword , out string hashedPassword , out byte[] salt )
        {
            var hmac = new HMACSHA256();
            salt = hmac.Key;
            hashedPassword = BitConverter.ToString(hmac.ComputeHash(Encoding.UTF8.GetBytes(originalPassword)));
        }
        public static bool VerifyPassword(string originalPassword, string hashedPassword , byte[] salt )
        {
            var hmac = new HMACSHA256(salt);
            return BitConverter.ToString(hmac.ComputeHash(Encoding.UTF8.GetBytes(originalPassword))) == hashedPassword;
        }
    }
}