using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EncaladaD_ExamenProgreso_1.Models
{
    public class Recompensas
    {
        [Key]
        [Display(Name = "Id Recompensas")]
        public int recompensasId { get; set; }


        [Required]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }


        [DataType(DataType.Date)]
        [Display(Name = "Fecha Inicio")]
        public DateTime FechaInicio { get; set; }


        [Display(Name = "Puntos Acumulados")]
        public int puntosAcumulados { get; set; }

        [Required]
        [Display(Name = "Id del Cliente")]
        public string clienteId { get; set; }

        [ForeignKey("clienteId")]
        public Cliente? Cliente { get; set; }

        public string TipoRecompensa
        {
            get
            {
                return puntosAcumulados < 500 ? "SILVER" : "GOLD";
            }
        }

    }
}
