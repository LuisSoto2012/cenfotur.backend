// EmpleadoEstadistica_1_N.cs20:5920:59

using System.Collections.Generic;
using Cenfotur.Data.Datos.Empleados;
using Cenfotur.Entidad.Entidades.Empleados;

namespace Cenfotur.Negocio.Negocios.Empleados
{
    public class EmpleadoEstadistica_1_N
    {
        public List<EmpleadoEstadistica_1_E> EmpleadoEstadistica_1()
        {
            EmpleadoEstadistica_1_D obj = new();
            return obj.EmpleadoEstadistica_1();
        }
    }
}