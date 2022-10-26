using System.ComponentModel.DataAnnotations.Schema;

namespace Cenfotur.Entidad.DTOS.Output
{
    public class DataSP_O_DTO
    {
        public string Preguntas { get; set; }
        [Column("1")]
        public string Encuesta1 { get; set; }
        [Column("2")]
        public string Encuesta2 { get; set; }
    }
}