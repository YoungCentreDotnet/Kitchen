using LinqToDB.Mapping;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Kitchen.Backend.Model
{
    public class User
    {
        [Identity]
        public int Id { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        [EmailAddress]
        public string? Login { get; set; }
        [PasswordPropertyText]
        [MaxLength(18)]          
        public string? Password { get; set; }
    }
}
