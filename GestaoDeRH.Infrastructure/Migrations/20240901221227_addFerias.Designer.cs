﻿// <auto-generated />
using System;
using GestaoDeRH.Infra.BancoDeDados;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GestaoDeRH.Infra.Migrations
{
    [DbContext(typeof(GestaoDeRhDbContext))]
    [Migration("20240901221227_addFerias")]
    partial class addFerias
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true);

            modelBuilder.Entity("GestaoDeRH.Dominio.ControlePonto.Ponto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ColaboradorId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DataMarcacao")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ColaboradorId");

                    b.ToTable("Pontos");
                });

            modelBuilder.Entity("GestaoDeRH.Dominio.Ferias.Ferias", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ColaboradorId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DataFimFerias")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataInicioFerias")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataUltimaSolicitacao")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Ferias");
                });

            modelBuilder.Entity("GestaoDeRH.Dominio.FolhaDePagamento.Holerite", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ColaboradorId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("TotalDosDescontos")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("TotalDosVencimentos")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ColaboradorId");

                    b.ToTable("Holerites");
                });

            modelBuilder.Entity("GestaoDeRH.Dominio.FolhaDePagamento.LancamentoHolerite", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descricao")
                        .HasColumnType("TEXT");

                    b.Property<int?>("HoleriteId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Referencia")
                        .HasColumnType("TEXT");

                    b.Property<int>("Tipo")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Valor")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("HoleriteId");

                    b.ToTable("LancamentoHolerite");
                });

            modelBuilder.Entity("GestaoDeRH.Dominio.Notificacao.Notificacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("DestinatarioId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Mensagem")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("DestinatarioId");

                    b.ToTable("Notificacoes");
                });

            modelBuilder.Entity("GestaoDeRH.Dominio.Pessoas.Colaborador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CPF")
                        .HasColumnType("TEXT");

                    b.Property<string>("Cargo")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataDeNascimento")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DataFimContratoDeTrabalho")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataInicioContratoDeTrabalho")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<string>("RG")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Salario")
                        .HasColumnType("TEXT");

                    b.Property<string>("Sobrenome")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Colaboradores");
                });

            modelBuilder.Entity("GestaoDeRH.Dominio.Recrutamento.Candidato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Aprovado")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CPF")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataDeNascimento")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<string>("RG")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("SalarioPretendido")
                        .HasColumnType("TEXT");

                    b.Property<string>("Sobrenome")
                        .HasColumnType("TEXT");

                    b.Property<int?>("VagaAplicadaId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("VagaAplicadaId");

                    b.ToTable("Candidatos");
                });

            modelBuilder.Entity("GestaoDeRH.Dominio.Recrutamento.Vaga", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Aberta")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("AbertaPorId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Cargo")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("FaixaSalarialMax")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("FaixaSalarialMin")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AbertaPorId");

                    b.ToTable("Vagas");
                });

            modelBuilder.Entity("GestaoDeRH.Dominio.ControlePonto.Ponto", b =>
                {
                    b.HasOne("GestaoDeRH.Dominio.Pessoas.Colaborador", "Colaborador")
                        .WithMany()
                        .HasForeignKey("ColaboradorId");

                    b.Navigation("Colaborador");
                });

            modelBuilder.Entity("GestaoDeRH.Dominio.FolhaDePagamento.Holerite", b =>
                {
                    b.HasOne("GestaoDeRH.Dominio.Pessoas.Colaborador", "Colaborador")
                        .WithMany()
                        .HasForeignKey("ColaboradorId");

                    b.Navigation("Colaborador");
                });

            modelBuilder.Entity("GestaoDeRH.Dominio.FolhaDePagamento.LancamentoHolerite", b =>
                {
                    b.HasOne("GestaoDeRH.Dominio.FolhaDePagamento.Holerite", null)
                        .WithMany("Lancamentos")
                        .HasForeignKey("HoleriteId");
                });

            modelBuilder.Entity("GestaoDeRH.Dominio.Notificacao.Notificacao", b =>
                {
                    b.HasOne("GestaoDeRH.Dominio.Pessoas.Colaborador", "Destinatario")
                        .WithMany()
                        .HasForeignKey("DestinatarioId");

                    b.Navigation("Destinatario");
                });

            modelBuilder.Entity("GestaoDeRH.Dominio.Recrutamento.Candidato", b =>
                {
                    b.HasOne("GestaoDeRH.Dominio.Recrutamento.Vaga", "VagaAplicada")
                        .WithMany()
                        .HasForeignKey("VagaAplicadaId");

                    b.Navigation("VagaAplicada");
                });

            modelBuilder.Entity("GestaoDeRH.Dominio.Recrutamento.Vaga", b =>
                {
                    b.HasOne("GestaoDeRH.Dominio.Pessoas.Colaborador", "AbertaPor")
                        .WithMany()
                        .HasForeignKey("AbertaPorId");

                    b.Navigation("AbertaPor");
                });

            modelBuilder.Entity("GestaoDeRH.Dominio.FolhaDePagamento.Holerite", b =>
                {
                    b.Navigation("Lancamentos");
                });
#pragma warning restore 612, 618
        }
    }
}
