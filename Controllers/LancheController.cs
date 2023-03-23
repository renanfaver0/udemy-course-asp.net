using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SistemaMVC_lanches.Repositories.Interfaces;
using SistemaMVC_lanches.ViewModels;

namespace SistemaMVC_lanches.Controllers
{
    public class LancheController : Controller
    {
        private readonly ILancheRepository _lancheRepository;

        public LancheController(ILancheRepository lancheRepository)
        {
            _lancheRepository = lancheRepository;
        }

        public IActionResult List()
        {
            // ViewData["Titulo"] = "Todos os lanches";
            // ViewData["Data"] = DateTime.Now;

            // var lanches = _lancheRepository.Lanches;
            // var totalLanches = lanches.Count();

            // ViewBag.Total = "Total de lanches";
            // ViewBag.TotalLanches = totalLanches;

            // return View(lanches);

            var lanchesListViewModel = new LancheListViewModel();
            lanchesListViewModel.Lanches = _lancheRepository.Lanches;
            lanchesListViewModel.CategoriaAtual = "Categoria Atual";

            return View(lanchesListViewModel);


        }
    }
}