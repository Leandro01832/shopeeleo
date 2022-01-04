using business.classes;
using SiteVendas.Data;
using System.Collections.Generic;
using System.Linq;

namespace SiteVendas.Models.Repository
{
    public interface IRepositoryLoja
    {
        List<Loja> GetAll();
    }


    public class LojaRepository : BaseRepository<Loja>, IRepositoryLoja
    {
        public LojaRepository(ApplicationDbContext contexto) : base(contexto)
        {

        }

        public List<Loja> GetAll()
        {
            return  dbSet.ToList();
        }
    }
}
