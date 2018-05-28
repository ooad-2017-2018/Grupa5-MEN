namespace AspNet.Models
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
            Dojavas = new HashSet<Dojava>();
            Dojavas1 = new HashSet<Dojava>();
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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Dojava> Dojavas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Dojava> Dojavas1 { get; set; }
    }
}
