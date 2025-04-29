using System.ComponentModel.DataAnnotations;

namespace EncaladaD_ExamenProgreso_1.Models
{
    public class Cliente
    {
        [Key]
        [MaxLength(15)]
        public string clienteId { get; set; }


        [Required]
        [MaxLength(100)]
        public string nombreCliente { get; set; }


        public int numeroTelefono { get; set; }


        [Required]
        public bool esMiembro { get; set; }


        [DataType(DataType.Date)]
        public DateTime fechaRegistro { get; set; }


        [Required]
        [Range(0, 10000)]
        public decimal pagosRealizado { get; set; }



        public ICollection<Reserva>? Reservas { get; set; }

    }
}
