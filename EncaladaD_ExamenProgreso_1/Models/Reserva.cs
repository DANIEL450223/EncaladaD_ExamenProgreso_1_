using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EncaladaD_ExamenProgreso_1.Models
{
    public class Reserva
    {
        [Key]
        [Display(Name = "Id Reserva")]
        public int reservaId { get; set; }


        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Entrada")]
        public DateTime fechaEntrada { get; set; }


        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Salida")]
        public DateTime fechaSalida { get; set; }



        [Range(0, 10000)]
        [Display(Name = "Valor a pagar")]
        public decimal valorPagar { get; set; }


        [Required]
        [Display(Name = "Id del Cliente")]
        public string clienteId { get; set; }

        [ForeignKey("clienteId")]
        public Cliente? Cliente { get; set; }
    }
}
