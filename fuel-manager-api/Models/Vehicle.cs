using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace fuel_manager_api.Models
{
    [Table("Vehicle")]
    public class Vehicle
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Mark { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public string Plate { get; set; }

        [Required]
        public int YearFab { get; set; }

        [Required]
        public int YearModel { get; set; }

        public ICollection<Consumption> Consumptions { get; set; }
    }
}