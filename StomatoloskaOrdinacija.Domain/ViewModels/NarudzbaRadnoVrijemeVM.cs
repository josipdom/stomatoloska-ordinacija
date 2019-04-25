using StomatoloskaOrdinacija.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StomatoloskaOrdinacija.Domain.ViewModels
{
    public class NarudzbaRadnoVrijemeVM
    {
        public List<NarudzbaDTO> NarudzbaDTOList { get; set; }

        public RadnoVrijemeDTO RadnoVrijemeDTO { get; set; }
    }
}
