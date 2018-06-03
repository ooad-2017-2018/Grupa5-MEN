namespace ERoutingAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Korisnik")]
    public partial class Korisnik
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Korisnik()
        {
            Dojava = new HashSet<Dojava>();
            Dojava1 = new HashSet<Dojava>();
            Dojava2 = new HashSet<Dojava>();
            Dojava3 = new HashSet<Dojava>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [StringLength(30)]
        public string Ime { get; set; }

        [StringLength(30)]
        public string Prezime { get; set; }

        [StringLength(30)]
        public string Username { get; set; }

        [StringLength(30)]
        public string Pass { get; set; }

        [StringLength(30)]
        public string Email { get; set; }

        public int? BrojDojava { get; set; }

        public int? BrojAktivnihDojava { get; set; }

        [Column(TypeName = "image")]
        public byte[] SlikaProfila { get; set; }

        public int? RememberMe { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Dojava> Dojava { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Dojava> Dojava1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Dojava> Dojava2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Dojava> Dojava3 { get; set; }
    }
}
