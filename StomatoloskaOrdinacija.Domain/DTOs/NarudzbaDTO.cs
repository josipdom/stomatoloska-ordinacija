using StomatoloskaOrdinacija.DAL;
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
        public string Naziv { get; set; }
        public DateTime VrijemeOd { get; set; }
        public DateTime VrijemeDo { get; set; }
        public string Opis { get; set; }
        public int PacijentID { get; set; }
        public bool Dolazak { get; set; }
        public virtual Pacijent Pacijent { get; set; }
    }
}
