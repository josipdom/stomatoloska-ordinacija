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
            zahvatDTO.PacijentID = zahvatDTO.PacijentID;
            zahvatDTO.Sifra = zahvatDTO.Sifra;
            zahvatDTO.Naziv = zahvatDTO.Naziv;
            zahvatDTO.Pacijent = zahvatDTO.Pacijent;

            return zahvatDTO;
        }

        public PacijentDTO MapPacijentDbToDTO(PacijentDTO pacijentDTO, Pacijent pacijentDb)
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

        public NarudzbaDTO MapNarudzbaDbToDTO(NarudzbaDTO narudzbaDTO, Narudzba narudzbaDb)
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

        public List<ZahvatDTO> MapZahvatDbToDTOList(List<ZahvatDTO> zahvatDTOList, List<Zahvat> zahvatDbList)
        {
            foreach (var zahvatDb in zahvatDbList)
            {
                ZahvatDTO zahvatDTO = new ZahvatDTO();
                MapZahvatDbToDTO(zahvatDTO, zahvatDb);

                zahvatDTOList.Add(zahvatDTO);
            }

            return zahvatDTOList;
        }

        public List<PacijentDTO> MapPacijentDbToDTOList(List<PacijentDTO> pacijentDTOList, List<Pacijent> pacijentDbList)
        {
            foreach (var pacijentDb in pacijentDbList)
            {
                PacijentDTO pacijentDTO = new PacijentDTO();
                MapPacijentDbToDTO(pacijentDTO, pacijentDb);
                pacijentDTOList.Add(pacijentDTO);
            }

            return pacijentDTOList;
        }

        public List<NarudzbaDTO> MapNarudzbaDbToDTOList(List<NarudzbaDTO> narudzbaDTOList, List<Narudzba> narudzbaDbList)
        {
            foreach (var narudzbaDb in narudzbaDbList)
            {
                NarudzbaDTO narudzbaDTO = new NarudzbaDTO();
                MapNarudzbaDbToDTO(narudzbaDTO, narudzbaDb);
                narudzbaDTOList.Add(narudzbaDTO);
            }

            return narudzbaDTOList;
        }


    }
}
