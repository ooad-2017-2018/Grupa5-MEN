using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//neophodno uključiti kako bi se koristili DbContext i DbSet
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
namespace AspNet.Models
{
    public class Database : DbContext
    {
        public Database() : base("Model1")
            //AzureConnection je naziv connection stringa u Web.config-u
 {
        }
        //dodavanjem klasa iz modela kao DbSet iste će biti mapirane u bazu podataka
        public DbSet<Korisnik> Korisnik{ get; set; }
        public DbSet<Administrator> Administrator { get; set; }
        public DbSet<Dojava>Dojava { get; set; }
        public DbSet<Ruta> Ruta { get; set; }

        //Ova funkcija se koriste da bi se ukinulo automatsko dodavanje množine u nazive
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
