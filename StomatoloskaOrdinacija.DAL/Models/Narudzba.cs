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

        public DateTime Vrijeme { get; set; }

        [StringLength(250)]
        public string Opis { get; set; }

        public int PacijentID { get; set; }

        public int ZahvatID { get; set; }

        public bool Dolazak { get; set; }

        public virtual Pacijent Pacijent { get; set; }

        public virtual Zahvat Zahvat { get; set; }
    }
}
