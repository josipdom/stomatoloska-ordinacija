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

        [Required]
        [StringLength(5)]
        public string Sifra { get; set; }

        [Required]
        [StringLength(150)]
        public string Naziv { get; set; }

        public int CijenaID { get; set; }

        public int TrajanjeID { get; set; }

        public virtual CijenaZahvata CijenaZahvata { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Narudzba> Narudzba { get; set; }

        public virtual TrajanjeZahvata TrajanjeZahvata { get; set; }
    }
}
