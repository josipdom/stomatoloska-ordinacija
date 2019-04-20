using StomatoloskaOrdinacija.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StomatoloskaOrdinacija.Domain.DTOs
{
    public class PacijentDTO
    {
        public int ID { get; set; }
        public string ImePacijenta { get; set; }
        public string PrezimePacijenta { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string Telefon { get; set; }
        public string Adresa { get; set; }
        public virtual ICollection<Zahvat> Zahvat { get; set; }
    }
}
