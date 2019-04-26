using StomatoloskaOrdinacija.DAL;
using StomatoloskaOrdinacija.Domain.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace StomatoloskaOrdinacija.Domain.DTOs
{
    public class ZahvatDTO
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "{0} je obvezno polje")]
        [Display(Name = "Šifra")]
        [StringLength(5, MinimumLength = 0, ErrorMessage = "Maksimalno 5 znamenki")]
        public string Sifra { get; set; }

        [StringLength(150)]
        [Required(ErrorMessage = "{0} je obvezno polje")]
        public string Naziv { get; set; }

        [Display(Name = "Cijena u kunama")]
        [Required(ErrorMessage = "{0} je obvezno polje")]
        public int CijenaID { get; set; }

        [Display(Name = "Trajanje")]
        [Required(ErrorMessage = "{0} je obvezno polje")]
        public int TrajanjeID { get; set; }

        public string Cijena { get; set; }

        public string Trajanje { get; set; }

        public List<SelectListItem> CijenaListDTO { get; set; }

        public List<SelectListItem> TrajanjeListDTO { get; set; }
    }
}
