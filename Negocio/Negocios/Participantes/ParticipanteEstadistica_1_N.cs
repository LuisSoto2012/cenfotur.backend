using System.Collections.Generic;
using Cenfotur.Data.Datos.Empleados;
using Cenfotur.Data.Datos.Participantes;
using Cenfotur.Entidad.Entidades.Participantes;

namespace Cenfotur.Negocio.Negocios.Participantes
{
    public class ParticipanteEstadistica_1_N
    {
        public List<ParticipanteEstadistica_1_E> ParticipanteEstadistica_1(int idCapacitacion)
        {
            ParticipanteEstadistica_1_D obj = new();
            return obj.ParticipanteEstadistica_1(idCapacitacion);
        }
    }
}