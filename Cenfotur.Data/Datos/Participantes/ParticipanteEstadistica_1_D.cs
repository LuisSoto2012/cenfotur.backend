using System;
using System.Collections.Generic;
using System.Data;
using Cenfotur.Entidad.Entidades.Empleados;
using Cenfotur.Entidad.Entidades.Participantes;
using Microsoft.Data.SqlClient;

namespace Cenfotur.Data.Datos.Participantes
{
    public class ParticipanteEstadistica_1_D : CadenaConexion
    {
        public List<ParticipanteEstadistica_1_E> ParticipanteEstadistica_1(int idCapacitacion)
        {
            List<ParticipanteEstadistica_1_E> Lista = new List<ParticipanteEstadistica_1_E>();

            using (SqlConnection Conexion = new SqlConnection(Cadena))
            {
                try
                {
                    Conexion.Open();
                    using (SqlCommand cmd = new SqlCommand("Participantes_Estadistica_1", Conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        //Se configura cada parametro del SP
                        cmd.Parameters.Add("@IdCapacitacion", SqlDbType.Int).Value = idCapacitacion;
                        
                        SqlDataReader Reader = cmd.ExecuteReader(CommandBehavior.SingleResult); // SingleResult solo guarda memoria para un select
                        if (Reader != null)
                        {
                            Lista = new List<ParticipanteEstadistica_1_E>();
                            ParticipanteEstadistica_1_E oParticipanteEstadistica_1_E;

                            int Icon = Reader.GetOrdinal("Icon");
                            int Title = Reader.GetOrdinal("Title");
                            int Valor = Reader.GetOrdinal("Valor");
                           


                            while (Reader.Read())
                            {
                                oParticipanteEstadistica_1_E = new ParticipanteEstadistica_1_E();
                                oParticipanteEstadistica_1_E.Icon = Reader.IsDBNull(Icon) ? "" : Convert.ToString(Reader[Icon]);
                                oParticipanteEstadistica_1_E.Title = Reader.IsDBNull(Title) ? "" : Convert.ToString(Reader[Title]);
                                oParticipanteEstadistica_1_E.Valor = Reader.IsDBNull(Valor) ? "" : Convert.ToString(Reader[Valor]);

                                Lista.Add(oParticipanteEstadistica_1_E);
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