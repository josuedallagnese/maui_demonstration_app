using SQLite;
using System.ComponentModel.DataAnnotations;

namespace MauiDemonstrationApp.Models
{
    public class Customer
    {
        public Customer()
        {
        }

        public Customer(int id, string name, string email, string avatar)
        {
            Id = id;
            Name = name;
            Email = email;
            Avatar = avatar;
        }

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        public string Avatar { get; set; }
    }
}
