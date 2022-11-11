using Cenfotur.Entidad.Entidades.Contrataciones;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cenfotur.Data.Contrataciones
{
    public class ContratacionListado_D : CadenaConexion
    {
        public List<ContratacionListado_E> ListaContratacionListado(string Anio)
        {
            List<ContratacionListado_E> Lista = new List<ContratacionListado_E>();

            using (SqlConnection Conexion = new SqlConnection(Cadena))
            {
                try
                {
                    Conexion.Open();
                    using (SqlCommand cmd = new SqlCommand("ContratacionesPersonal_Listado_1", Conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        //Se configura cada parametro del SP
                        cmd.Parameters.Add("@Anio", SqlDbType.Int).Value = Anio;


                        SqlDataReader Reader = cmd.ExecuteReader(CommandBehavior.SingleResult); // SingleResult solo guarda memoria para un select
                        if (Reader != null)
                        {
                            Lista = new List<ContratacionListado_E>();
                            ContratacionListado_E oContratacionListado_E;

                            int EmpleadoId = Reader.GetOrdinal("EmpleadoId");
                            int ApellidoPaterno = Reader.GetOrdinal("ApellidoPaterno");
                            int ApellidoMaterno = Reader.GetOrdinal("ApellidoMaterno");
                            int Nombres = Reader.GetOrdinal("Nombres");
                            int SexoId = Reader.GetOrdinal("SexoId");
                            int TelefMovil = Reader.GetOrdinal("TelefMovil");
                            int Correo = Reader.GetOrdinal("Correo");
                            int TipoDocumentoId = Reader.GetOrdinal("TipoDocumentoId");
                            int TipoDocAbrevNombre = Reader.GetOrdinal("TipoDocAbrevNombre");
                            int NumDoc = Reader.GetOrdinal("NumDoc");
                            int FechaNacimiento = Reader.GetOrdinal("FechaNacimiento");

                            int ContratacionId = Reader.GetOrdinal("ContratacionId");
                            int FechaContratacion = Reader.GetOrdinal("FechaContratacion");
                            int PuestoLaboralId = Reader.GetOrdinal("PuestoLaboralId");
                            int PuestoLaboralNombre = Reader.GetOrdinal("PuestoLaboralNombre");
                            int MetaPresupuestalId = Reader.GetOrdinal("MetaPresupuestalId");
                            int MetaPresupuestalNombre = Reader.GetOrdinal("MetaPresupuestalNombre");
                            int OrdenServicio = Reader.GetOrdinal("OrdenServicio");
                            int ContratacionDescripcion = Reader.GetOrdinal("ContratacionDescripcion");
                            int Remuneracion = Reader.GetOrdinal("Remuneracion");
                            int TotalContrataciones = Reader.GetOrdinal("TotalContrataciones");
                            int Habilitacion = Reader.GetOrdinal("Habilitacion");
                            int ArchivoOrdenServicio = Reader.GetOrdinal("ArchivoOrdenServicio");


                            while (Reader.Read())
                            {
                                oContratacionListado_E = new ContratacionListado_E();
                                oContratacionListado_E.EmpleadoId = Reader.IsDBNull(EmpleadoId) ? 0 : Reader.GetInt32(EmpleadoId);
                                oContratacionListado_E.ApellidoPaterno = Reader.IsDBNull(ApellidoPaterno) ? "" : Reader.GetString(ApellidoPaterno);
                                oContratacionListado_E.ApellidoMaterno = Reader.IsDBNull(ApellidoMaterno) ? "" : Reader.GetString(ApellidoMaterno);
                                oContratacionListado_E.Nombres = Reader.IsDBNull(Nombres) ? "" : Reader.GetString(Nombres);
                                oContratacionListado_E.SexoId = Reader.IsDBNull(SexoId) ? 0 : Reader.GetInt32(SexoId);
                                oContratacionListado_E.TelefMovil = Reader.IsDBNull(TelefMovil) ? "" : Reader.GetString(TelefMovil);
                                oContratacionListado_E.Correo = Reader.IsDBNull(Correo) ? "" : Reader.GetString(Correo);
                                oContratacionListado_E.TipoDocumentoId = Reader.IsDBNull(TipoDocumentoId) ? 0 : Reader.GetInt32(TipoDocumentoId);
                                oContratacionListado_E.TipoDocAbrevNombre = Reader.IsDBNull(TipoDocAbrevNombre) ? "" : Reader.GetString(TipoDocAbrevNombre);
                                oContratacionListado_E.NumDoc = Reader.IsDBNull(NumDoc) ? "" : Reader.GetString(NumDoc);
                                oContratacionListado_E.FechaNacimiento = Reader.IsDBNull(FechaNacimiento) ? "" : Reader.GetString(FechaNacimiento);


                                oContratacionListado_E.ContratacionId = Reader.IsDBNull(ContratacionId) ? 0 : Reader.GetInt32(ContratacionId);
                                oContratacionListado_E.FechaContratacion = Reader.IsDBNull(FechaContratacion) ? "" : Convert.ToString(Reader[FechaContratacion]);
                                oContratacionListado_E.PuestoLaboralId = Reader.IsDBNull(PuestoLaboralId) ? 0 : Reader.GetInt32(PuestoLaboralId);
                                oContratacionListado_E.PuestoLaboralNombre = Reader.IsDBNull(PuestoLaboralNombre) ? "" : Reader.GetString(PuestoLaboralNombre);
                                oContratacionListado_E.MetaPresupuestalId = Reader.IsDBNull(MetaPresupuestalId) ? 0 : Reader.GetInt32(MetaPresupuestalId);
                                oContratacionListado_E.MetaPresupuestalNombre = Reader.IsDBNull(MetaPresupuestalNombre) ? "" : Reader.GetString(MetaPresupuestalNombre);
                                oContratacionListado_E.OrdenServicio = Reader.IsDBNull(OrdenServicio) ? "" : Reader.GetString(OrdenServicio);
                                oContratacionListado_E.ContratacionDescripcion = Reader.IsDBNull(ContratacionDescripcion) ? "" : Reader.GetString(ContratacionDescripcion);
                                oContratacionListado_E.Remuneracion = Reader.IsDBNull(Remuneracion) ? "" : Convert.ToString(Reader[Remuneracion]);
                                oContratacionListado_E.TotalContrataciones = Reader.IsDBNull(TotalContrataciones) ? "" : Convert.ToString(Reader[TotalContrataciones]);
                                oContratacionListado_E.Habilitacion = Reader.IsDBNull(Habilitacion) ? "" : Reader.GetString(Habilitacion);
                                oContratacionListado_E.ArchivoOrdenServicio = Reader.IsDBNull(ArchivoOrdenServicio)
                                    ? ""
                                    :  ReadFile(Reader.GetString(ArchivoOrdenServicio));
                                oContratacionListado_E.RutaOrdenServicio =  Reader.IsDBNull(ArchivoOrdenServicio)
                                    ? ""
                                    :  Reader.GetString(ArchivoOrdenServicio);
                                Lista.Add(oContratacionListado_E);
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

        private string ReadFile(string path)
        {
            if (Directory.Exists(path))
            {
                return Convert.ToBase64String(File.ReadAllBytes(path));
            }

            return string.Empty;
        }
    }
}
