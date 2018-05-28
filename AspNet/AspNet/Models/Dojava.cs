namespace AspNet.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Dojava")]
    public partial class Dojava
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [StringLength(30)]
        public string Mjesto { get; set; }

        public DateTime? VrijemeDojave { get; set; }

        public int? TrajanjeDojave { get; set; }

        public int? Posiljalac { get; set; }

        public int? ZadnjiIzmjenio { get; set; }

        public virtual Korisnik Korisnik { get; set; }

        public virtual Korisnik Korisnik1 { get; set; }
    }
}
