using StomatoloskaOrdinacija.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StomatoloskaOrdinacija.Domain.DTOs
{
    public class PacijentDTO
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "{0} je obvezno polje")]
        public string Ime { get; set; }

        [Required(ErrorMessage = "{0} je obvezno polje")]
        public string Prezime { get; set; }

        [Required(ErrorMessage = "{0} je obvezno polje")]
        [Display(Name="Datum rođenja")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        public DateTime DatumRodjenja { get; set; }

        [Required(ErrorMessage = "{0} je obvezno polje")]
        public string Telefon { get; set; }

        [Required(ErrorMessage = "{0} je obvezno polje")]
        public string Adresa { get; set; }

        public virtual ICollection<Narudzba> Narudzba { get; set; }
    }
}
