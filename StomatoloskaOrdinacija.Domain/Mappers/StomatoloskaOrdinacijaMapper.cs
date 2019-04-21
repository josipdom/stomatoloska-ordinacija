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

        public Zahvat MapZahvatDTOToDb(ZahvatDTO zahvatDTO)
        {
            Zahvat zahvat = new Zahvat();
            zahvat.ID = zahvatDTO.ID;
            zahvat.Sifra = zahvatDTO.Sifra;
            zahvat.Naziv = zahvatDTO.Naziv;
            zahvat.Cijena = zahvatDTO.Cijena;
            zahvat.Trajanje = zahvatDTO.Trajanje;

            return zahvat;
        }

        public Narudzba MapNarudzbaDTOToDb(NarudzbaDTO narudzbaDTO)
        {
            Narudzba narudzba = new Narudzba();
            narudzba.ID = narudzbaDTO.ID;
            narudzba.VrijemeOd = narudzbaDTO.VrijemeOd;
            narudzba.VrijemeDo = narudzbaDTO.VrijemeDo;
            narudzba.SatiOd = narudzbaDTO.SatiOd;
            narudzba.SatiDo = narudzbaDTO.SatiDo;
            narudzba.Opis = narudzbaDTO.Opis;
            narudzba.PacijentID = narudzbaDTO.PacijentID;
            narudzba.ZahvatID = narudzbaDTO.ZahvatID;
            narudzba.Dolazak = narudzbaDTO.Dolazak;
            narudzba.Pacijent = narudzbaDTO.Pacijent;
            narudzba.Zahvat = narudzbaDTO.Zahvat;

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
    }
}
