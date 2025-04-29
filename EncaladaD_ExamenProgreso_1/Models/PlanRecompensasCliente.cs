using System.ComponentModel.DataAnnotations;

namespace EncaladaD_ExamenProgreso_1.Models
{
    public class PlanRecompensasCliente
    {
        [Key]
        public int recompensasId { get; set; }


        [Required]
        public string nombre { get; set; }


        [DataType(DataType.Date)]
        public DateTime FechaInicio { get; set; }


        public int puntosAcumulados { get; set; }


        public string TipoRecompensa
        {
            get
            {
                return puntosAcumulados < 500 ? "SILVER" : "GOLD";
            }
        }

    }
}
