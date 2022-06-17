// CursoEstadistica_1_E.cs19:1719:17

using System;
using System.Collections.Generic;
using System.Data;
using Cenfotur.Entidad.Entidades.Cursos;
using Microsoft.Data.SqlClient;

namespace Cenfotur.Data.Datos.Cursos
{
    public class CursoEstadistica_1_D : CadenaConexion
    {
        public List<CursoEstadistica_1_E> CursoEstadistica_1()
        {
            List<CursoEstadistica_1_E> Lista = new List<CursoEstadistica_1_E>();

            using (SqlConnection Conexion = new SqlConnection(Cadena))
            {
                try
                {
                    Conexion.Open();
                    using (SqlCommand cmd = new SqlCommand("Cursos_Estadistica_1", Conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlDataReader Reader = cmd.ExecuteReader(CommandBehavior.SingleResult); // SingleResult solo guarda memoria para un select
                        if (Reader != null)
                        {
                            Lista = new List<CursoEstadistica_1_E>();
                            CursoEstadistica_1_E oCursoEstadistica_1_E;

                            int Icon = Reader.GetOrdinal("Icon");
                            int Title = Reader.GetOrdinal("Title");
                            int Valor = Reader.GetOrdinal("Valor");

                            while (Reader.Read())
                            {
                                oCursoEstadistica_1_E = new CursoEstadistica_1_E();
                                oCursoEstadistica_1_E.Icon = Reader.IsDBNull(Icon) ? "" : Convert.ToString(Reader[Icon]);
                                oCursoEstadistica_1_E.Title = Reader.IsDBNull(Title) ? "" : Convert.ToString(Reader[Title]);
                                oCursoEstadistica_1_E.Valor = Reader.IsDBNull(Valor) ? "" : Convert.ToString(Reader[Valor]);

                                Lista.Add(oCursoEstadistica_1_E);
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