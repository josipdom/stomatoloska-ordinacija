using StomatoloskaOrdinacija.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StomatoloskaOrdinacija.Domain.DTOs
{
    public class NarudzbaDTO
    {
        public int ID { get; set; }
        public DateTime VrijemeOd { get; set; }
        public DateTime VrijemeDo { get; set; }
        public int SatiOd { get; set; }
        public int SatiDo { get; set; }

        [StringLength(250)]
        public string Opis { get; set; }

        public int PacijentID { get; set; }
        public int ZahvatID { get; set; }
        public bool Dolazak { get; set; }
        public virtual Pacijent Pacijent { get; set; }
        public virtual Zahvat Zahvat { get; set; }
    }
}
