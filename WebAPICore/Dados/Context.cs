using Dominio.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Dados
{
    public class Context : DbContext  
    {
        public DbSet<Obra> Obras { get; set; }
        public DbSet<Instituicao> Instituicao { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Acervo;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Instituicao>()
                .HasMany(c => c.Obras);
               
        }

    }
}