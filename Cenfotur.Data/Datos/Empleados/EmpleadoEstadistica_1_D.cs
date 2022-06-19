// EmpleadoEstadistica_1_D.cs21:0021:00

using System;
using System.Collections.Generic;
using System.Data;
using Cenfotur.Entidad.Entidades.Empleados;
using Microsoft.Data.SqlClient;

namespace Cenfotur.Data.Datos.Empleados
{
    public class EmpleadoEstadistica_1_D : CadenaConexion
    {
        public List<EmpleadoEstadistica_1_E> EmpleadoEstadistica_1()
        {
            List<EmpleadoEstadistica_1_E> Lista = new List<EmpleadoEstadistica_1_E>();

            using (SqlConnection Conexion = new SqlConnection(Cadena))
            {
                try
                {
                    Conexion.Open();
                    using (SqlCommand cmd = new SqlCommand("Empleados_Estadistica_1", Conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        
                        SqlDataReader Reader = cmd.ExecuteReader(CommandBehavior.SingleResult); // SingleResult solo guarda memoria para un select
                        if (Reader != null)
                        {
                            Lista = new List<EmpleadoEstadistica_1_E>();
                            EmpleadoEstadistica_1_E oEmpleadoEstadistica_1_E;

                            int Icon = Reader.GetOrdinal("Icon");
                            int Title = Reader.GetOrdinal("Title");
                            int Valor = Reader.GetOrdinal("Valor");
                           


                            while (Reader.Read())
                            {
                                oEmpleadoEstadistica_1_E = new EmpleadoEstadistica_1_E();
                                oEmpleadoEstadistica_1_E.Icon = Reader.IsDBNull(Icon) ? "" : Convert.ToString(Reader[Icon]);
                                oEmpleadoEstadistica_1_E.Title = Reader.IsDBNull(Title) ? "" : Convert.ToString(Reader[Title]);
                                oEmpleadoEstadistica_1_E.Valor = Reader.IsDBNull(Valor) ? "" : Convert.ToString(Reader[Valor]);

                                Lista.Add(oEmpleadoEstadistica_1_E);
                            }
                            Conexion.Close();

                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }

            }

            return Lista;

        }
    }
}