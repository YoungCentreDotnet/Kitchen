using LinqToDB.Mapping;
using LinqToDB.SqlQuery;
using System.ComponentModel.DataAnnotations;

namespace Kitchen.Backend.Model.Stock
{
    public class KgProduct
    {
        [Identity]
        public int Id { get; set; }
        [Required]
        public string? ProductName { get; set; }
        [Required]
        public DateTimeOffset DateReceived { get; set; }
        [Required]
        public DateTimeOffset StorageDate { get; set; }
        [Required]
        public int Number { get; set; }
    }
}
