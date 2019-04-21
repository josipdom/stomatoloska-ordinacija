namespace StomatoloskaOrdinacija.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RadnoVrijeme")]
    public partial class RadnoVrijeme
    {
        public int ID { get; set; }

        public int VrijemeOd { get; set; }

        public int VrijemeDo { get; set; }
    }
}
