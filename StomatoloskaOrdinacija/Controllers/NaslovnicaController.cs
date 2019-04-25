using StomatoloskaOrdinacija.Domain.DTOs;
using StomatoloskaOrdinacija.Domain.Services;
using StomatoloskaOrdinacija.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StomatoloskaOrdinacija.Controllers
{
    [Authorize]
    public class NaslovnicaController : Controller
    {
        RadnoVrijemeService radnoVrijemeService = new RadnoVrijemeService();
        NarudzbeService narudzbaService = new NarudzbeService();

        // GET: Naslovnica
        public ActionResult Kalendar()
        {
            NarudzbaRadnoVrijemeVM viewModel = new NarudzbaRadnoVrijemeVM();
            viewModel.NarudzbaDTOList = GetNarudzbaList();
            viewModel.RadnoVrijemeDTO = GetRadnoVrijeme();

            return View(viewModel);
        }

        public List<NarudzbaDTO> GetNarudzbaList()
        {
            List<NarudzbaDTO> narudzbaDTO = narudzbaService.GetPopisNarudzba();

            return narudzbaDTO;
        }

        public RadnoVrijemeDTO GetRadnoVrijeme()
        {
            var id = radnoVrijemeService.GetRadnoVrijemeId();
            RadnoVrijemeDTO radnoVrijemeDTO = radnoVrijemeService.GetRadnoVrijemeById(id);

            return radnoVrijemeDTO;
        }
    }
}