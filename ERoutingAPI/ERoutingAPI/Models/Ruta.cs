namespace ERoutingAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ruta")]
    public partial class Ruta
    {
        public int Id { get; set; }

        public string Start { get; set; }

        public string Kraj { get; set; }

        public DateTime VrijemePutovanja { get; set; }
    }
}
