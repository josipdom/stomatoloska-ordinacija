using StomatoloskaOrdinacija.DAL;
using StomatoloskaOrdinacija.Domain.DTOs;
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

        public Zahvat MapZahvatDTOToDb(ZahvatDTO zahvatDTO)
        {
            Zahvat zahvat = new Zahvat();
            zahvat.ID = zahvatDTO.ID;
            zahvat.Sifra = zahvatDTO.Sifra;
            zahvat.Naziv = zahvatDTO.Naziv;
            zahvat.CijenaID = zahvatDTO.CijenaID;
            zahvat.TrajanjeID = zahvatDTO.TrajanjeID;

            return zahvat;
        }

        public Narudzba MapNarudzbaDTOToDb(OrdinacijaDb db, NarudzbaDTO narudzbaDTO)
        {
            TrajanjeZahvata trajanjeZahvata = GetTrajanjeForZahvatId(db, narudzbaDTO.ZahvatID);

            Narudzba narudzba = new Narudzba();
            narudzba.ID = narudzbaDTO.ID;
            narudzba.Vrijeme = narudzbaDTO.Datum.AddHours(narudzbaDTO.Sati).AddMinutes(narudzbaDTO.Minute);
            narudzba.VrijemeZavrsetkaZahvata = narudzba.Vrijeme
                .AddHours(trajanjeZahvata.Trajanje.Hour)
                .AddMinutes(trajanjeZahvata.Trajanje.Minute);
            narudzba.Opis = narudzbaDTO.Opis;
            narudzba.PacijentID = narudzbaDTO.PacijentID;
            narudzba.ZahvatID = narudzbaDTO.ZahvatID;
            narudzba.Dolazak = narudzbaDTO.Dolazak;

            return narudzba;
        }

        public RadnoVrijeme MapRadnoVrijemeDTOToDb(RadnoVrijemeDTO radnoVrijemeDTO)
        {
            RadnoVrijeme radnoVrijeme = new RadnoVrijeme();
            radnoVrijeme.ID = radnoVrijemeDTO.ID;
            radnoVrijeme.VrijemeOd = radnoVrijemeDTO.VrijemeOd;
            radnoVrijeme.VrijemeDo = radnoVrijemeDTO.VrijemeDo;

            return radnoVrijeme;
        }

        public CijenaZahvata MapCijenaZahvataDTOToDb(CijenaZahvataDTO cijenaZahvataDTO)
        {
            CijenaZahvata cijenaZahvata = new CijenaZahvata();
            cijenaZahvata.ID = cijenaZahvataDTO.ID;
            cijenaZahvata.Cijena = cijenaZahvataDTO.Cijena;

            return cijenaZahvata;
        }

        public TrajanjeZahvata MapTrajanjeZahvataDTOToDb(TrajanjeZahvataDTO trajanjeZahvataDTO)
        {
            TrajanjeZahvata trajanjeZahvata = new TrajanjeZahvata();
            trajanjeZahvata.ID = trajanjeZahvataDTO.ID;
            trajanjeZahvata.Trajanje = trajanjeZahvataDTO.Trajanje;

            return trajanjeZahvata;
        }

        private TrajanjeZahvata GetTrajanjeForZahvatId(OrdinacijaDb db, int zahvatId)
        {
            TrajanjeZahvata t = db.Zahvat
                .Where(x => x.ID == zahvatId)
                .Select(x => x.TrajanjeZahvata)
                .Single();

            return t;
        }
    }
}
