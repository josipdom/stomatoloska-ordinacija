using StomatoloskaOrdinacija.DAL;
using StomatoloskaOrdinacija.Domain.Builders;
using StomatoloskaOrdinacija.Domain.DTOs;
using StomatoloskaOrdinacija.Domain.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StomatoloskaOrdinacija.Domain.Repository
{
    public class NarudzbeRepository
    {
        OrdinacijaDb db = new OrdinacijaDb();
        StomatoloskaOrdinacijaDTOBuilder dtoBuilder = new StomatoloskaOrdinacijaDTOBuilder();
        StomatoloskaOrdinacijaMapper dbMapper = new StomatoloskaOrdinacijaMapper();

        public List<NarudzbaDTO> GetPopisNarudzba()
        {
            List<NarudzbaDTO> narudzbaDTOList = new List<NarudzbaDTO>();
            List<Narudzba> narudzbeDbList = db.Narudzba.ToList();

            dtoBuilder.FillNarudzbaDTOList(narudzbaDTOList, narudzbeDbList);

            return narudzbaDTOList;
        }
    }
}
