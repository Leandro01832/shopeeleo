using business.classes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SiteVendas.Data;
using SiteVendas.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteVendas.Models.Repository
{
    public interface IPedidoRepository
    {
        IEnumerable<Pedido> GetAll();
        Task<Pedido> Get(int id);
        void Update(Pedido item);
        bool Delete(int id);
        Task<Pedido> UpdateCadastroAsync(Cadastro pedido);
        Task<Pedido> GetPedidoAsync();
        Task AddItemAsync(string codigo);
        Task<UpdateQuantidadeResponse> UpdateQuantidadeAsync(ItemPedido itemPedido);
    }

    public class PedidoRepository : BaseRepository<Pedido>, IPedidoRepository
    {
        public PedidoRepository(ApplicationDbContext contexto,
            IClienteRepository repositoryCliente, IHttpHelper httpHelper,
            IHttpContextAccessor contextAccessor, UserManager<IdentityUser> userManager) : base(contexto)
        {
            Contexto = contexto;
            RepositoryCliente = repositoryCliente;
            HttpHelper = httpHelper;
            ContextAccessor = contextAccessor;
            UserManager = userManager;
        }

        public ApplicationDbContext Contexto { get; }
        public IClienteRepository RepositoryCliente { get; }
        public IHttpHelper HttpHelper { get; }
        public IHttpContextAccessor ContextAccessor { get; }
        public UserManager<IdentityUser> UserManager { get; }
        
        public IEnumerable<Pedido> GetAll()
        {
            return dbSet.ToList();
        }

        public bool Delete(int id)
        {
            var prod = dbSet.FirstOrDefault(p => p.Id == id);

            if (prod != null)
            {
                dbSet.Remove(prod);
                Contexto.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<Pedido> Get(int id)
        {
            return await dbSet.Include(p => p.ItensPedido).FirstAsync(p => p.Id == id);
        }

        public async Task AddItemAsync(string codigo)
        {
            var produto = await
                            contexto.Set<Produto>()
                            .Where(p => p.Id == int.Parse(codigo))
                            .SingleOrDefaultAsync();

            if (produto == null)
            {
                throw new ArgumentException("Produto não encontrado");
            }

            var pedido = await GetPedidoAsync();

            var itemPedido = await
                                contexto.Set<ItemPedido>()
                                .Where(i => i.Produto.Id == int.Parse(codigo)
                                        && i.Pedido.Id == pedido.Id)
                                .SingleOrDefaultAsync();

            if (itemPedido == null)
            {
                itemPedido = new ItemPedido(pedido, produto, 1, produto.Preco);
                contexto.Set<ItemPedido>().Add(itemPedido);

                await contexto.SaveChangesAsync();
            }
        }

        public async Task<Pedido> GetPedidoAsync()
        {
            var pedidoId = HttpHelper.GetPedidoId();
            var pedido =
                await dbSet
                .Include(p => p.ItensPedido)
                    .ThenInclude(i => i.Produto)
                        .ThenInclude(prod => prod.Categoria)
                .Include(p => p.Cadastro)
                .Where(p => p.Id == pedidoId)
                .SingleOrDefaultAsync();

            if (pedido == null)
            {
                var claimsPrincipal = ContextAccessor.HttpContext.User;
                var clienteId = UserManager.GetUserId(claimsPrincipal);
                pedido = new Pedido(clienteId);
                await dbSet.AddAsync(pedido);
                await contexto.SaveChangesAsync();
                HttpHelper.SetPedidoId(pedido.Id);
            }

            return pedido;
        }

        public void Update(Pedido item)
        {
            Contexto.Entry(item).State = EntityState.Modified;
            Contexto.SaveChanges();
        }

        public async Task<Pedido> UpdateCadastroAsync(Cadastro cadastro)
        {
            Contexto.Update(cadastro);
            await Contexto.SaveChangesAsync();
            return cadastro.Pedido;
        }

        public async Task<UpdateQuantidadeResponse> UpdateQuantidadeAsync(ItemPedido itemPedido)
        {
            var itemPedidoDB = await GetItemPedidoAsync(itemPedido.Id);

            if (itemPedidoDB != null)
            {
                itemPedidoDB.AtualizaQuantidade(itemPedido.Quantidade);

                if (itemPedido.Quantidade == 0)
                {
                    await RemoveItemPedidoAsync(itemPedido.Id);
                }

                await contexto.SaveChangesAsync();

                var pedido = await Get((int)HttpHelper.GetPedidoId());
                var carrinhoViewModel = new CarrinhoViewModel(pedido.ItensPedido);

                return new UpdateQuantidadeResponse(itemPedidoDB, carrinhoViewModel);
            }

            throw new ArgumentException("ItemPedido não encontrado");
        }

        private async Task<ItemPedido> GetItemPedidoAsync(int itemPedidoId)
        {
            return
            await contexto.Set<ItemPedido>()
                .Where(ip => ip.Id == itemPedidoId)
                .SingleOrDefaultAsync();
        }

        private async Task RemoveItemPedidoAsync(int itemPedidoId)
        {
            contexto.Set<ItemPedido>()
                .Remove(await GetItemPedidoAsync(itemPedidoId));
        }
    }
}