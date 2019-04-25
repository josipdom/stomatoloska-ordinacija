using StomatoloskaOrdinacija.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace StomatoloskaOrdinacija.Domain.DTOs
{
    public class NarudzbaDTO
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Datum je obvezno polje")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        public DateTime Datum { get; set; }

        [Required(ErrorMessage = "Sati su obvezno polje")]
        [Range(0, 23, ErrorMessage = "Sati moraju biti u rasponu od 0 do 23")]
        public int Sati { get; set; }

        [Required(ErrorMessage = "Minute su obvezno polje")]
        [Range(0, 59, ErrorMessage = "Minute moraju biti u rasponu od 0 do 59")]
        public int Minute { get; set; }

        public DateTime Vrijeme { get; set; }

        [Required(ErrorMessage = "Opis je obvezno polje")]
        [StringLength(250)]
        public string Opis { get; set; }

        public int PacijentID { get; set; }

        public int ZahvatID { get; set; }

        public bool Dolazak { get; set; }

        public DateTime VrijemeZavrsetkaZahvata { get; set; }

        public List<SelectListItem> PacijentListDTO { get; set; }

        public List<SelectListItem> ZahvatListDTO { get; set; }
    }
}
