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

        [StringLength(100)]
        public string NazivNarudzbe { get; set; }

        public DateTime VrijemeOd { get; set; }

        public DateTime VrijemeDo { get; set; }

        [Required]
        [StringLength(250)]
        public string OpisNarudzbe { get; set; }

        [Required]
        [StringLength(100)]
        public string NazivPacijenta { get; set; }

        public bool Dolazak { get; set; }
    }
}
