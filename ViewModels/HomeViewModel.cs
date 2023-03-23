using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaMVC_lanches.Models;

namespace SistemaMVC_lanches.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Lanche> LanchesPreferidos { get; set; }
    }
}