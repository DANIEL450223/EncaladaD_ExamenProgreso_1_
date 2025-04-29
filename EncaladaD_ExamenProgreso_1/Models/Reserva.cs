using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EncaladaD_ExamenProgreso_1.Models
{
    public class Reserva
    {
        [Key]
        [MaxLength(15)]
        public int reservaId { get; set; }


        [Required]
        [DataType(DataType.Date)]
        public DataType fechaEntrada { get; set; }


        [Required]
        [DataType(DataType.Date)]
        public DataType fechaSalida { get; set; }


        [Required]
        [Range(0, 10000)]
        public decimal valorPagar { get; set; }


        [Required]
        [MaxLength(15)]
        public string clienteId { get; set; }

        [ForeignKey("clienteId")]
        public Cliente? Cliente { get; set; }
    }
}
