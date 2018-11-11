﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using easy_hotel_backend;

namespace easyhotelbackend.Migrations
{
    [DbContext(typeof(ApiDbContext))]
    partial class ApiDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.2-rtm-30932");

            modelBuilder.Entity("easy_hotel_backend.Models.Hotel", b =>
                {
                    b.Property<int>("HotelId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Avaliacao");

                    b.Property<string>("Cidade");

                    b.Property<string>("Descricao");

                    b.Property<string>("Email");

                    b.Property<string>("Estado");

                    b.Property<string>("Nome");

                    b.HasKey("HotelId");

                    b.ToTable("Hotels");
                });

            modelBuilder.Entity("easy_hotel_backend.Models.Imagem", b =>
                {
                    b.Property<int>("ImagemId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Arquivo");

                    b.Property<string>("Nome");

                    b.Property<int?>("QuartoId");

                    b.HasKey("ImagemId");

                    b.HasIndex("QuartoId");

                    b.ToTable("Imagem");
                });

            modelBuilder.Entity("easy_hotel_backend.Models.Quarto", b =>
                {
                    b.Property<int>("QuartoId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AvaliacaoQuarto");

                    b.Property<string>("Descricao");

                    b.Property<int>("HotelId");

                    b.Property<string>("TipoQuarto");

                    b.Property<double>("Valor");

                    b.HasKey("QuartoId");

                    b.HasIndex("HotelId");

                    b.ToTable("Quarto");
                });

            modelBuilder.Entity("easy_hotel_backend.Models.Reserva", b =>
                {
                    b.Property<int>("ReservaId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataFim");

                    b.Property<DateTime>("DataInicio");

                    b.Property<int>("QuartoId");

                    b.Property<int>("UsuarioId");

                    b.Property<double>("Valor");

                    b.HasKey("ReservaId");

                    b.HasIndex("QuartoId");

                    b.ToTable("Reserva");
                });

            modelBuilder.Entity("easy_hotel_backend.Usuario", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("Nome");

                    b.Property<string>("Senha");

                    b.HasKey("UsuarioId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("easy_hotel_backend.Models.Imagem", b =>
                {
                    b.HasOne("easy_hotel_backend.Models.Quarto")
                        .WithMany("Imagens")
                        .HasForeignKey("QuartoId");
                });

            modelBuilder.Entity("easy_hotel_backend.Models.Quarto", b =>
                {
                    b.HasOne("easy_hotel_backend.Models.Hotel", "Hotel")
                        .WithMany()
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("easy_hotel_backend.Models.Reserva", b =>
                {
                    b.HasOne("easy_hotel_backend.Models.Quarto", "quarto")
                        .WithMany()
                        .HasForeignKey("QuartoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
