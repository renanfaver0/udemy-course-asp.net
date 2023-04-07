using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaMVC_lanches.Models;
using SistemaMVC_lanches.Repositories.Interfaces;

namespace SistemaMVC_lanches.Controllers
{
    public class PedidoController : Controller
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly CarrinhoCompra _carrinhoCompra;

        public PedidoController(IPedidoRepository pedidoRepository,
            CarrinhoCompra carrinhoCompra)
        {
            _pedidoRepository = pedidoRepository;
            _carrinhoCompra = carrinhoCompra;
        }

        [Authorize]
        [HttpGet]
        public IActionResult Checkout()
        {
            return View();
        }
        
        [Authorize]
        [HttpPost]
        public IActionResult Checkout(Pedido pedido)
        {
            int totalItensPedidos = 0;
            decimal precoTotalPedido = 0.0m;

            // Getting the items of cart of client.
            List<CarrinhoCompraItem> items = _carrinhoCompra.GetCarrinhoCompraItens();
            _carrinhoCompra.CarrinhoCompraItems = items;

            // Check if exists items in the order.
            if(_carrinhoCompra.CarrinhoCompraItems.Count == 0)
            {
                ModelState.AddModelError("", "Seu carrinho está vazio, que tal incluir algum produto?...");
            }

            // Calculating the total of items and the total of order.
            foreach(var item in items)
            {
                totalItensPedidos += item.Quantidade;
                precoTotalPedido += (item.Lanche.Preco * item.Quantidade);
            }

            // Attributing the values obtained in the order.
            pedido.TotalItensPedido = totalItensPedidos;
            pedido.PedidoTotal = precoTotalPedido;

            // Validate the data of order.
            if (ModelState.IsValid)
            {
                // Create the order and the details.
                _pedidoRepository.CriarPedido(pedido);

                // Define messages for the cliente.
                ViewBag.CheckoutCompletoMensagem = "Obrigado pelo seu pedido =)";
                ViewBag.TotalPedido = _carrinhoCompra.GetCarrinhoCompraTotal();

                // Clear the cart of client.
                _carrinhoCompra.LimparCarrinho();

                // Display the view with data of client and of order.
                return View("Views/Pedido/CheckoutCompleto.cshtml", pedido);

            }
            return View(pedido);
        }
    }
}