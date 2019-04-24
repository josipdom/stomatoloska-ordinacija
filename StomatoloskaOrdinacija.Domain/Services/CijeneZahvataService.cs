using StomatoloskaOrdinacija.DAL;
using StomatoloskaOrdinacija.Domain.Builders;
using StomatoloskaOrdinacija.Domain.DTOs;
using StomatoloskaOrdinacija.Domain.Mappers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StomatoloskaOrdinacija.Domain.Services
{
    public class CijeneZahvataService
    {
        OrdinacijaDb db = new OrdinacijaDb();
        StomatoloskaOrdinacijaDTOBuilder dtoBuilder = new StomatoloskaOrdinacijaDTOBuilder();
        StomatoloskaOrdinacijaMapper dbMapper = new StomatoloskaOrdinacijaMapper();

        public List<CijenaZahvataDTO> GetPopisCijenaZahvata()
        {
            List<CijenaZahvataDTO> cijenaZahvataDTOList = new List<CijenaZahvataDTO>();
            List<CijenaZahvata> cijenaZahvataDbList = db.CijenaZahvata.ToList();

            dtoBuilder.FillCijenaZahvataDTOList(db, cijenaZahvataDTOList, cijenaZahvataDbList);

            return cijenaZahvataDTOList;
        }

        public CijenaZahvataDTO GetCijenaZahvataById(int id)
        {
            CijenaZahvata cijenaZahvataDb = db.CijenaZahvata
                .AsNoTracking()
                .Where(x => x.ID == id)
                .FirstOrDefault();

            CijenaZahvataDTO cijenaZahvataDTO = new CijenaZahvataDTO();
            dtoBuilder.FillCijenaZahvataDTO(db, cijenaZahvataDTO, cijenaZahvataDb);

            return cijenaZahvataDTO;
        }

        public void CreateNewCijenaZahvata(CijenaZahvataDTO cijenaZahvataDTO)
        {
            CijenaZahvata cijenaZahvataDb = dbMapper.MapCijenaZahvataDTOToDb(cijenaZahvataDTO);

            db.CijenaZahvata.Add(cijenaZahvataDb);
            db.SaveChanges();
        }

        public void DeleteCijenaZahvata(CijenaZahvataDTO cijenaZahvataDTO)
        {
            CijenaZahvata cijenaZahvatDb = dbMapper.MapCijenaZahvataDTOToDb(cijenaZahvataDTO);

            db.CijenaZahvata.Attach(cijenaZahvatDb);
            db.CijenaZahvata.Remove(cijenaZahvatDb);
            db.SaveChanges();
        }

        public void EditCijenaZahvata(CijenaZahvataDTO cijenaZahvataDTO)
        {
            CijenaZahvata cijenaZahvatDb = dbMapper.MapCijenaZahvataDTOToDb(cijenaZahvataDTO);

            db.Entry(cijenaZahvatDb).State = EntityState.Modified;
            db.SaveChanges();

        }
    }
}
