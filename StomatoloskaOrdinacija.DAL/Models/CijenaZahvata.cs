namespace StomatoloskaOrdinacija.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CijenaZahvata")]
    public partial class CijenaZahvata
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CijenaZahvata()
        {
            Zahvat = new HashSet<Zahvat>();
        }

        public int ID { get; set; }

        public int Cijena { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Zahvat> Zahvat { get; set; }
    }
}
