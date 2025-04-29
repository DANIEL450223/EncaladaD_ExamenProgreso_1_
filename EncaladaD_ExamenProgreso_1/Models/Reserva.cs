using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EncaladaD_ExamenProgreso_1.Models
{
    public class Reserva
    {
        [Key]
        public int reservaId { get; set; }


        [Required]
        [DataType(DataType.Date)]
        public DataType fechaEntrada { get; set; }


        [Required]
        [DataType(DataType.Date)]
        public DataType fechaSalida { get; set; }


        [Required]
        public decimal valorPagar { get; set; }

        public string clienteId { get; set; }
        [ForeignKey("clienteId")]
        public Cliente? Cliente { get; set; }
    }
}
