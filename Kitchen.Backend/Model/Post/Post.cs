using LinqToDB.Mapping;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Kitchen.Backend.Model.Post
{
    public class Post
    {
        [Identity]
        public int Id { get; set; }
        [Required]
        public string? PostFoto { get; set; } 
        [Required]
        public string? Descreption { get; set; }
        
    }
}
