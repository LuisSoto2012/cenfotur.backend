using System;
using System.Collections.Generic;
using System.Data;
using Cenfotur.Entidad.Entidades.FichaSupervision;
using Cenfotur.Entidad.Models;
using Microsoft.Data.SqlClient;

namespace Cenfotur.Data.Datos.FichaSupervision
{
    public class FichaSupervision_1_D : CadenaConexion
    {
        public List<FichaSupervision_1_E> FichaSupervision_1(string anio)
        {
            List<FichaSupervision_1_E> Lista = new List<FichaSupervision_1_E>();

            using (SqlConnection Conexion = new SqlConnection(Cadena))
            {
                try
                {
                    Conexion.Open();
                    using (SqlCommand cmd = new SqlCommand("FichasSupervision_Estadistica_1", Conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        //Se configura cada parametro del SP
                        cmd.Parameters.Add("@Anio", SqlDbType.Int).Value = anio;


                        SqlDataReader Reader = cmd.ExecuteReader(CommandBehavior.SingleResult); // SingleResult solo guarda memoria para un select
                        if (Reader != null)
                        {
                            Lista = new List<FichaSupervision_1_E>();
                            FichaSupervision_1_E oCapacitacionEstadistica_1_E;

                            int Icon = Reader.GetOrdinal("Icon");
                            int Title = Reader.GetOrdinal("Title");
                            int Valor = Reader.GetOrdinal("Valor");
                           


                            while (Reader.Read())
                            {
                                oCapacitacionEstadistica_1_E = new FichaSupervision_1_E();
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