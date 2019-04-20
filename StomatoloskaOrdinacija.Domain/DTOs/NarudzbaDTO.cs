using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StomatoloskaOrdinacija.Domain.DTOs
{
    public class NarudzbaDTO
    {
        public int ID { get; set; }
        public string NazivNarudzbe { get; set; }
        public DateTime VrijemeOd { get; set; }
        public DateTime VrijemeDo { get; set; }
        public string OpisNarudzbe { get; set; }
        public string NazivPacijenta { get; set; }
        public bool Dolazak { get; set; }
    }
}
