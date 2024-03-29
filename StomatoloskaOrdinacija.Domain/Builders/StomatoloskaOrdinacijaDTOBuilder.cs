﻿using StomatoloskaOrdinacija.DAL;
using StomatoloskaOrdinacija.Domain.DTOs;
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

        public ZahvatDTO FillDDLPacijentTrajanje(OrdinacijaDb db, ZahvatDTO zahvatDTO)
        {
            zahvatDTO.CijenaListDTO = FillSelectListItem(db.CijenaZahvata.ToList());
            zahvatDTO.TrajanjeListDTO = FillSelectListItem(db.TrajanjeZahvata.ToList());

            return zahvatDTO;
        }

        public NarudzbaDTO FillDDLPacijentZahvat(OrdinacijaDb db, NarudzbaDTO narudzbaDTO)
        {
            narudzbaDTO.PacijentListDTO = FillSelectListItem(db.Pacijent.ToList());
            narudzbaDTO.ZahvatListDTO = FillSelectListItem(db.Zahvat.ToList());

            return narudzbaDTO;
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
            narudzbaDTO.Datum = narudzbaDb.Vrijeme.Date;
            narudzbaDTO.Sati = narudzbaDb.Vrijeme.Hour;
            narudzbaDTO.Minute = narudzbaDb.Vrijeme.Minute;
            narudzbaDTO.Vrijeme = narudzbaDb.Vrijeme.Date.AddHours(narudzbaDb.Vrijeme.Hour).AddMinutes(narudzbaDb.Vrijeme.Minute);
            narudzbaDTO.VrijemeZavrsetkaZahvata = narudzbaDb.VrijemeZavrsetkaZahvata;
            narudzbaDTO.Opis = narudzbaDb.Opis;
            narudzbaDTO.Dolazak = narudzbaDb.Dolazak;
            narudzbaDTO.PacijentID = narudzbaDb.PacijentID;
            narudzbaDTO.ZahvatID = narudzbaDb.ZahvatID;
            narudzbaDTO.PacijentListDTO = FillSelectListItem(db.Pacijent.ToList());
            narudzbaDTO.ZahvatListDTO = FillSelectListItem(db.Zahvat.ToList());

            return narudzbaDTO;
        }

        public NarudzbaDTO PrepareNarudzbaDTOForCreate(OrdinacijaDb db)
        {
            NarudzbaDTO narudzbaDTO = new NarudzbaDTO();
            narudzbaDTO.Datum = DateTime.Now.Date;
            narudzbaDTO.PacijentListDTO = FillSelectListItem(db.Pacijent.ToList());
            narudzbaDTO.ZahvatListDTO = FillSelectListItem(db.Zahvat.ToList());

            return narudzbaDTO;
        }

        public RadnoVrijemeDTO FillRadnoVrijemeDTO(OrdinacijaDb db, RadnoVrijemeDTO radnoVrijemeDTO, RadnoVrijeme radnoVrijemeDb)
        {
            radnoVrijemeDTO.ID = radnoVrijemeDb.ID;
            radnoVrijemeDTO.VrijemeOd = radnoVrijemeDb.VrijemeOd;
            radnoVrijemeDTO.VrijemeDo = radnoVrijemeDb.VrijemeDo;

            return radnoVrijemeDTO;
        }

        public CijenaZahvataDTO FillCijenaZahvataDTO(OrdinacijaDb db, CijenaZahvataDTO cijenaZahvataDTO, CijenaZahvata cijenaZahvataDb)
        {
            cijenaZahvataDTO.ID = cijenaZahvataDb.ID;
            cijenaZahvataDTO.Cijena = cijenaZahvataDb.Cijena;

            return cijenaZahvataDTO;
        }

        public TrajanjeZahvataDTO FillTrajanjeZahvataDTO(OrdinacijaDb db, TrajanjeZahvataDTO trajanjeZahvataDTO, TrajanjeZahvata trajanjeZahvataDb)
        {
            trajanjeZahvataDTO.ID = trajanjeZahvataDb.ID;
            trajanjeZahvataDTO.Trajanje = trajanjeZahvataDb.Trajanje;

            return trajanjeZahvataDTO;
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

        public List<CijenaZahvataDTO> FillCijenaZahvataDTOList(OrdinacijaDb db, List<CijenaZahvataDTO> cijenaZahvatDTOList, List<CijenaZahvata> cijenaZahvataDbList)
        {
            foreach (var cijenaZahvataDb in cijenaZahvataDbList)
            {
                CijenaZahvataDTO cijenaZahvataDTO = new CijenaZahvataDTO();
                FillCijenaZahvataDTO(db, cijenaZahvataDTO, cijenaZahvataDb);

                cijenaZahvatDTOList.Add(cijenaZahvataDTO);
            }

            return cijenaZahvatDTOList;
        }

        public List<TrajanjeZahvataDTO> FillTrajanjeZahvataDTOList(OrdinacijaDb db, List<TrajanjeZahvataDTO> trajanjeZahvatDTOList, List<TrajanjeZahvata> trajanjeZahvataDbList)
        {
            foreach (var trajanjeZahvataDb in trajanjeZahvataDbList)
            {
                TrajanjeZahvataDTO trajanjeZahvataDTO = new TrajanjeZahvataDTO();
                FillTrajanjeZahvataDTO(db, trajanjeZahvataDTO, trajanjeZahvataDb);

                trajanjeZahvatDTOList.Add(trajanjeZahvataDTO);
            }

            return trajanjeZahvatDTOList;
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

        public List<SelectListItem> FillSelectListItem(List<Pacijent> pacijent)
        {
            List<SelectListItem> selectListItemList = new List<SelectListItem>();

            foreach (var item in pacijent)
            {
                SelectListItem o = new SelectListItem();
                o.Value = item.ID.ToString();
                o.Text = item.Ime + " " + item.Prezime;

                selectListItemList.Add(o);
            }

            return selectListItemList;
        }

        public List<SelectListItem> FillSelectListItem(List<Zahvat> zahvat)
        {
            List<SelectListItem> selectListItemList = new List<SelectListItem>();

            foreach (var item in zahvat)
            {
                SelectListItem o = new SelectListItem();
                o.Value = item.ID.ToString();
                o.Text = item.Naziv;

                selectListItemList.Add(o);
            }

            return selectListItemList;
        }

    }
}
