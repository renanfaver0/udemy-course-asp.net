using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SistemaMVC_lanches.Models;
using SistemaMVC_lanches.Repositories.Interfaces;
using SistemaMVC_lanches.ViewModels;

namespace SistemaMVC_lanches.Controllers;

public class HomeController : Controller
{

    private readonly ILancheRepository _lancheRepository;

    public HomeController(ILancheRepository lancheRepository)
    {
        _lancheRepository = lancheRepository;
    }
    public IActionResult Index()
    {
        var homeViewMode = new HomeViewModel
        {
            LanchesPreferidos = _lancheRepository.LanchesPreferidos
        };
        
        return View(homeViewMode);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
