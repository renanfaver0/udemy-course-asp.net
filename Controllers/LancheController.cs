using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SistemaMVC_lanches.Models;
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

        public IActionResult List(string categoria)
        {
            IEnumerable<Lanche> lanches;
            string categoriaAtual = string.Empty;

            if (string.IsNullOrEmpty(categoria))
            {
                lanches = _lancheRepository.Lanches.OrderBy(l => l.LancheId);
                categoriaAtual = "Todos os lanches";
            }
            else
            {
                // if (string.Equals("Normal", categoria, StringComparison.OrdinalIgnoreCase))
                // {
                //     lanches = _lancheRepository.Lanches
                //         .Where(l => l.Categoria.CategoriaNome.Equals("Normal"))
                //         .OrderBy(l => l.Nome);
                // }
                // else
                // {
                //     lanches = _lancheRepository.Lanches
                //         .Where(l => l.Categoria.CategoriaNome.Equals("Natural"))
                //         .OrderBy(l => l.Nome);
                // }
                lanches = _lancheRepository.Lanches
                .Where(l => l.Categoria.CategoriaNome.Equals(categoria))
                .OrderBy(c => c.Nome);
                categoriaAtual = categoria;
            }

            var lanchesListViewModel = new LancheListViewModel
            {
                Lanches = lanches,
                CategoriaAtual = categoriaAtual
        };

            return View(lanchesListViewModel);
        }

        public IActionResult Details(int lancheId)
        {
            var lanche = _lancheRepository.Lanches.FirstOrDefault(l => l.LancheId == lancheId);
            return View(lanche);
        }
    }
}