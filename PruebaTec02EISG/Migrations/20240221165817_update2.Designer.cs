﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PruebaTec02EISG.Models;

#nullable disable

namespace PruebaTec02EISG.Migrations
{
    [DbContext(typeof(PruebaTec02EISGDbContext))]
    [Migration("20240221165817_update2")]
    partial class update2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.27")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PruebaTec02EISG.Models.Carrera", b =>
                {
                    b.Property<int>("CarreraId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CarreraId"), 1L, 1);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CarreraId");

                    b.ToTable("Carreras");
                });

            modelBuilder.Entity("PruebaTec02EISG.Models.Profesor", b =>
                {
                    b.Property<int>("ProfesorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProfesorId"), 1L, 1);

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CarreraId")
                        .HasColumnType("int");

                    b.Property<string>("CorreoElectronico")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Imagen")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProfesorId");

                    b.HasIndex("CarreraId");

                    b.ToTable("Profesores");
                });

            modelBuilder.Entity("PruebaTec02EISG.Models.Profesor", b =>
                {
                    b.HasOne("PruebaTec02EISG.Models.Carrera", "Carrera")
                        .WithMany("Profesores")
                        .HasForeignKey("CarreraId");

                    b.Navigation("Carrera");
                });

            modelBuilder.Entity("PruebaTec02EISG.Models.Carrera", b =>
                {
                    b.Navigation("Profesores");
                });
#pragma warning restore 612, 618
        }
    }
}