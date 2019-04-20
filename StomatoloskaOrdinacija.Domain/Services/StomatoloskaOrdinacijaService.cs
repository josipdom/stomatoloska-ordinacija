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


    }
}
