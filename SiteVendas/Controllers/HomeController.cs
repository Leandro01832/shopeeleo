using business;
using business.classes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SiteVendas.Data;
using SiteVendas.Models;
using SiteVendas.Models.Repository;
using SiteVendas.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteVendas.Controllers
{
    public class HomeController : Controller
    {
        public IProdutoRepository ProdutoRepository { get; }
        public IPedidoRepository PedidoRepository { get; }
        public IClienteRepository ClienteRepository { get; }
        public UserManager<IdentityUser> UserManager { get; }
        public IHttpHelper HttpHelper { get; }

        public HomeController(IProdutoRepository produtoRepository, IPedidoRepository pedidoRepository,
            IClienteRepository clienteRepository, UserManager<IdentityUser> userManager, IHttpHelper httpHelper)
        {
            ProdutoRepository = produtoRepository;
            PedidoRepository = pedidoRepository;
            ClienteRepository = clienteRepository;
            UserManager = userManager;
            HttpHelper = httpHelper;
        }

        public ActionResult Index()
        {
            return View(ProdutoRepository.GetAll());
        }

        public async Task<ActionResult> BuscaProdutos(string pesquisa)
        {
            return View(await ProdutoRepository.GetProdutosAsync(pesquisa));
        }

        [Authorize]
        public async Task<ActionResult> Carrinho(string codigo)
        {
            if (!string.IsNullOrEmpty(codigo))
            {
                await PedidoRepository.AddItemAsync(codigo);
            }

            var pedido = await PedidoRepository.GetPedidoAsync();
            List<ItemPedido> itens = pedido.ItensPedido;
            CarrinhoViewModel carrinhoViewModel = new CarrinhoViewModel(itens);
            return base.View(carrinhoViewModel);
        }

        [Authorize]
        public async Task<ActionResult> Cadastro()
        {
            Pedido pedido = await PedidoRepository.GetPedidoAsync();

            if (pedido == null)
            {
                return RedirectToAction("Carrossel");
            }
            pedido.Cadastro.Nome = User.FindFirst("name")?.Value;

            return View(pedido.Cadastro);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<ActionResult> Resumo(Cadastro cadastro)
        {
            var usuario = await UserManager.GetUserAsync(this.User);
            var ped = await PedidoRepository.UpdateCadastroAsync(cadastro);
            ped = await PedidoRepository.GetPedidoAsync();
           // pedido = await PedidoRepository.Get(pedido.Id);
            //  var urlPedido = "http://localhost:53443/Home/RetornaPedido/" + pedido.Id;
            //  IdentityMessage msg = new IdentityMessage
            //  {
            //      Body = "<p style='color:blue; background-color:yellow;'>" +
            //      $" N° Pedido - {pedido.Id.ToString()} <a href='{urlPedido}'> visualizar pedido <a/>." +
            //      $" Agradecemos pela sua prefêrencia. <p/>" +
            //      "<p style='color:red; background-color:yellow;'> Volte sempre. Assinado Cida Modas sz sz sz sz <p/>" +
            //      "<img src='https://cdn.ecvol.com/s/loja.anatuori.com/produtos/ligia-vestido-festa-longo-evase-ombro-a-ombro-com-alcas-saia-plissada-madrinha-casamento-formatura-cor-marsala/m/0.jpg?v=1' />",
            //      Subject = "Pedido confirmado.",
            //      Destination = usuario.Email
            //  };
            //  await AccountController.SendMarketingAsync(msg);
            if(ped != null)
            return View(ped);

            return RedirectToAction("Cadastro");
        }

        public async Task<ActionResult> RetornaPedido(int id)
        {
            Pedido pedido = await PedidoRepository.Get(id);
            return View(pedido);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<JsonResult> UpdateQuantidade([FromBody]ItemPedido itemPedido)
        {
            //  return await PedidoRepository.UpdateQuantidadeAsync(itemPedido);
            // banco.Configuration.ProxyCreationEnabled = false;

            var ped = await PedidoRepository.UpdateQuantidadeAsync(itemPedido);

            string[] result = new string[5];

            result[0] = ped.ItemPedido.Subtotal.ToString();
            result[1] = ped.ItemPedido.Id.ToString();
            result[2] = ped.ItemPedido.Quantidade.ToString();
            result[3] = ped.CarrinhoViewModel.Itens.Count.ToString();
            result[4] = ped.CarrinhoViewModel.Total.ToString();

            return Json(result);
        }

    }
}
