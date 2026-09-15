using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;


namespace CookingPal.Model
{
    [Table("User")]
    public class User
    {

        [PrimaryKey][AutoIncrement]
        [Column("ID")]
        public int Id { get; set; }
        [Column("UserName")]
        public string? Name { get; set; }
        [Column("UserEmail")]
        public string? Email { get; set; }
        [Column("UserPassword")]
        public string? Password { get; set; }
        [Column("UserIngredients")]
        public string? UserIngredients { get; set; }

        // 🔐 Password hashing method
        public void SetPassword(string plainPassword)
        {
            using var sha = SHA256.Create();
            var hashedBytes = sha.ComputeHash(Encoding.UTF8.GetBytes(plainPassword));
            Password = Convert.ToBase64String(hashedBytes);
        }

        // ✅ Optional: method to verify login
        public bool VerifyPassword(string plainPassword)
        {
            using var sha = SHA256.Create();
            var hashedBytes = sha.ComputeHash(Encoding.UTF8.GetBytes(plainPassword));
            var hashedInput = Convert.ToBase64String(hashedBytes);
            return hashedInput == Password;
        }




    }
}
