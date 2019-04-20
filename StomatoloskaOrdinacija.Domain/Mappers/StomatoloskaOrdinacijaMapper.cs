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
        public PacijentDTO MapPacijentDbToDTO(PacijentDTO pacijentDTO, Pacijent pacijentDb)
        {
            pacijentDTO.ID = pacijentDb.ID;
            pacijentDTO.ImePacijenta = pacijentDb.ImePacijenta;
            pacijentDTO.PrezimePacijenta = pacijentDb.PrezimePacijenta;
            pacijentDTO.DatumRodjenja = pacijentDb.DatumRodjenja;
            pacijentDTO.Telefon = pacijentDb.Telefon;
            pacijentDTO.Adresa = pacijentDb.Adresa;
            pacijentDTO.Zahvat = pacijentDb.Zahvat;

            return pacijentDTO;
        }

        public NarudzbaDTO MapNarudzbaDbToDTO(NarudzbaDTO narudzbaDTO, Narudzba narudzbaDb)
        {
            narudzbaDTO.ID = narudzbaDb.ID;
            narudzbaDTO.NazivNarudzbe = narudzbaDb.NazivNarudzbe;
            narudzbaDTO.VrijemeOd = narudzbaDb.VrijemeOd;
            narudzbaDTO.VrijemeDo = narudzbaDb.VrijemeDo;
            narudzbaDTO.OpisNarudzbe = narudzbaDb.OpisNarudzbe;
            narudzbaDTO.NazivPacijenta = narudzbaDb.NazivPacijenta;
            narudzbaDTO.Dolazak = narudzbaDb.Dolazak;

            return narudzbaDTO;
        }

        public ZahvatDTO MapZahvatDbToDTO(ZahvatDTO zahvatDTO, Zahvat zahvatDb)
        {
            if (zahvatDTO.Sifra == (int)VrsteZahvataEnum.Pregled)
            {
                zahvatDTO.Cijena = 0;
            }
            else
            {
                zahvatDTO.Cijena = zahvatDTO.Cijena;
            }
            zahvatDTO.ID = zahvatDTO.ID;
            zahvatDTO.PacijentId = zahvatDTO.PacijentId;
            zahvatDTO.Sifra = zahvatDTO.Sifra;
            zahvatDTO.Naziv = zahvatDTO.Naziv;
            zahvatDTO.Pacijent = zahvatDTO.Pacijent;

            return zahvatDTO;
        }
    }
}
