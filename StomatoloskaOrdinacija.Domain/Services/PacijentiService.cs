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
    public class PacijentiService
    {
        OrdinacijaDb db = new OrdinacijaDb();
        StomatoloskaOrdinacijaDTOBuilder dtoBuilder = new StomatoloskaOrdinacijaDTOBuilder();
        StomatoloskaOrdinacijaMapper dbMapper = new StomatoloskaOrdinacijaMapper();

        public List<PacijentDTO> GetPopisPacijenata()
        {
            List<PacijentDTO> pacijentDTOList = new List<PacijentDTO>();

            List<Pacijent> pacijentiDbList = db.Pacijent.ToList();

            dtoBuilder.FillPacijentDTOList(db, pacijentDTOList, pacijentiDbList);
            
            return pacijentDTOList;
        }

        public PacijentDTO GetPacijentById(int id)
        {
            Pacijent pacijentDb = db.Pacijent
                .AsNoTracking()
                .Where(x => x.ID == id)
                .FirstOrDefault();

            PacijentDTO pacijentDTO = new PacijentDTO();
            dtoBuilder.FillPacijentDTO(db, pacijentDTO, pacijentDb);

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
