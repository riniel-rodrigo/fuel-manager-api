using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace fuel_manager_api.Models
{
    [Table("Consum")]
    public class Consum
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Desc { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public decimal Value { get; set; }

        [Required]
        public FuelType Type { get; set; }

        [Required]
        public int VeiculoId { get; set; }

        public Vehicle Vehicle { get; set; }

    }

    public enum FuelType
    {
        Gasoline,
        Alcohol,
        Diesel
    }


}
