using StomatoloskaOrdinacija.DAL;
using StomatoloskaOrdinacija.Domain.DTOs;
using StomatoloskaOrdinacija.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace StomatoloskaOrdinacija.Domain.Builders
{
    public class StomatoloskaOrdinacijaDTOBuilder
    {
        public ZahvatDTO FillZahvatDTO(OrdinacijaDb db, ZahvatDTO zahvatDTO, Zahvat zahvatDb)
        {
            zahvatDTO.ID = zahvatDb.ID;
            zahvatDTO.Sifra = zahvatDb.Sifra;
            zahvatDTO.Naziv = zahvatDb.Naziv;
            zahvatDTO.Cijena = zahvatDb.CijenaZahvata.Cijena.ToString();
            zahvatDTO.Trajanje = zahvatDb.TrajanjeZahvata.Trajanje.ToShortTimeString();

            zahvatDTO.TrajanjeID = zahvatDb.TrajanjeID;
            zahvatDTO.CijenaID = zahvatDb.CijenaID;
            zahvatDTO.CijenaListDTO = FillSelectListItem(db.CijenaZahvata.ToList());
            zahvatDTO.TrajanjeListDTO = FillSelectListItem(db.TrajanjeZahvata.ToList());

            return zahvatDTO;
        }

        public ZahvatDTO PrepareZahvatDTOForCreate(OrdinacijaDb db)
        {
            ZahvatDTO zahvatDTO = new ZahvatDTO();
            zahvatDTO.CijenaListDTO = FillSelectListItem(db.CijenaZahvata.ToList());
            zahvatDTO.TrajanjeListDTO = FillSelectListItem(db.TrajanjeZahvata.ToList());

            return zahvatDTO;
        }

        public PacijentDTO FillPacijentDTO(OrdinacijaDb db, PacijentDTO pacijentDTO, Pacijent pacijentDb)
        {
            pacijentDTO.ID = pacijentDb.ID;
            pacijentDTO.Ime = pacijentDb.Ime;
            pacijentDTO.Prezime = pacijentDb.Prezime;
            pacijentDTO.DatumRodjenja = pacijentDb.DatumRodjenja;
            pacijentDTO.Telefon = pacijentDb.Telefon;
            pacijentDTO.Adresa = pacijentDb.Adresa;
            pacijentDTO.Narudzba = pacijentDb.Narudzba;

            return pacijentDTO;
        }

        public NarudzbaDTO FillNarudzbaDTO(OrdinacijaDb db, NarudzbaDTO narudzbaDTO, Narudzba narudzbaDb)
        {
            narudzbaDTO.ID = narudzbaDb.ID;
            narudzbaDTO.VrijemeOd = narudzbaDb.VrijemeOd;
            narudzbaDTO.VrijemeDo = narudzbaDb.VrijemeDo;
            narudzbaDTO.SatiOd = narudzbaDb.SatiOd;
            narudzbaDTO.SatiDo = narudzbaDb.SatiDo;
            narudzbaDTO.Opis = narudzbaDb.Opis;
            narudzbaDTO.PacijentID = narudzbaDb.PacijentID;
            narudzbaDTO.ZahvatID = narudzbaDb.ZahvatID;
            narudzbaDTO.Dolazak = narudzbaDb.Dolazak;
            narudzbaDTO.Pacijent = narudzbaDb.Pacijent;
            narudzbaDTO.Zahvat = narudzbaDb.Zahvat;

            return narudzbaDTO;
        }

        public RadnoVrijemeDTO FillRadnoVrijemeDTO(OrdinacijaDb db, RadnoVrijemeDTO radnoVrijemeDTO, RadnoVrijeme radnoVrijemeDb)
        {
            radnoVrijemeDTO.ID = radnoVrijemeDb.ID;
            radnoVrijemeDTO.VrijemeOd = radnoVrijemeDb.VrijemeOd;
            radnoVrijemeDTO.VrijemeDo = radnoVrijemeDb.VrijemeDo;

            return radnoVrijemeDTO;
        }

        public List<ZahvatDTO> FillZahvatDTOList(OrdinacijaDb db, List<ZahvatDTO> zahvatDTOList, List<Zahvat> zahvatDbList)
        {
            foreach (var zahvatDb in zahvatDbList)
            {
                ZahvatDTO zahvatDTO = new ZahvatDTO();
                FillZahvatDTO(db, zahvatDTO, zahvatDb);

                zahvatDTOList.Add(zahvatDTO);
            }

            return zahvatDTOList;
        }

        public List<PacijentDTO> FillPacijentDTOList(OrdinacijaDb db, List<PacijentDTO> pacijentDTOList, List<Pacijent> pacijentDbList)
        {
            foreach (var pacijentDb in pacijentDbList)
            {
                PacijentDTO pacijentDTO = new PacijentDTO();
                FillPacijentDTO(db, pacijentDTO, pacijentDb);
                pacijentDTOList.Add(pacijentDTO);
            }

            return pacijentDTOList;
        }

        public List<NarudzbaDTO> FillNarudzbaDTOList(OrdinacijaDb db, List<NarudzbaDTO> narudzbaDTOList, List<Narudzba> narudzbaDbList)
        {
            foreach (var narudzbaDb in narudzbaDbList)
            {
                NarudzbaDTO narudzbaDTO = new NarudzbaDTO();
                FillNarudzbaDTO(db, narudzbaDTO, narudzbaDb);
                narudzbaDTOList.Add(narudzbaDTO);
            }

            return narudzbaDTOList;
        }

        public List<SelectListItem> FillSelectListItem(List<CijenaZahvata> cijenaZahvata)
        {
            List<SelectListItem> selectListItemList = new List<SelectListItem>();

            foreach (var item in cijenaZahvata)
            {
                SelectListItem o = new SelectListItem();
                o.Value = item.ID.ToString();
                o.Text = item.Cijena.ToString();

                selectListItemList.Add(o);
            }

            return selectListItemList;
        }

        public List<SelectListItem> FillSelectListItem(List<TrajanjeZahvata> trajanjeZahvata)
        {
            List<SelectListItem> selectListItemList = new List<SelectListItem>();

            foreach (var item in trajanjeZahvata)
            {
                SelectListItem o = new SelectListItem();
                o.Value = item.ID.ToString();
                o.Text = item.Trajanje.ToShortTimeString();

                selectListItemList.Add(o);
            }

            return selectListItemList;
        }

    }
}
