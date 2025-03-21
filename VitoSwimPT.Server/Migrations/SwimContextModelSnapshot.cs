﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VitoSwimPT.Server.Models;

#nullable disable

namespace VitoSwimPT.Server.Migrations
{
    [DbContext(typeof(SwimContext))]
    partial class SwimContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

            modelBuilder.Entity("VitoSwimPT.Server.Models.EsercizioAllenamento", b =>
                {
                    b.Property<int>("EsercizioId")
                        .HasColumnType("int");

                    b.Property<int>("AllenamentoId")
                        .HasColumnType("int");

                    b.HasKey("EsercizioId", "AllenamentoId");

                    b.HasIndex("AllenamentoId");

                    b.ToTable("EserciziAllenamenti");
                });

            modelBuilder.Entity("VitoSwimPT.Server.Models.Piano", b =>
                {
                    b.Property<int>("PianoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PianoId"));

                    b.Property<string>("Descrizione")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomePiano")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PianoId");

                    b.ToTable("Piani");
                });

            modelBuilder.Entity("VitoSwimPT.Server.Models.EsercizioAllenamento", b =>
                {
                    b.HasOne("VitoSwimPT.Server.Models.Allenamento", "Allenamento")
                        .WithMany("EserciziAllenamenti")
                        .HasForeignKey("AllenamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VitoSwimPT.Server.Models.Esercizio", "Esercizio")
                        .WithMany("EserciziAllenamenti")
                        .HasForeignKey("EsercizioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Allenamento");

                    b.Navigation("Esercizio");
                });

            modelBuilder.Entity("VitoSwimPT.Server.Models.Allenamento", b =>
                {
                    b.Navigation("EserciziAllenamenti");
                });

            modelBuilder.Entity("VitoSwimPT.Server.Models.Esercizio", b =>
                {
                    b.Navigation("EserciziAllenamenti");
                });
#pragma warning restore 612, 618
        }
    }
}
