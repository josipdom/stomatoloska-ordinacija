using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StomatoloskaOrdinacija.Domain.DTOs
{
    public class CijenaZahvataDTO
    {
        public int ID { get; set; }

        //Pretpostavka da je najskulji tretman 1000kn
        [Required(ErrorMessage = "Cijena je obvezno polje")]
        [Range(0, 1000, ErrorMessage = "Cijena mora biti između 0 i 1000 kuna")]
        public int Cijena { get; set; }
    }
}
