using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StomatoloskaOrdinacija.Domain.DTOs
{
    public class RadnoVrijemeDTO
    {
        public int ID { get; set; }

        //int zbog syncfusion komponente
        [Display(Name = "Vrijeme od")]
        [Range(0,23, ErrorMessage = "Upišite sat kao cijeli broj između 0 i 23")]
        public int VrijemeOd { get; set; }

        [Display(Name = "Vrijeme do")]
        [Range(0,23, ErrorMessage = "Upišite sat kao cijeli broj između 0 i 23")]
        public int VrijemeDo { get; set; }
    }
}
