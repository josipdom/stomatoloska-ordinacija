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
    public class NarudzbeService
    {
        OrdinacijaDb db = new OrdinacijaDb();
        StomatoloskaOrdinacijaDTOBuilder dtoBuilder = new StomatoloskaOrdinacijaDTOBuilder();
        StomatoloskaOrdinacijaMapper dbMapper = new StomatoloskaOrdinacijaMapper();

        public List<NarudzbaDTO> GetPopisNarudzba()
        {
            List<NarudzbaDTO> narudzbaDTOList = new List<NarudzbaDTO>();
            List<Narudzba> narudzbeDbList = db.Narudzba.ToList();

            dtoBuilder.FillNarudzbaDTOList(db, narudzbaDTOList, narudzbeDbList);

            return narudzbaDTOList;
        }

        public NarudzbaDTO GetNarudzbaById(int id)
        {
            Narudzba narudzbaDb = db.Narudzba
                .AsNoTracking()
                .Where(x => x.ID == id)
                .FirstOrDefault();

            NarudzbaDTO narudzbaDTO = new NarudzbaDTO();
            dtoBuilder.FillNarudzbaDTO(db, narudzbaDTO, narudzbaDb);

            return narudzbaDTO;
        }

        public void CreateNewNarudzba(NarudzbaDTO narudzbaDTO)
        {
            Narudzba narudzbaDb = dbMapper.MapNarudzbaDTOToDb(narudzbaDTO);

            db.Narudzba.Add(narudzbaDb);
            db.SaveChanges();
        }

        public NarudzbaDTO GetEmptyNarudzba()
        {
            NarudzbaDTO narudzbaDTO = dtoBuilder.PrepareNarudzbaDTOForCreate(db);
            return narudzbaDTO;
        }

        public void DeleteNarudzba(NarudzbaDTO narudzbaDTO)
        {
            Narudzba narudzbaDb = dbMapper.MapNarudzbaDTOToDb(narudzbaDTO);

            db.Narudzba.Attach(narudzbaDb);
            db.Narudzba.Remove(narudzbaDb);
            db.SaveChanges();
        }

        public void EditNarudzba(NarudzbaDTO narudzbaDTO)
        {
            Narudzba narudzbaDb = dbMapper.MapNarudzbaDTOToDb(narudzbaDTO);

            db.Entry(narudzbaDb).State = EntityState.Modified;
            db.SaveChanges();

        }
    }
}
