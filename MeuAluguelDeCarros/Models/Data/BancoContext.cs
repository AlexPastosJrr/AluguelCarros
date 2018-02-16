using MeuAluguelDeCarros.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace MeuAluguelDeCarros.Models.Data
{
    public class BancoContext : DbContext
    {
        public DbSet<Carro> Carros { get; set; }
        public DbSet<Aluguel> Aluguel { get; set; }

        public BancoContext() : base("BancoAluguel")
        {
            Database.Log = sql => Debug.WriteLine(sql);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(typeof(BancoContext).Assembly);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}