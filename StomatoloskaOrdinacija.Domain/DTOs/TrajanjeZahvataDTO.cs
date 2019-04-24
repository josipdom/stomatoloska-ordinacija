using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StomatoloskaOrdinacija.Domain.DTOs
{
    public class TrajanjeZahvataDTO
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Trajanje zahvata je obvezno polje")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        [DataType(DataType.Time)]
        public DateTime Trajanje { get; set; }
    }
}
