using StomatoloskaOrdinacija.DAL;
using StomatoloskaOrdinacija.Domain.DTOs;
using StomatoloskaOrdinacija.Domain.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace StomatoloskaOrdinacija.Domain.Services
{
    public class StomatoloskaOrdinacijaService
    {
        OrdinacijaDb db = new OrdinacijaDb();
        StomatoloskaOrdinacijaMapper mapper = new StomatoloskaOrdinacijaMapper();

        public List<PacijentDTO> GetPopisPacijenata()
        {
            List<PacijentDTO> pacijentDTOList = new List<PacijentDTO>();

            //zoveš bazu da ti vrati listu pacijenata db .ToList()
            List<Pacijent> pacijentiDbList = db.Pacijent.ToList();

            //Zoveš Mapper da mapiraš listu Db objekata u listu DTO-oeva
            mapper.MapPacijentDbToDTOList(pacijentDTOList, pacijentiDbList);
            
            return pacijentDTOList;
        }

        public List<ZahvatDTO> GetPopisZahvata()
        {
            List<ZahvatDTO> zahvatDTOList = new List<ZahvatDTO>();
            List<Zahvat> zahvatiDbList = db.Zahvat.ToList();

            mapper.MapZahvatDbToDTOList(zahvatDTOList, zahvatiDbList);

            return zahvatDTOList;
        }

        public List<NarudzbaDTO> GetPopisNarudzba()
        {
            List<NarudzbaDTO> narudzbaDTOList = new List<NarudzbaDTO>();
            List<Narudzba> narudzbeDbList = db.Narudzba.ToList();

            mapper.MapNarudzbaDbToDTOList(narudzbaDTOList, narudzbeDbList);

            return narudzbaDTOList;
        }


    }
}
