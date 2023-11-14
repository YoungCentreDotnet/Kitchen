using LinqToDB.Mapping;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Kitchen.Backend.Model
{
    public class Tables
    {
        [Identity]
        public int Id { get; set; }
        [Required]
        public string? Login { get; set; }
        [PasswordPropertyText]
        [MinLength(8)]
        [MaxLength(18)]          
        public string Password { get; set; }
    }
}
