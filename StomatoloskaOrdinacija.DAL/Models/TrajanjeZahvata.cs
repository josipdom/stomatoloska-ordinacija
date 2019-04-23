namespace StomatoloskaOrdinacija.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TrajanjeZahvata")]
    public partial class TrajanjeZahvata
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TrajanjeZahvata()
        {
            Zahvat = new HashSet<Zahvat>();
        }

        public int ID { get; set; }

        public DateTime Trajanje { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Zahvat> Zahvat { get; set; }
    }
}
