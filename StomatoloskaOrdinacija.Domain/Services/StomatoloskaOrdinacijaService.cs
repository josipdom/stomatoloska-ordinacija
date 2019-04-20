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
        public List<PacijentDTO> GetPopisPacijenata()
        {
            List<PacijentDTO> pacijentList = new List<PacijentDTO>();

            //zoveš bazu da ti vrati listu pacijenata db .ToList()
            List<Pacijent> pacijents = db.Pacijent.ToList();

            //Zoveš Mapper da mapiraš listu Db objekata u listu DTO-oeva
            StomatoloskaOrdinacijaMapper mapper = new StomatoloskaOrdinacijaMapper();
            foreach (var pacijentDb in pacijents)
            {
                PacijentDTO pacijentDTO = new PacijentDTO();
                mapper.MapPacijentDbToDTO(pacijentDTO, pacijentDb);

                pacijentList.Add(pacijentDTO);
            }

            return pacijentList;
        }

        public List<ZahvatDTO> GetPopisZahvata()
        {
            List<ZahvatDTO> zahvatList = new List<ZahvatDTO>();

            List<Zahvat> zahvati = db.Zahvat.ToList();

            StomatoloskaOrdinacijaMapper mapper = new StomatoloskaOrdinacijaMapper();
            foreach (var zahvatDb in zahvati)
            {
                ZahvatDTO zahvatDTO = new ZahvatDTO();
                mapper.MapZahvatDbToDTO(zahvatDTO, zahvatDb);

                zahvatList.Add(zahvatDTO);
            }

            return zahvatList;
        }

        public List<NarudzbaDTO> GetPopisNarudzba()
        {
            List<NarudzbaDTO> narudzbaList = new List<NarudzbaDTO>();

            List<Narudzba> narudzbe = db.Narudzba.ToList();

            StomatoloskaOrdinacijaMapper mapper = new StomatoloskaOrdinacijaMapper();
            foreach (var narudzbaDb in narudzbe)
            {
                NarudzbaDTO narudzbaDTO = new NarudzbaDTO();
                mapper.MapNarudzbaDbToDTO(narudzbaDTO, narudzbaDb);

                narudzbaList.Add(narudzbaDTO);
            }

            return narudzbaList;
        }


    }
}
