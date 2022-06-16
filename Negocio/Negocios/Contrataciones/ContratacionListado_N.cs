using Cenfotur.Data.Contrataciones;
using Cenfotur.Entidad.Entidades.Contrataciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cenfotur.Negocio.Negocios.Contrataciones
{
    public class ContratacionListado_N
    {
        public List<ContratacionListado_E> ListaContratacionListado(string Anio)
        {
            ContratacionListado_D obj = new();
            return obj.ListaContratacionListado(Anio);
        }
    }
}
