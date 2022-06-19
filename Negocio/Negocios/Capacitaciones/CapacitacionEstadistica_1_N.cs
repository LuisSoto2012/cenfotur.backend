// CapacitacionEstadistica_1_N.cs00:4900:49

using System.Collections.Generic;
using Cenfotur.Data.Datos.Capacitaciones;
using Cenfotur.Entidad.Entidades.Capacitaciones;

namespace Cenfotur.Negocio.Negocios.Capacitaciones
{
    public class CapacitacionEstadistica_1_N
    {
        public List<CapacitacionEstadistica_1_E> CapacitacionEstadistica_1(string Anio)
        {
            CapacitacionEstadistica_1_D obj = new();
            return obj.CapacitacionEstadistica_1(Anio);
        }
    }
}