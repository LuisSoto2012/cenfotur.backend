using Cenfotur.Data.Datos.Contrataciones;
using Cenfotur.Entidad.Entidades.Contrataciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cenfotur.Negocio.Negocios.Contrataciones
{
    public class ContratacionEstadistica_1_N
    {
        public List<ContratacionEstadistica_1_E> ContratacionEstadistica_1(string Anio)
        {
            ContratacionEstadistica_1_D obj = new();
            return obj.ContratacionEstadistica_1(Anio);
        }
    }
}
