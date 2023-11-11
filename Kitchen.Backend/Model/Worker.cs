using LinqToDB.Mapping;
using System.ComponentModel.DataAnnotations;

namespace Kitchen.Backend.Model
{
    public class Worker
    {
        [Identity]
        public int Id { get; set; }
        [Required]
        public string? FirsName { get; set; }
        [Required]
        public string? LastName { get; set; }
        public DateTime  WorkAppointmentDay { get; set; }

    }
}
