﻿// <auto-generated />
using System;
using Integracao_Cadastro_Cliente.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Integracao_Cadastro_Cliente.API.Migrations
{
    [DbContext(typeof(EmpresaPadraoContext))]
    [Migration("20240429160117_Inicial")]
    partial class Inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17");

            modelBuilder.Entity("Integracao_Cadastro_Cliente.API.Models.Cliente", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<byte[]>("Logotipo")
                        .HasColumnType("image");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(60)
                        .IsUnicode(false)
                        .HasColumnType("varchar(60)");

                    b.HasKey("Id");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("Integracao_Cadastro_Cliente.API.Models.ClienteLogradouro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<long>("ClienteId")
                        .HasColumnType("bigint");

                    b.Property<long>("LogradouroId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("ClienteLogradouro");
                });

            modelBuilder.Entity("Integracao_Cadastro_Cliente.API.Models.Logradouro", b =>
                {
                    b.Property<long>("LogradouroId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("Cidade")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Complemento")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Estado")
                        .HasMaxLength(2)
                        .HasColumnType("nchar(2)")
                        .IsFixedLength(true);

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.HasKey("LogradouroId");

                    b.ToTable("Logradouro");
                });

            modelBuilder.Entity("Integracao_Cadastro_Cliente.API.Models.ClienteLogradouro", b =>
                {
                    b.HasOne("Integracao_Cadastro_Cliente.API.Models.Cliente", "Cliente")
                        .WithMany("ClienteLogradouros")
                        .HasForeignKey("ClienteId")
                        .HasConstraintName("FK_Cliente_ClienteLogradouro")
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("Integracao_Cadastro_Cliente.API.Models.Cliente", b =>
                {
                    b.Navigation("ClienteLogradouros");
                });
#pragma warning restore 612, 618
        }
    }
}