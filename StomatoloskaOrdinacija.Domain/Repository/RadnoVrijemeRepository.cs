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

namespace StomatoloskaOrdinacija.Domain.Repository
{
    public class RadnoVrijemeRepository
    {
        OrdinacijaDb db = new OrdinacijaDb();
        StomatoloskaOrdinacijaDTOBuilder dtoBuilder = new StomatoloskaOrdinacijaDTOBuilder();
        StomatoloskaOrdinacijaMapper dbMapper = new StomatoloskaOrdinacijaMapper();

        public RadnoVrijemeDTO GetRadnoVrijemeById(int id)
        {
            RadnoVrijeme radnoVrijemeDb = db.RadnoVrijeme
                .AsNoTracking()
                .Where(x => x.ID == id)
                .FirstOrDefault();

            RadnoVrijemeDTO radnoVrijemeDTO = new RadnoVrijemeDTO();
            dtoBuilder.FillRadnoVrijemeDTO(db, radnoVrijemeDTO, radnoVrijemeDb);

            return radnoVrijemeDTO;
        }

        public void EditRadnoVrijeme(RadnoVrijemeDTO radnoVrijemeDTO)
        {
            RadnoVrijeme radnoVrijemeDb = dbMapper.MapRadnoVrijemeDTOToDb(radnoVrijemeDTO);

            db.Entry(radnoVrijemeDb).State = EntityState.Modified;
            db.SaveChanges();

        }

        public int GetRadnoVrijemeId()
        {
            RadnoVrijeme radnoVrijeme = db.RadnoVrijeme.FirstOrDefault();
            var radnoVrijemeId = radnoVrijeme.ID;

            return radnoVrijemeId;
        }
    }
}
