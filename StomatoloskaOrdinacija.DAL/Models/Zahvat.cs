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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Zahvat()
        {
            Narudzba = new HashSet<Narudzba>();
        }

        public int ID { get; set; }

        public int Sifra { get; set; }

        [Required]
        [StringLength(150)]
        public string Naziv { get; set; }

        public int Cijena { get; set; }

        public int Trajanje { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Narudzba> Narudzba { get; set; }
    }
}
