namespace Cenfotur.Entidad.DTOS.Output
{
    public class EncuenstaDatos_O_DTO
    {
        public string Distrito { get; set; }
        public string Facilitador { get; set; }
        public bool EncuestaRegistrada { get; set; }

        public EncuenstaDatos_O_DTO(string distrito, string facilitador, bool encuestaRegistrada)
        {
            Distrito = distrito;
            Facilitador = facilitador;
            EncuestaRegistrada = encuestaRegistrada;
        }
    }
}