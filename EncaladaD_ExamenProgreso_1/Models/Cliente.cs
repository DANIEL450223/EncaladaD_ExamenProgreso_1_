using System.ComponentModel.DataAnnotations;

namespace EncaladaD_ExamenProgreso_1.Models
{
    public class Cliente
    {
        [Key]
        [MaxLength(15)]
        [Display(Name = "Codigo del Cliente")]
        public string clienteId { get; set; }


        [Required]
        [MaxLength(100)]
        [Display(Name = "Nombre Cliente")]
        public string nombreCliente { get; set; }


        [Display(Name = "Numero Telefonico Cliente")]
        public int numeroTelefono { get; set; }


        [Required]
        [Display(Name = "Membresia")]
        public bool esMiembro { get; set; }


        [Display(Name = "Fecha de registro")]
        [DataType(DataType.Date)]
        public DateTime fechaRegistro { get; set; }


        [Required]
        [Range(0, 10000)]
        [Display(Name = "Pagos Realizados del cliente")]
        public decimal pagosRealizado { get; set; }



        public ICollection<Reserva>? Reservas { get; set; }

    }
}
