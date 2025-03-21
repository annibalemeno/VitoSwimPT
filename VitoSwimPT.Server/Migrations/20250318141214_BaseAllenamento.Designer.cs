﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VitoSwimPT.Server.Models;

#nullable disable

namespace VitoSwimPT.Server.Migrations
{
    [DbContext(typeof(SwimContext))]
    [Migration("20250318141214_BaseAllenamento")]
    partial class BaseAllenamento
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("VitoSwimPT.Server.Models.Allenamento", b =>
                {
                    b.Property<int>("AllenamentoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AllenamentoId"));

                    b.Property<string>("NomeAllenamento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AllenamentoId");

                    b.ToTable("Allenamenti");
                });

            modelBuilder.Entity("VitoSwimPT.Server.Models.Esercizio", b =>
                {
                    b.Property<int>("EsercizioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EsercizioId"));

                    b.Property<int>("Distanza")
                        .HasColumnType("int");

                    b.Property<int>("Recupero")
                        .HasColumnType("int");

                    b.Property<int>("Ripetizioni")
                        .HasColumnType("int");

                    b.Property<string>("Stile")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EsercizioId");

                    b.ToTable("Esercizi");
                });
#pragma warning restore 612, 618
        }
    }
}
