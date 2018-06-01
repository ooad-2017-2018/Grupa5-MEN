namespace AspNet.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Administrator> Administrators { get; set; }
        public virtual DbSet<Dojava> Dojavas { get; set; }
        public virtual DbSet<Korisnik> Korisniks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrator>()
                .Property(e => e.Ime)
                .IsUnicode(false);

            modelBuilder.Entity<Administrator>()
                .Property(e => e.Prezime)
                .IsUnicode(false);

            modelBuilder.Entity<Administrator>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<Administrator>()
                .Property(e => e.Pass)
                .IsUnicode(false);

            modelBuilder.Entity<Dojava>()
                .Property(e => e.Mjesto)
                .IsUnicode(false);

            modelBuilder.Entity<Korisnik>()
                .Property(e => e.Ime)
                .IsUnicode(false);

            modelBuilder.Entity<Korisnik>()
                .Property(e => e.Prezime)
                .IsUnicode(false);

            modelBuilder.Entity<Korisnik>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<Korisnik>()
                .Property(e => e.Pass)
                .IsUnicode(false);

            modelBuilder.Entity<Korisnik>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Korisnik>()
                .HasMany(e => e.Dojavas)
                .WithOptional(e => e.Korisnik)
                .HasForeignKey(e => e.Posiljalac);

            modelBuilder.Entity<Korisnik>()
                .HasMany(e => e.Dojavas1)
                .WithOptional(e => e.Korisnik1)
                .HasForeignKey(e => e.ZadnjiIzmjenio);
        }

        public System.Data.Entity.DbSet<AspNet.Models.Ruta> Rutas { get; set; }
    }
}
