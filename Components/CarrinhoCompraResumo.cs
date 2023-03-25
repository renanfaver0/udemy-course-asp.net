using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SistemaMVC_lanches.Models;
using SistemaMVC_lanches.ViewModels;

namespace SistemaMVC_lanches.Components
{
    public class CarrinhoCompraResumo : ViewComponent
    {

        private readonly CarrinhoCompra _carrinhoCompra;

        public CarrinhoCompraResumo(CarrinhoCompra carrinhoCompra)
        {
            _carrinhoCompra = carrinhoCompra;
        }

        public IViewComponentResult Invoke() 
        {
            var itens = _carrinhoCompra.GetCarrinhoCompraItens();

            // var itens = new List<CarrinhoCompraItem>()
            // {
            //     new CarrinhoCompraItem(),
            //     new CarrinhoCompraItem()
            // };

            _carrinhoCompra.CarrinhoCompraItems = itens;

            var carrinhoCompraVM = new CarrinhoCompraViewModel
            {
                CarrinhoCompra = _carrinhoCompra,
                CarrinhoCompraTotal = _carrinhoCompra.GetCarrinhoCompraTotal()
            };
            
            return View(carrinhoCompraVM);
        }
    }
}