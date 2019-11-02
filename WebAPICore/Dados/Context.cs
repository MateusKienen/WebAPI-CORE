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
        //    modelBuilder.Entity<Instituicao>()
        //.HasMany(c => c.Obras)
        //.WithOne(e => e.Company);
        }

    }
}