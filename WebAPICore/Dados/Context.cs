using Dominio.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Dados
{
    public class Context : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=acervo;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ObraInstituicao>()
              .HasKey(oi => new { oi.ObraId, oi.InstituicaoId});
            modelBuilder.Entity<ObraInstituicao>()
                .HasOne(oi => oi.Obra)
                .WithMany(b => b.ObraInstituicao)
                .HasForeignKey(oi => oi.ObraId);
            modelBuilder.Entity<ObraInstituicao>()
                .HasOne(bc => bc.Instituicao)
                .WithMany(c => c.ObraInstituicao)
                .HasForeignKey(bc => bc.InstituicaoId);
        }

    }
}