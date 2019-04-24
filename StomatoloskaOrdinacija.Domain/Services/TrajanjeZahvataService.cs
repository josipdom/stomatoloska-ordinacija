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
    public class TrajanjeZahvataService
    {
        OrdinacijaDb db = new OrdinacijaDb();
        StomatoloskaOrdinacijaDTOBuilder dtoBuilder = new StomatoloskaOrdinacijaDTOBuilder();
        StomatoloskaOrdinacijaMapper dbMapper = new StomatoloskaOrdinacijaMapper();

        public List<TrajanjeZahvataDTO> GetPopisTrajanjeZahvata()
        {
            List<TrajanjeZahvataDTO> trajanjeZahvataDTOList = new List<TrajanjeZahvataDTO>();
            List<TrajanjeZahvata> trajanjeZahvataDbList = db.TrajanjeZahvata.ToList();

            dtoBuilder.FillTrajanjeZahvataDTOList(db, trajanjeZahvataDTOList, trajanjeZahvataDbList);

            return trajanjeZahvataDTOList;
        }

        public TrajanjeZahvataDTO GetTrajanjeZahvataById(int id)
        {
            TrajanjeZahvata trajanjeZahvataDb = db.TrajanjeZahvata
                .AsNoTracking()
                .Where(x => x.ID == id)
                .FirstOrDefault();

            TrajanjeZahvataDTO trajanjeZahvataDTO = new TrajanjeZahvataDTO();
            dtoBuilder.FillTrajanjeZahvataDTO(db, trajanjeZahvataDTO, trajanjeZahvataDb);

            return trajanjeZahvataDTO;
        }

        public void CreateNewTrajanjeZahvata(TrajanjeZahvataDTO trajanjeZahvataDTO)
        {
            TrajanjeZahvata trajanjeZahvataDb = dbMapper.MapTrajanjeZahvataDTOToDb(trajanjeZahvataDTO);

            db.TrajanjeZahvata.Add(trajanjeZahvataDb);
            db.SaveChanges();
        }

        public void DeleteTrajanjeZahvata(TrajanjeZahvataDTO trajanjeZahvataDTO)
        {
            TrajanjeZahvata trajanjeZahvatDb = dbMapper.MapTrajanjeZahvataDTOToDb(trajanjeZahvataDTO);

            db.TrajanjeZahvata.Attach(trajanjeZahvatDb);
            db.TrajanjeZahvata.Remove(trajanjeZahvatDb);
            db.SaveChanges();
        }

        public void EditTrajanjeZahvata(TrajanjeZahvataDTO trajanjeZahvataDTO)
        {
            TrajanjeZahvata trajanjeZahvatDb = dbMapper.MapTrajanjeZahvataDTOToDb(trajanjeZahvataDTO);

            db.Entry(trajanjeZahvatDb).State = EntityState.Modified;
            db.SaveChanges();

        }
    }
}
