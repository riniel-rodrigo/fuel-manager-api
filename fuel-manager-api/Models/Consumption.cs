using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace fuel_manager_api.Models
{
    [Table("Consumption ")]
    public class Consumption
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [Column(TypeName ="decimal(18,2)")]
        public decimal Value { get; set; }

        [Required]
        public FuelType Type { get; set; }

        [Required]
        public int VehicleId { get; set; }

        [ForeignKey("VehicleId")]
        public Vehicle Vehicle { get; set; }

    }

    public enum FuelType
    {
        Gasoline,
        Alcohol,
        Diesel
    }


}
