using Cenfotur.Entidad.Entidades.Contrataciones;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cenfotur.Data.Datos.Contrataciones
{
    public class ContratacionEstadistica_1_D : CadenaConexion
    {
        public List<ContratacionEstadistica_1_E> ContratacionEstadistica_1(string Anio)
        {
            List<ContratacionEstadistica_1_E> Lista = new List<ContratacionEstadistica_1_E>();

            using (SqlConnection Conexion = new SqlConnection(Cadena))
            {
                try
                {
                    Conexion.Open();
                    using (SqlCommand cmd = new SqlCommand("ContratacionesPersonal_Estadistica_1", Conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        //Se configura cada parametro del SP
                        cmd.Parameters.Add("@Anio", SqlDbType.Int).Value = Anio;


                        SqlDataReader Reader = cmd.ExecuteReader(CommandBehavior.SingleResult); // SingleResult solo guarda memoria para un select
                        if (Reader != null)
                        {
                            Lista = new List<ContratacionEstadistica_1_E>();
                            ContratacionEstadistica_1_E oContratacionEstadistica_1_E;

                            int Icon = Reader.GetOrdinal("Icon");
                            int Title = Reader.GetOrdinal("Title");
                            int Valor = Reader.GetOrdinal("Valor");
                           


                            while (Reader.Read())
                            {
                                oContratacionEstadistica_1_E = new ContratacionEstadistica_1_E();
                                oContratacionEstadistica_1_E.Icon = Reader.IsDBNull(Icon) ? "" : Convert.ToString(Reader[Icon]);
                                oContratacionEstadistica_1_E.Title = Reader.IsDBNull(Title) ? "" : Convert.ToString(Reader[Title]);
                                oContratacionEstadistica_1_E.Valor = Reader.IsDBNull(Valor) ? "" : Convert.ToString(Reader[Valor]);
                                //oContratacionEstadistica_1_E.CantAdministrativos = Reader.IsDBNull(CantAdministrativos) ? "" : Convert.ToString(Reader[CantAdministrativos]);

                                Lista.Add(oContratacionEstadistica_1_E);
                            }
                            Conexion.Close();

                        }
                    }
                }
                catch (Exception)
                {
                    throw;
                }

            }

            return Lista;

        }
    }
}
