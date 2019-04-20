namespace StomatoloskaOrdinacija.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Zahvat")]
    public partial class Zahvat
    {
        public int ID { get; set; }

        public int PacijentID { get; set; }

        public int Sifra { get; set; }

        [Required]
        [StringLength(150)]
        public string Naziv { get; set; }

        public int Cijena { get; set; }

        public virtual Pacijent Pacijent { get; set; }
    }
}
