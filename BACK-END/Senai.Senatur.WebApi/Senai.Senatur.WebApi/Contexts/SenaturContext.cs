﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Senai.Senatur.WebApi.Domains
{
    /// <summary>
    /// Classe responsável pelo contexto do projeto
    /// Faz a comunicação entre API e Banco de Dados
    /// </summary>
    public partial class SenaturContext : DbContext
    {
        public SenaturContext()
        {
        }

        public SenaturContext(DbContextOptions<SenaturContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cidades> Cidades { get; set; }
        public virtual DbSet<Pacotes> Pacotes { get; set; }
        public virtual DbSet<TiposUsuario> TiposUsuario { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=N-1S-DEV-12\\SQLEXPRESS; Initial Catalog=Senatur_Manha; user Id=sa; pwd=sa@132;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cidades>(entity =>
            {
                entity.HasKey(e => e.IdCidade);

                entity.Property(e => e.NomeCidade)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Pacotes>(entity =>
            {
                entity.HasKey(e => e.IdPacote);

                entity.Property(e => e.Ativo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.DataIda).HasColumnType("date");

                entity.Property(e => e.DataVolta).HasColumnType("date");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.NomePacote)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCidadeNavigation)
                    .WithMany(p => p.Pacotes)
                    .HasForeignKey(d => d.IdCidade)
                    .HasConstraintName("FK__Pacotes__IdCidad__3A81B327");
            });

            modelBuilder.Entity<TiposUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario);

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .HasConstraintName("FK__Usuarios__IdTipo__3F466844");
            });
        }
    }
}
