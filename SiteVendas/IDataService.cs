using System;
using System.Threading.Tasks;

namespace SiteVendas
{
    interface IDataService
    {
        Task InicializaDBAsync(IServiceProvider provider);
    }
}
