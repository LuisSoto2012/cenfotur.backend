// CapacitacionEstadistica_1_D.cs00:5000:50

using System;
using System.Collections.Generic;
using System.Data;
using Cenfotur.Entidad.Entidades.Capacitaciones;
using Microsoft.Data.SqlClient;

namespace Cenfotur.Data.Datos.Capacitaciones
{
    public class CapacitacionEstadistica_1_D : CadenaConexion
    {
        public List<CapacitacionEstadistica_1_E> CapacitacionEstadistica_1(string Anio)
        {
            List<CapacitacionEstadistica_1_E> Lista = new List<CapacitacionEstadistica_1_E>();

            using (SqlConnection Conexion = new SqlConnection(Cadena))
            {
                try
                {
                    Conexion.Open();
                    using (SqlCommand cmd = new SqlCommand("Capacitaciones_Estadistica_1", Conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        //Se configura cada parametro del SP
                        cmd.Parameters.Add("@Anio", SqlDbType.Int).Value = Anio;


                        SqlDataReader Reader = cmd.ExecuteReader(CommandBehavior.SingleResult); // SingleResult solo guarda memoria para un select
                        if (Reader != null)
                        {
                            Lista = new List<CapacitacionEstadistica_1_E>();
                            CapacitacionEstadistica_1_E oCapacitacionEstadistica_1_E;

                            int Icon = Reader.GetOrdinal("Icon");
                            int Title = Reader.GetOrdinal("Title");
                            int Valor = Reader.GetOrdinal("Valor");
                           


                            while (Reader.Read())
                            {
                                oCapacitacionEstadistica_1_E = new CapacitacionEstadistica_1_E();
                                oCapacitacionEstadistica_1_E.Icon = Reader.IsDBNull(Icon) ? "" : Convert.ToString(Reader[Icon]);
                                oCapacitacionEstadistica_1_E.Title = Reader.IsDBNull(Title) ? "" : Convert.ToString(Reader[Title]);
                                oCapacitacionEstadistica_1_E.Valor = Reader.IsDBNull(Valor) ? "" : Convert.ToString(Reader[Valor]);
                                //oCapacitacionEstadistica_1_E.CantAdministrativos = Reader.IsDBNull(CantAdministrativos) ? "" : Convert.ToString(Reader[CantAdministrativos]);

                                Lista.Add(oCapacitacionEstadistica_1_E);
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