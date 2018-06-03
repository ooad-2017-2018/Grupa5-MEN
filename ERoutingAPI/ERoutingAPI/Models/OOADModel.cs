namespace ERoutingAPI.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class OOADModel : DbContext
    {
        public OOADModel()
            : base("name=OOADModel")
        {
        }

        public virtual DbSet<Administrator> Administrator { get; set; }
        public virtual DbSet<Dojava> Dojava { get; set; }
        public virtual DbSet<Korisnik> Korisnik { get; set; }
        public virtual DbSet<Ruta> Ruta { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dojava>()
                .Property(e => e.Mjesto)
                .IsUnicode(false);

            modelBuilder.Entity<Dojava>()
                .Property(e => e.VrstaDojave)
                .IsUnicode(false);

            modelBuilder.Entity<Korisnik>()
                .HasMany(e => e.Dojava)
                .WithOptional(e => e.Korisnik)
                .HasForeignKey(e => e.Korisnik_ID);

            modelBuilder.Entity<Korisnik>()
                .HasMany(e => e.Dojava1)
                .WithOptional(e => e.Korisnik1)
                .HasForeignKey(e => e.Korisnik_ID1);

            modelBuilder.Entity<Korisnik>()
                .HasMany(e => e.Dojava2)
                .WithOptional(e => e.Korisnik2)
                .HasForeignKey(e => e.Korisnik_ID2);

            modelBuilder.Entity<Korisnik>()
                .HasMany(e => e.Dojava3)
                .WithOptional(e => e.Korisnik3)
                .HasForeignKey(e => e.Korisnik1_ID);
        }
    }
}
