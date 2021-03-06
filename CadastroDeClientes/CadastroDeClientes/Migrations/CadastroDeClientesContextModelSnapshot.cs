﻿// <auto-generated />
using System;
using CadastroDeClientes.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CadastroDeClientes.Migrations
{
    [DbContext(typeof(CadastroDeClientesContext))]
    partial class CadastroDeClientesContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("CadastroDeClientes.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Bairro")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("CEP")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Cidade")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Complemento")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("DataDeNascimento")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Endereco")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Estado")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int?>("Numero")
                        .HasColumnType("int");

                    b.Property<string>("Sexo")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Cliente");
                });
#pragma warning restore 612, 618
        }
    }
}
