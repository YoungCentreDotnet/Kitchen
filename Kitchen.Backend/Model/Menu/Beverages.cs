using LinqToDB.Mapping;
using System.ComponentModel.DataAnnotations;

namespace Kitchen.Backend.Model.Menu
{
    public class Beverages
    {
        [Identity]
        public int Id { get; set; }
        [Required]
        public string? Type { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int Number { get; set; }
        [Required]
        public int Litr { get; set; }
        [Required]
        public string? Discreption { get; set; }
        
    }
}
