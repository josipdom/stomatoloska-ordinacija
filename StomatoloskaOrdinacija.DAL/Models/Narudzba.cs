namespace StomatoloskaOrdinacija.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Narudzba")]
    public partial class Narudzba
    {
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string Naziv { get; set; }

        public DateTime VrijemeOd { get; set; }

        public DateTime VrijemeDo { get; set; }

        [StringLength(250)]
        public string Opis { get; set; }

        public int PacijentID { get; set; }

        public bool Dolazak { get; set; }

        public virtual Pacijent Pacijent { get; set; }
    }
}
