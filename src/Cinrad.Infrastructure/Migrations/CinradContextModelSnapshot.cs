﻿// <auto-generated />
using System;
using Cinrad.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Cinrad.Infrastructure.Migrations
{
    [DbContext(typeof(CinradContext))]
    partial class CinradContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Cinrad.Core.Entity.AgendaProducao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.HasKey("Id");

                    b.ToTable("AgendaProducao");
                });

            modelBuilder.Entity("Cinrad.Core.Entity.ApresentacaoProduto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.HasKey("Id");

                    b.ToTable("ApresentacaoProduto");
                });

            modelBuilder.Entity("Cinrad.Core.Entity.Cliente", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Cnpj");

                    b.Property<int>("Codigo");

                    b.Property<string>("NomeFantasia");

                    b.Property<string>("RazaoSocial");

                    b.Property<string>("Site");

                    b.Property<string>("Telefone");

                    b.HasKey("Id");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("Cinrad.Core.Entity.Pedido", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.HasKey("Id");

                    b.ToTable("Pedido");
                });

            modelBuilder.Entity("Cinrad.Core.Entity.Produto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("Codigo");

                    b.Property<Guid>("CodigoCor");

                    b.Property<string>("Descrisao");

                    b.Property<bool>("IsDadosObrigatorio");

                    b.Property<string>("Nome");

                    b.Property<string>("UnidadeMedida");

                    b.Property<string>("UnidadeVenda");

                    b.HasKey("Id");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("Cinrad.Core.Entity.Transportadora", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Cnpj");

                    b.Property<int>("Codigo");

                    b.Property<string>("NomeFantasia");

                    b.Property<string>("RazaoSocial");

                    b.Property<string>("Site");

                    b.Property<string>("Telefone");

                    b.HasKey("Id");

                    b.ToTable("Transportadora");
                });

            modelBuilder.Entity("Cinrad.Core.Entity.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CPF");

                    b.Property<string>("Celular");

                    b.Property<Guid?>("ClienteId");

                    b.Property<string>("Email");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Nome");

                    b.Property<string>("Telefone");

                    b.Property<Guid?>("TransportadoraId");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("TransportadoraId");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("Cinrad.Core.Entity.Usuario", b =>
                {
                    b.HasOne("Cinrad.Core.Entity.Cliente", "Cliente")
                        .WithMany("Usuarios")
                        .HasForeignKey("ClienteId");

                    b.HasOne("Cinrad.Core.Entity.Transportadora", "Transportadora")
                        .WithMany("Usuarios")
                        .HasForeignKey("TransportadoraId");
                });
#pragma warning restore 612, 618
        }
    }
}
