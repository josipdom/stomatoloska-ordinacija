using StomatoloskaOrdinacija.DAL;
using StomatoloskaOrdinacija.Domain.DTOs;
using StomatoloskaOrdinacija.Domain.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using StomatoloskaOrdinacija.Domain.Builders;

namespace StomatoloskaOrdinacija.Domain.Services
{
    public class StomatoloskaOrdinacijaService
    {
        OrdinacijaDb db = new OrdinacijaDb();
        StomatoloskaOrdinacijaDTOBuilder dtoBuilder = new StomatoloskaOrdinacijaDTOBuilder();
        StomatoloskaOrdinacijaMapper dbMapper = new StomatoloskaOrdinacijaMapper();

        public List<PacijentDTO> GetPopisPacijenata()
        {
            List<PacijentDTO> pacijentDTOList = new List<PacijentDTO>();

            //zoveš bazu da ti vrati listu pacijenata db .ToList()
            List<Pacijent> pacijentiDbList = db.Pacijent.ToList();

            //Zoveš Mapper da mapiraš listu Db objekata u listu DTO-oeva
            dtoBuilder.FillPacijentDTOList(pacijentDTOList, pacijentiDbList);
            
            return pacijentDTOList;
        }

        public List<ZahvatDTO> GetPopisZahvata()
        {
            List<ZahvatDTO> zahvatDTOList = new List<ZahvatDTO>();
            List<Zahvat> zahvatiDbList = db.Zahvat.ToList();

            dtoBuilder.FillZahvatDTOList(zahvatDTOList, zahvatiDbList);

            return zahvatDTOList;
        }

        public List<NarudzbaDTO> GetPopisNarudzba()
        {
            List<NarudzbaDTO> narudzbaDTOList = new List<NarudzbaDTO>();
            List<Narudzba> narudzbeDbList = db.Narudzba.ToList();

            dtoBuilder.FillNarudzbaDTOList(narudzbaDTOList, narudzbeDbList);

            return narudzbaDTOList;
        }

        public PacijentDTO GetPacijentById(int id)
        {
            Pacijent pacijentDb = db.Pacijent
                .AsNoTracking()
                .Where(x => x.ID == id)
                .FirstOrDefault();

            PacijentDTO pacijentDTO = new PacijentDTO();
            dtoBuilder.FillPacijentDTO(pacijentDTO, pacijentDb);

            return pacijentDTO;
        }

        public void CreateNewPacijent(PacijentDTO pacijentDTO)
        {
            Pacijent pacijentDb = dbMapper.MapPacijentDTOToDb(pacijentDTO);

            db.Pacijent.Add(pacijentDb);
            db.SaveChanges();
        }

        public void DeletePacijent(PacijentDTO pacijentDTO)
        {
            Pacijent pacijentDb = dbMapper.MapPacijentDTOToDb(pacijentDTO);

            db.Pacijent.Attach(pacijentDb);
            db.Pacijent.Remove(pacijentDb);
            db.SaveChanges();
        }

        public void EditPacijent(PacijentDTO pacijentDTO)
        {
            Pacijent pacijentDb = dbMapper.MapPacijentDTOToDb(pacijentDTO);

            db.Entry(pacijentDb).State = EntityState.Modified;
            db.SaveChanges();

        }
    }
}
