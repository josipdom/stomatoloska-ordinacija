using StomatoloskaOrdinacija.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StomatoloskaOrdinacija.Domain.DTOs
{
    public class ZahvatDTO
    {
        public int ID { get; set; }

        public int Sifra { get; set; }

        [Required]
        [StringLength(150)]
        public string Naziv { get; set; }

        public int Cijena { get; set; }

        public int Trajanje { get; set; }

        public virtual ICollection<Narudzba> Narudzba { get; set; }
    }
}
