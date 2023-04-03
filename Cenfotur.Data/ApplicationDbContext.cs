using Cenfotur.Entidad.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cenfotur.Entidad.DTOS.Output;

namespace Cenfotur.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<EmpleadoRol> EmpleadoRol { get; set; }
        public DbSet<Modulo> Modulos { get; set; }
        public DbSet<SubModulo> SubModulos { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<RolSubModulo> RolSubModulo { get; set; }
        public DbSet<Anio> Anios { get; set; }
        public DbSet<Sexo> Sexos { get; set; }
        public DbSet<TipoDocumento> TipoDocumentos { get; set; }
        public DbSet<MetaPresupuestal> MetasPresupuestales { get; set; }
        public DbSet<PuestoLaboral> PuestosLaborales { get; set; }

        // ------------------
        public DbSet<Contratacion> Contrataciones { get; set; }
        
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Capacitacion> Capacitaciones { get; set; }
        public DbSet<TipoCapacitacion> TipoCapacitaciones { get; set; }

        public DbSet<Provincia> Provincias { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Distrito> Distritos { get; set; }
        public DbSet<Documentacion> Documentaciones { get; set; }
        public DbSet<MaterialAcademico> MaterialesAcademicos { get; set; }
        public DbSet<PerfilRelacionado> PerfilesRelacionados { get; set; }
        public DbSet<Participante> Participantes { get;set; }
        
        public DbSet<EstadoCivil> EstadosCiviles { get; set; }
        public DbSet<NivelEducativo> NivelesEducativos { get; set; }
        public DbSet<Alcance> Alcances { get; set; }
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<TipoRemuneracion> TiposRemuneraciones { get; set; }
        public DbSet<TipoContribuyente> TiposContribuyentes { get; set; }

        public DbSet<Rubro> Rubros { get; set; }
        public DbSet<Dicertur> Dicerturs { get; set; }
        public DbSet<Clase> Clases { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Referencia> Referencias { get; set; }

        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<ParticipanteCapacitacion> ParticipanteCapacitacion { get; set; }
        public DbSet<EncuestaSatisfaccion> EncuestaSatisfaccion { get; set; }
        public DbSet<Asistencia> Asistencia { get; set; }
        public DbSet<Nota> Notas { get; set; }
        public DbSet<FacilitadorArchivo> FacilitadorArchivos { get; set; }
        public DbSet<Programa> Programas { get; set; }
        public DbSet<TipoSupervision> TiposSupervision { get; set; }
        public DbSet<FichaSupervision> FichasSupervision { get; set; }
        public DbSet<Certificado> Certificados { get; set; }
        public DbSet<DirectorioEncuesta> DirectoriosEncuestas { get; set; }
        public DbSet<ProgramacionInfoPFC> ProgramacionesInfoPFC { get; set; }
        
        public DbSet<DataSP_O_DTO> DataSpODtos { get; set; }
        public DbSet<DataSP2_O_DTO> DataSp2ODtos { get; set; }

        // Esto se crea para poder agregar 2 key a una tabla es la unica manera 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DataSP_O_DTO>().HasNoKey();
            modelBuilder.Entity<DataSP2_O_DTO>().HasNoKey();
            
            modelBuilder.Entity<EmpleadoRol>().HasKey(er => new { er.EmpleadoId, er.RolId });
            //modelbuilder.Entity<RolSubModulo>().HasKey(rs => new { rs.RolId, rs.SubModuloId }); //No se puede colocar id a una tabla muchos a muchos

            modelBuilder.Entity<ParticipanteCapacitacion>().HasKey(pc => new { pc.ParticipanteId, pc.CapacitacionId });
            
            modelBuilder.Entity<EncuestaSatisfaccion>().HasKey(pc => new { pc.ParticipanteId, pc.CapacitacionId });

            modelBuilder.Entity<Nota>().HasKey(pc => new { pc.ParticipanteId, pc.CapacitacionId });
            
            modelBuilder.Entity<Capacitacion>()
                .HasOne<Distrito>(s => s.Ubigeo)
                .WithMany(g => g.Capacitaciones)
                .HasForeignKey(s => s.UbigueoId);
                
            modelBuilder.Entity<CursoPerfilRelacionado>().HasKey(er => new { er.CursoId, er.PerfilRelacionadoId });
            modelBuilder.Entity<ParticipantePerfilRelacionado>().HasKey(er => new { er.ParticipanteId, er.PerfilRelacionadoId });
        }
    }
}
