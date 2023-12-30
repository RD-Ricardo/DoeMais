﻿// <auto-generated />
using System;
using DM.Infrastructure.Data.CommandsDb;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DM.Infrastructure.Data.CommandDb.Migrations
{
    [DbContext(typeof(DoeMaisDbContextMySql))]
    [Migration("20231224112306_Versao.000.00")]
    partial class Versao00000
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("DM.Domain.Entities.Doacao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("DataAtualizado")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataDoacao")
                        .HasColumnType("date");

                    b.Property<Guid>("DoadorId")
                        .HasColumnType("char(36)");

                    b.Property<double>("QuantidadeML")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.HasIndex("DoadorId");

                    b.ToTable("Doacoes");
                });

            modelBuilder.Entity("DM.Domain.Entities.Doador", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("DataAtualizado")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<int>("FatorRh")
                        .HasColumnType("int");

                    b.Property<int>("Genero")
                        .HasColumnType("int");

                    b.Property<string>("NomeCompleto")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<double>("Peso")
                        .HasColumnType("double");

                    b.Property<int>("TipoSanguineo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Email");

                    b.ToTable("Doadores");
                });

            modelBuilder.Entity("DM.Domain.Entities.EstoqueSangue", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("DataAtualizado")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("FatorRh")
                        .HasColumnType("int");

                    b.Property<double>("QuantidadeML")
                        .HasColumnType("double");

                    b.Property<int>("TipoSanguineo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("EstoqueSangues");

                    b.HasData(
                        new
                        {
                            Id = new Guid("baac0b06-a0ea-4adb-89f1-628096ca9ccb"),
                            DataAtualizado = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataCadastro = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FatorRh = 1,
                            QuantidadeML = 0.0,
                            TipoSanguineo = 0
                        },
                        new
                        {
                            Id = new Guid("f93e2ea6-e37f-496d-b59e-d10be251c3be"),
                            DataAtualizado = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataCadastro = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FatorRh = 0,
                            QuantidadeML = 0.0,
                            TipoSanguineo = 0
                        },
                        new
                        {
                            Id = new Guid("4cd49427-68f3-46d4-99d5-c5820ad17152"),
                            DataAtualizado = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataCadastro = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FatorRh = 1,
                            QuantidadeML = 0.0,
                            TipoSanguineo = 1
                        },
                        new
                        {
                            Id = new Guid("be69cb34-0911-468b-91b8-c13afb783f8e"),
                            DataAtualizado = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataCadastro = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FatorRh = 0,
                            QuantidadeML = 0.0,
                            TipoSanguineo = 1
                        },
                        new
                        {
                            Id = new Guid("901ad1bc-3eb8-45e1-a7ba-c554337509ec"),
                            DataAtualizado = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataCadastro = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FatorRh = 1,
                            QuantidadeML = 0.0,
                            TipoSanguineo = 2
                        },
                        new
                        {
                            Id = new Guid("94fe7651-65fb-4cc6-a236-0c12338b475a"),
                            DataAtualizado = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataCadastro = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FatorRh = 0,
                            QuantidadeML = 0.0,
                            TipoSanguineo = 2
                        },
                        new
                        {
                            Id = new Guid("b378a0c5-e8b2-4fa5-a78b-58ea88c278f8"),
                            DataAtualizado = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataCadastro = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FatorRh = 1,
                            QuantidadeML = 0.0,
                            TipoSanguineo = 3
                        },
                        new
                        {
                            Id = new Guid("617d9602-47fd-43be-9746-011f85eb04f9"),
                            DataAtualizado = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataCadastro = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FatorRh = 0,
                            QuantidadeML = 0.0,
                            TipoSanguineo = 3
                        });
                });

            modelBuilder.Entity("DM.Domain.Entities.Doacao", b =>
                {
                    b.HasOne("DM.Domain.Entities.Doador", "Doador")
                        .WithMany("Doacoes")
                        .HasForeignKey("DoadorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doador");
                });

            modelBuilder.Entity("DM.Domain.Entities.Doador", b =>
                {
                    b.OwnsOne("DM.Core.DomainObjects.ValueObjects.Endereco", "Endereco", b1 =>
                        {
                            b1.Property<Guid>("DoadorId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("Cep")
                                .HasMaxLength(8)
                                .HasColumnType("varchar(8)")
                                .HasColumnName("Cep");

                            b1.Property<string>("Cidade")
                                .HasMaxLength(50)
                                .HasColumnType("varchar(50)")
                                .HasColumnName("Cidade");

                            b1.Property<string>("Estado")
                                .HasMaxLength(2)
                                .HasColumnType("varchar(2)")
                                .HasColumnName("Estado");

                            b1.Property<string>("Logradouro")
                                .HasMaxLength(100)
                                .HasColumnType("varchar(100)")
                                .HasColumnName("Logradouro");

                            b1.HasKey("DoadorId");

                            b1.ToTable("Doadores");

                            b1.WithOwner()
                                .HasForeignKey("DoadorId");
                        });

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("DM.Domain.Entities.Doador", b =>
                {
                    b.Navigation("Doacoes");
                });
#pragma warning restore 612, 618
        }
    }
}
