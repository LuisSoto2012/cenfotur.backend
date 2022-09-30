using System.Collections.Generic;
using Cenfotur.Data.Datos.FichaSupervision;
using Cenfotur.Entidad.Entidades.FichaSupervision;
using Cenfotur.Entidad.Models;

namespace Cenfotur.Negocio.Negocios.FichaSupervision
{
    public class FichaSupervision_1_N
    {
        public List<FichaSupervision_1_E> FichaSupervision_1(string anio)
        {
            FichaSupervision_1_D obj = new();
            return obj.FichaSupervision_1(anio);
        }
    }
}