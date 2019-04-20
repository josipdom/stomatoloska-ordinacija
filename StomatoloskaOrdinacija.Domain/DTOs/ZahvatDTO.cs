using StomatoloskaOrdinacija.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StomatoloskaOrdinacija.Domain.DTOs
{
    public class ZahvatDTO
    {
        public int ID { get; set; }
        public int PacijentID { get; set; }
        public int Sifra { get; set; }
        public string Naziv { get; set; }
        public int Cijena { get; set; }
        public virtual Pacijent Pacijent { get; set; }
    }
}
