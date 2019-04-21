using StomatoloskaOrdinacija.DAL;
using StomatoloskaOrdinacija.Domain.DTOs;
using StomatoloskaOrdinacija.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StomatoloskaOrdinacija.Domain.Mappers
{
    public class StomatoloskaOrdinacijaMapper
    {
        public Pacijent MapPacijentDTOToDb(PacijentDTO pacijentDTO)
        {
            Pacijent pacijent = new Pacijent();
            pacijent.ID = pacijentDTO.ID;
            pacijent.Ime = pacijentDTO.Ime;
            pacijent.Prezime = pacijentDTO.Prezime;
            pacijent.DatumRodjenja = pacijentDTO.DatumRodjenja;
            pacijent.Telefon = pacijentDTO.Telefon;
            pacijent.Adresa = pacijentDTO.Adresa;

            return pacijent;
        }
    }
}
