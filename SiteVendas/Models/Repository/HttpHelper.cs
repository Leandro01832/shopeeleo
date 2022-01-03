using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace SiteVendas.Models.Repository
{
    public class HttpHelper : IHttpHelper
    {
        private readonly IHttpContextAccessor ContextAccessor;
        private readonly UserManager<IdentityUser> userManager;

        public IConfiguration Configuration { get; }

        public HttpHelper(IHttpContextAccessor contextAccessor
            , IConfiguration configuration
            , UserManager<IdentityUser> userManager)
        {
            ContextAccessor = contextAccessor;
            Configuration = configuration;
            this.userManager = userManager;
        }

        public int? GetPedidoId()
        {
            var getCliente = GetClienteId();
            return ContextAccessor.HttpContext.Session.GetInt32($"pedidoId_{getCliente}");
        }

        public void SetPedidoId(int pedidoId)
        {
            ContextAccessor.HttpContext.Session.SetInt32($"pedidoId_{GetClienteId()}", pedidoId);
        }

        public void ResetPedidoId()
        {
            ContextAccessor.HttpContext.Session.Remove($"pedidoId_{GetClienteId()}");
        }

        private string GetClienteId()
        {
            var claimsPrincipal = ContextAccessor.HttpContext.User;
            return userManager.GetUserId(claimsPrincipal);
        }
    }
}
