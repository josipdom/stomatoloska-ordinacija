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
    public class ZahvatiService
    {
        OrdinacijaDb db = new OrdinacijaDb();
        StomatoloskaOrdinacijaDTOBuilder dtoBuilder = new StomatoloskaOrdinacijaDTOBuilder();
        StomatoloskaOrdinacijaMapper dbMapper = new StomatoloskaOrdinacijaMapper();

        public List<ZahvatDTO> GetPopisZahvata()
        {
            List<ZahvatDTO> zahvatDTOList = new List<ZahvatDTO>();
            List<Zahvat> zahvatiDbList = db.Zahvat.ToList();

            dtoBuilder.FillZahvatDTOList(db, zahvatDTOList, zahvatiDbList);

            return zahvatDTOList;
        }

        public ZahvatDTO GetZahvatById(int id)
        {
            Zahvat zahvatDb = db.Zahvat
                .AsNoTracking()
                .Where(x => x.ID == id)
                .FirstOrDefault();

            ZahvatDTO zahvatDTO = new ZahvatDTO();
            dtoBuilder.FillZahvatDTO(db, zahvatDTO, zahvatDb);

            return zahvatDTO;
        }

        public void CreateNewZahvat(ZahvatDTO zahvatDTO)
        {
            Zahvat zahvatDb = dbMapper.MapZahvatDTOToDb(zahvatDTO);
            
            db.Zahvat.Add(zahvatDb);
            db.SaveChanges();
        }

        public ZahvatDTO GetEmptyZahvat()
        {
            ZahvatDTO zahvatDTO = new ZahvatDTO();
            zahvatDTO = dtoBuilder.FillDDLPacijentTrajanje(db, zahvatDTO);

            return zahvatDTO;
        }

        public void DeleteZahvat(ZahvatDTO zahvatDTO)
        {
            Zahvat zahvatDb = dbMapper.MapZahvatDTOToDb(zahvatDTO);

            db.Zahvat.Attach(zahvatDb);
            db.Zahvat.Remove(zahvatDb);
            db.SaveChanges();
        }

        public void EditZahvat(ZahvatDTO zahvatDTO)
        {
            Zahvat zahvatDb = dbMapper.MapZahvatDTOToDb(zahvatDTO);

            db.Entry(zahvatDb).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void FillDDLPacijentTrajanje(ZahvatDTO zahvatDTO)
        {
            dtoBuilder.FillDDLPacijentTrajanje(db, zahvatDTO);
        }
    }
}
