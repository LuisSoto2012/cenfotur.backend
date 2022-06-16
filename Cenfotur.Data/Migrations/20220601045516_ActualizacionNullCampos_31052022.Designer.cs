﻿// <auto-generated />
using System;
using Cenfotur.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Cenfotur.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220601045516_ActualizacionNullCampos_31052022")]
    partial class ActualizacionNullCampos_31052022
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Cenfotur.Entidad.Models.Empleados.Empleado", b =>
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

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("FechaModificacion")
                        .HasColumnType("datetime");

                    b.Property<string>("FechaNacimiento")
                        .HasColumnType("varchar(8)")
                        .HasColumnName("FechaNacimiento");

                    b.Property<bool>("LoginEstado")
                        .HasColumnType("bit");

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

                    b.ToTable("Empleados");
                });

            modelBuilder.Entity("Cenfotur.Entidad.Models.Empleados.EmpleadoRol", b =>
                {
                    b.Property<int>("EmpleadoId")
                        .HasColumnType("int");

                    b.Property<int>("RolId")
                        .HasColumnType("int");

                    b.HasKey("EmpleadoId", "RolId");

                    b.HasIndex("RolId");

                    b.ToTable("EmpleadoRol");
                });

            modelBuilder.Entity("Cenfotur.Entidad.Models.Modulos.Modulo", b =>
                {
                    b.Property<int>("ModuloId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ModuloId"), 1L, 1);

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaCreacion")
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

            modelBuilder.Entity("Cenfotur.Entidad.Models.Roles.Rol", b =>
                {
                    b.Property<int>("RolId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RolId"), 1L, 1);

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaCreacion")
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

            modelBuilder.Entity("Cenfotur.Entidad.Models.Roles.RolSubModulo", b =>
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

                    b.Property<DateTime>("FechaCreacion")
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

            modelBuilder.Entity("Cenfotur.Entidad.Models.SubModulos.SubModulo", b =>
                {
                    b.Property<int>("SubModuloId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubModuloId"), 1L, 1);

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("FechaModificacion")
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

                    b.Property<int>("UsuarioModificacionId")
                        .HasColumnType("int");

                    b.HasKey("SubModuloId");

                    b.HasIndex("ModuloId");

                    b.ToTable("SubModulos");
                });

            modelBuilder.Entity("Cenfotur.Entidad.Models.Empleados.EmpleadoRol", b =>
                {
                    b.HasOne("Cenfotur.Entidad.Models.Empleados.Empleado", "Empleado")
                        .WithMany()
                        .HasForeignKey("EmpleadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cenfotur.Entidad.Models.Roles.Rol", "Rol")
                        .WithMany("EmpleadoRol")
                        .HasForeignKey("RolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empleado");

                    b.Navigation("Rol");
                });

            modelBuilder.Entity("Cenfotur.Entidad.Models.Roles.RolSubModulo", b =>
                {
                    b.HasOne("Cenfotur.Entidad.Models.Roles.Rol", "Rol")
                        .WithMany("RolSubModulo")
                        .HasForeignKey("RolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cenfotur.Entidad.Models.SubModulos.SubModulo", "SubModulo")
                        .WithMany("RolSubModulo")
                        .HasForeignKey("SubModuloId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rol");

                    b.Navigation("SubModulo");
                });

            modelBuilder.Entity("Cenfotur.Entidad.Models.SubModulos.SubModulo", b =>
                {
                    b.HasOne("Cenfotur.Entidad.Models.Modulos.Modulo", null)
                        .WithMany("SubModulos")
                        .HasForeignKey("ModuloId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Cenfotur.Entidad.Models.Modulos.Modulo", b =>
                {
                    b.Navigation("SubModulos");
                });

            modelBuilder.Entity("Cenfotur.Entidad.Models.Roles.Rol", b =>
                {
                    b.Navigation("EmpleadoRol");

                    b.Navigation("RolSubModulo");
                });

            modelBuilder.Entity("Cenfotur.Entidad.Models.SubModulos.SubModulo", b =>
                {
                    b.Navigation("RolSubModulo");
                });
#pragma warning restore 612, 618
        }
    }
}
