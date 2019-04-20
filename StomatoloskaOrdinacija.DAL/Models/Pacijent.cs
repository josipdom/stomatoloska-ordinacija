namespace StomatoloskaOrdinacija.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Pacijent")]
    public partial class Pacijent
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pacijent()
        {
            Zahvat = new HashSet<Zahvat>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string ImePacijenta { get; set; }

        [Required]
        [StringLength(50)]
        public string PrezimePacijenta { get; set; }

        public DateTime DatumRodjenja { get; set; }

        [Required]
        [StringLength(15)]
        public string Telefon { get; set; }

        [StringLength(100)]
        public string Adresa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Zahvat> Zahvat { get; set; }
    }
}
