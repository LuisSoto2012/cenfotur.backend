﻿using Cenfotur.Entidad.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


        // Esto se crea para poder agregar 2 key a una tabla es la unica manera 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmpleadoRol>().HasKey(er => new { er.EmpleadoId, er.RolId });
            //modelbuilder.Entity<RolSubModulo>().HasKey(rs => new { rs.RolId, rs.SubModuloId }); //No se puede colocar id a una tabla muchos a muchos
            
            modelBuilder.Entity<Capacitacion>()
                .HasOne<Distrito>(s => s.Ubigeo)
                .WithMany(g => g.Capacitaciones)
                .HasForeignKey(s => s.UbigueoId);
        }
    }
}
