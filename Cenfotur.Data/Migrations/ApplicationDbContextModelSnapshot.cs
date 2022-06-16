﻿// <auto-generated />
using System;
using Cenfotur.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Cenfotur.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Cenfotur.Entidad.Models.Anio", b =>
                {
                    b.Property<int>("AnioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AnioId"), 1L, 1);

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<int>("ConDirectaMonMax")
                        .HasColumnType("int");

                    b.Property<DateTime?>("FechaCreacion")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("FechaModificacion")
                        .HasColumnType("datetime");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("varchar(4)")
                        .HasColumnName("Nombre");

                    b.Property<string>("NombreOficial")
                        .IsRequired()
                        .HasMaxLength(170)
                        .HasColumnType("varchar(170)")
                        .HasColumnName("NombreOficial");

                    b.Property<int>("UIT")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioCreacionId")
                        .HasColumnType("int");

                    b.Property<int?>("UsuarioModificacionId")
                        .HasColumnType("int");

                    b.HasKey("AnioId");

                    b.ToTable("Anios");
                });

            modelBuilder.Entity("Cenfotur.Entidad.Models.Contratacion", b =>
                {
                    b.Property<int>("ContratacionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ContratacionId"), 1L, 1);

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<int?>("AnioId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("ArchivoOrdenServicio")
                        .HasColumnType("varchar(200)")
                        .HasColumnName("ArchivoOrdenServicio");

                    b.Property<string>("ContratacionDescripcion")
                        .HasColumnType("varchar(100)")
                        .HasColumnName("ContratacionDescripcion");

                    b.Property<int>("EmpleadoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaContratacion")
                        .HasColumnType("Date")
                        .HasColumnName("FechaContratacion");

                    b.Property<DateTime?>("FechaCreacion")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("FechaModificacion")
                        .HasColumnType("datetime");

                    b.Property<int>("MetaPresupuestalId")
                        .HasColumnType("int");

                    b.Property<string>("OrdenServicio")
                        .HasColumnType("varchar(40)")
                        .HasColumnName("OrdenServicio");

                    b.Property<int>("PuestoLaboralId")
                        .HasColumnType("int");

                    b.Property<decimal?>("Remuneracion")
                        .HasColumnType("decimal(7,2)");

                    b.Property<int>("UsuarioCreacionId")
                        .HasColumnType("int");

                    b.Property<int?>("UsuarioModificacionId")
                        .HasColumnType("int");

                    b.HasKey("ContratacionId");

                    b.HasIndex("AnioId");

                    b.HasIndex("EmpleadoId");

                    b.HasIndex("MetaPresupuestalId");

                    b.HasIndex("PuestoLaboralId");

                    b.ToTable("Contrataciones");
                });

            modelBuilder.Entity("Cenfotur.Entidad.Models.Empleado", b =>
                {
                    b.Property<int>("EmpleadoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmpleadoId"), 1L, 1);

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<string>("ApellidoMaterno")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("ApellidoMaterno");

                    b.Property<string>("ApellidoPaterno")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("ApellidoPaterno");

                    b.Property<string>("Contrasena")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Contrasena");

                    b.Property<string>("Correo")
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)")
                        .HasColumnName("Correo");

                    b.Property<DateTime?>("FechaCreacion")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("FechaModificacion")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("Date")
                        .HasColumnName("FechaNacimiento");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Nombres");

                    b.Property<string>("NumDoc")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)")
                        .HasColumnName("NumDoc");

                    b.Property<int>("SexoId")
                        .HasColumnType("int");

                    b.Property<string>("TelefMovil")
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("TelefMovil");

                    b.Property<int>("TipoDocumentoId")
                        .HasColumnType("int");

                    b.Property<string>("Usuario")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)")
                        .HasColumnName("Usuario");

                    b.Property<int>("UsuarioCreacionId")
                        .HasColumnType("int");

                    b.Property<int?>("UsuarioModificacionId")
                        .HasColumnType("int");

                    b.HasKey("EmpleadoId");

                    b.HasIndex("NumDoc")
                        .IsUnique();

                    b.HasIndex("TipoDocumentoId");

                    b.ToTable("Empleados");
                });

            modelBuilder.Entity("Cenfotur.Entidad.Models.EmpleadoRol", b =>
                {
                    b.Property<int>("EmpleadoId")
                        .HasColumnType("int");

                    b.Property<int>("RolId")
                        .HasColumnType("int");

                    b.HasKey("EmpleadoId", "RolId");

                    b.HasIndex("RolId");

                    b.ToTable("EmpleadoRol");
                });

            modelBuilder.Entity("Cenfotur.Entidad.Models.MetaPresupuestal", b =>
                {
                    b.Property<int>("MetaPresupuestalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MetaPresupuestalId"), 1L, 1);

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<int?>("AnioId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("FechaModificacion")
                        .HasColumnType("datetime");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(85)
                        .HasColumnType("varchar(85)")
                        .HasColumnName("Nombre");

                    b.Property<int>("UsuarioCreacionId")
                        .HasColumnType("int");

                    b.Property<int?>("UsuarioModificacionId")
                        .HasColumnType("int");

                    b.HasKey("MetaPresupuestalId");

                    b.HasIndex("AnioId");

                    b.ToTable("MetasPresupuestales");
                });

            modelBuilder.Entity("Cenfotur.Entidad.Models.Modulo", b =>
                {
                    b.Property<int>("ModuloId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ModuloId"), 1L, 1);

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("FechaCreacion")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("FechaModificacion")
                        .HasColumnType("datetime");

                    b.Property<string>("Icono")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Icono");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Nombre");

                    b.Property<int>("Orden")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioCreacionId")
                        .HasColumnType("int");

                    b.Property<int?>("UsuarioModificacionId")
                        .HasColumnType("int");

                    b.HasKey("ModuloId");

                    b.ToTable("Modulos");
                });

            modelBuilder.Entity("Cenfotur.Entidad.Models.PuestoLaboral", b =>
                {
                    b.Property<int>("PuestoLaboralId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PuestoLaboralId"), 1L, 1);

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("FechaCreacion")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("FechaModificacion")
                        .HasColumnType("datetime");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)")
                        .HasColumnName("Nombre");

                    b.Property<int>("UsuarioCreacionId")
                        .HasColumnType("int");

                    b.Property<int?>("UsuarioModificacionId")
                        .HasColumnType("int");

                    b.HasKey("PuestoLaboralId");

                    b.ToTable("PuestosLaborales");
                });

            modelBuilder.Entity("Cenfotur.Entidad.Models.Rol", b =>
                {
                    b.Property<int>("RolId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RolId"), 1L, 1);

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("FechaCreacion")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("FechaModificacion")
                        .HasColumnType("datetime");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("varchar(150)")
                        .HasColumnName("Nombre");

                    b.Property<int>("UsuarioCreacionId")
                        .HasColumnType("int");

                    b.Property<int?>("UsuarioModificacionId")
                        .HasColumnType("int");

                    b.HasKey("RolId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Cenfotur.Entidad.Models.RolSubModulo", b =>
                {
                    b.Property<int>("RolSubModuloId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RolSubModuloId"), 1L, 1);

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<bool>("Agregar")
                        .HasColumnType("bit");

                    b.Property<bool>("Editar")
                        .HasColumnType("bit");

                    b.Property<bool>("Eliminar")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("FechaCreacion")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("FechaModificacion")
                        .HasColumnType("datetime");

                    b.Property<int>("RolId")
                        .HasColumnType("int");

                    b.Property<int>("SubModuloId")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioCreacionId")
                        .HasColumnType("int");

                    b.Property<int?>("UsuarioModificacionId")
                        .HasColumnType("int");

                    b.Property<bool>("Ver")
                        .HasColumnType("bit");

                    b.HasKey("RolSubModuloId");

                    b.HasIndex("RolId");

                    b.HasIndex("SubModuloId");

                    b.ToTable("RolSubModulo");
                });

            modelBuilder.Entity("Cenfotur.Entidad.Models.Sexo", b =>
                {
                    b.Property<int>("SexoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SexoId"), 1L, 1);

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("FechaCreacion")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("FechaModificacion")
                        .HasColumnType("datetime");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)")
                        .HasColumnName("Nombre");

                    b.Property<int>("UsuarioCreacionId")
                        .HasColumnType("int");

                    b.Property<int?>("UsuarioModificacionId")
                        .HasColumnType("int");

                    b.HasKey("SexoId");

                    b.ToTable("Sexos");
                });

            modelBuilder.Entity("Cenfotur.Entidad.Models.SubModulo", b =>
                {
                    b.Property<int>("SubModuloId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubModuloId"), 1L, 1);

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("FechaCreacion")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("FechaModificacion")
                        .HasColumnType("datetime");

                    b.Property<int>("ModuloId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Nombre");

                    b.Property<int>("Orden")
                        .HasColumnType("int");

                    b.Property<string>("Ruta")
                        .HasColumnType("varchar(200)")
                        .HasColumnName("Ruta");

                    b.Property<int>("UsuarioCreacionId")
                        .HasColumnType("int");

                    b.Property<int?>("UsuarioModificacionId")
                        .HasColumnType("int");

                    b.HasKey("SubModuloId");

                    b.HasIndex("ModuloId");

                    b.ToTable("SubModulos");
                });

            modelBuilder.Entity("Cenfotur.Entidad.Models.TipoDocumento", b =>
                {
                    b.Property<int>("TipoDocumentoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TipoDocumentoId"), 1L, 1);

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("FechaCreacion")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("FechaModificacion")
                        .HasColumnType("datetime");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Nombre");

                    b.Property<string>("NombreAbrev")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)")
                        .HasColumnName("NombreAbrev");

                    b.Property<int>("UsuarioCreacionId")
                        .HasColumnType("int");

                    b.Property<int?>("UsuarioModificacionId")
                        .HasColumnType("int");

                    b.HasKey("TipoDocumentoId");

                    b.ToTable("TipoDocumentos");
                });

            modelBuilder.Entity("Cenfotur.Entidad.Models.Contratacion", b =>
                {
                    b.HasOne("Cenfotur.Entidad.Models.Anio", null)
                        .WithMany("Contrataciones")
                        .HasForeignKey("AnioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cenfotur.Entidad.Models.Empleado", null)
                        .WithMany("Contrataciones")
                        .HasForeignKey("EmpleadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cenfotur.Entidad.Models.MetaPresupuestal", null)
                        .WithMany("Contrataciones")
                        .HasForeignKey("MetaPresupuestalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cenfotur.Entidad.Models.PuestoLaboral", null)
                        .WithMany("Contrataciones")
                        .HasForeignKey("PuestoLaboralId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Cenfotur.Entidad.Models.Empleado", b =>
                {
                    b.HasOne("Cenfotur.Entidad.Models.TipoDocumento", null)
                        .WithMany("Empleados")
                        .HasForeignKey("TipoDocumentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Cenfotur.Entidad.Models.EmpleadoRol", b =>
                {
                    b.HasOne("Cenfotur.Entidad.Models.Empleado", "Empleado")
                        .WithMany("EmpleadoRol")
                        .HasForeignKey("EmpleadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cenfotur.Entidad.Models.Rol", "Rol")
                        .WithMany("EmpleadoRol")
                        .HasForeignKey("RolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empleado");

                    b.Navigation("Rol");
                });

            modelBuilder.Entity("Cenfotur.Entidad.Models.MetaPresupuestal", b =>
                {
                    b.HasOne("Cenfotur.Entidad.Models.Anio", null)
                        .WithMany("MetasPresupuestales")
                        .HasForeignKey("AnioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Cenfotur.Entidad.Models.RolSubModulo", b =>
                {
                    b.HasOne("Cenfotur.Entidad.Models.Rol", "Rol")
                        .WithMany("RolSubModulo")
                        .HasForeignKey("RolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cenfotur.Entidad.Models.SubModulo", "SubModulo")
                        .WithOne("RolSubModulo")
                        .HasForeignKey("Cenfotur.Entidad.Models.RolSubModulo", "SubModuloId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rol");

                    b.Navigation("SubModulo");
                });

            modelBuilder.Entity("Cenfotur.Entidad.Models.SubModulo", b =>
                {
                    b.HasOne("Cenfotur.Entidad.Models.Modulo", null)
                        .WithMany("SubModulos")
                        .HasForeignKey("ModuloId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Cenfotur.Entidad.Models.Anio", b =>
                {
                    b.Navigation("Contrataciones");

                    b.Navigation("MetasPresupuestales");
                });

            modelBuilder.Entity("Cenfotur.Entidad.Models.Empleado", b =>
                {
                    b.Navigation("Contrataciones");

                    b.Navigation("EmpleadoRol");
                });

            modelBuilder.Entity("Cenfotur.Entidad.Models.MetaPresupuestal", b =>
                {
                    b.Navigation("Contrataciones");
                });

            modelBuilder.Entity("Cenfotur.Entidad.Models.Modulo", b =>
                {
                    b.Navigation("SubModulos");
                });

            modelBuilder.Entity("Cenfotur.Entidad.Models.PuestoLaboral", b =>
                {
                    b.Navigation("Contrataciones");
                });

            modelBuilder.Entity("Cenfotur.Entidad.Models.Rol", b =>
                {
                    b.Navigation("EmpleadoRol");

                    b.Navigation("RolSubModulo");
                });

            modelBuilder.Entity("Cenfotur.Entidad.Models.SubModulo", b =>
                {
                    b.Navigation("RolSubModulo");
                });

            modelBuilder.Entity("Cenfotur.Entidad.Models.TipoDocumento", b =>
                {
                    b.Navigation("Empleados");
                });
#pragma warning restore 612, 618
        }
    }
}
