using StomatoloskaOrdinacija.DAL;
using StomatoloskaOrdinacija.Domain.DTOs;
using StomatoloskaOrdinacija.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StomatoloskaOrdinacija.Domain.Builders
{
    public class StomatoloskaOrdinacijaDTOBuilder
    {
        public ZahvatDTO FillZahvatDTO(ZahvatDTO zahvatDTO, Zahvat zahvatDb)
        {
            if (zahvatDTO.Sifra == (int)VrsteZahvataEnum.Pregled)
            {
                zahvatDTO.Cijena = 0;
            }
            else
            {
                zahvatDTO.Cijena = zahvatDb.Cijena;
            }
            zahvatDTO.ID = zahvatDb.ID;
            zahvatDTO.PacijentID = zahvatDb.PacijentID;
            zahvatDTO.Sifra = zahvatDb.Sifra;
            zahvatDTO.Naziv = zahvatDb.Naziv;
            zahvatDTO.Pacijent = zahvatDb.Pacijent;

            return zahvatDTO;
        }

        public PacijentDTO FillPacijentDTO(PacijentDTO pacijentDTO, Pacijent pacijentDb)
        {
            pacijentDTO.ID = pacijentDb.ID;
            pacijentDTO.Ime = pacijentDb.Ime;
            pacijentDTO.Prezime = pacijentDb.Prezime;
            pacijentDTO.DatumRodjenja = pacijentDb.DatumRodjenja;
            pacijentDTO.Telefon = pacijentDb.Telefon;
            pacijentDTO.Adresa = pacijentDb.Adresa;
            pacijentDTO.Zahvat = pacijentDb.Zahvat;
            pacijentDTO.Narudzba = pacijentDb.Narudzba;

            return pacijentDTO;
        }

        public NarudzbaDTO FillNarudzbaDTO(NarudzbaDTO narudzbaDTO, Narudzba narudzbaDb)
        {
            narudzbaDTO.ID = narudzbaDb.ID;
            narudzbaDTO.Naziv = narudzbaDb.Naziv;
            narudzbaDTO.VrijemeOd = narudzbaDb.VrijemeOd;
            narudzbaDTO.VrijemeDo = narudzbaDb.VrijemeDo;
            narudzbaDTO.Opis = narudzbaDb.Opis;
            narudzbaDTO.PacijentID = narudzbaDb.PacijentID;
            narudzbaDTO.Dolazak = narudzbaDb.Dolazak;
            narudzbaDTO.Pacijent = narudzbaDb.Pacijent;

            return narudzbaDTO;
        }

        public List<ZahvatDTO> FillZahvatDTOList(List<ZahvatDTO> zahvatDTOList, List<Zahvat> zahvatDbList)
        {
            foreach (var zahvatDb in zahvatDbList)
            {
                ZahvatDTO zahvatDTO = new ZahvatDTO();
                FillZahvatDTO(zahvatDTO, zahvatDb);

                zahvatDTOList.Add(zahvatDTO);
            }

            return zahvatDTOList;
        }

        public List<PacijentDTO> FillPacijentDTOList(List<PacijentDTO> pacijentDTOList, List<Pacijent> pacijentDbList)
        {
            foreach (var pacijentDb in pacijentDbList)
            {
                PacijentDTO pacijentDTO = new PacijentDTO();
                FillPacijentDTO(pacijentDTO, pacijentDb);
                pacijentDTOList.Add(pacijentDTO);
            }

            return pacijentDTOList;
        }

        public List<NarudzbaDTO> FillNarudzbaDTOList(List<NarudzbaDTO> narudzbaDTOList, List<Narudzba> narudzbaDbList)
        {
            foreach (var narudzbaDb in narudzbaDbList)
            {
                NarudzbaDTO narudzbaDTO = new NarudzbaDTO();
                FillNarudzbaDTO(narudzbaDTO, narudzbaDb);
                narudzbaDTOList.Add(narudzbaDTO);
            }

            return narudzbaDTOList;
        }
    }
}
