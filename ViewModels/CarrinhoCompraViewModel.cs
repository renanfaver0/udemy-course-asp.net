using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaMVC_lanches.Models;

namespace SistemaMVC_lanches.ViewModels
{
    public class CarrinhoCompraViewModel
    {
        public CarrinhoCompra CarrinhoCompra { get; set; }
        public decimal CarrinhoCompraTotal { get; set; }
    }
}