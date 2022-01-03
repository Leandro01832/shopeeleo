using business;
using business.classes;
using Microsoft.EntityFrameworkCore;
using SiteVendas.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteVendas.Models.Repository
{
    public interface IClienteRepository
    {
        IEnumerable<Cliente> GetAll();
        Task<Cliente> Get(string email);
        void Add(Cliente item);
        void Update(Cliente item);
        bool Delete(int id);
    }

    public class RepositoryCliente : BaseRepository<Cliente>, IClienteRepository
    {

        public RepositoryCliente(ApplicationDbContext contexto) : base(contexto)
        {
            Contexto = contexto;
        }

        public ApplicationDbContext Contexto { get; }

        public void Add(Cliente item)
        {
            dbSet.Add(item);
            Contexto.SaveChanges();
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

        public async Task<Cliente> Get(string email)
        {
            return await dbSet.FirstAsync(p => p.Email == email);
        }

        public IEnumerable<Cliente> GetAll()
        {
            return dbSet.ToList();
        }

        public void Update(Cliente item)
        {
            Contexto.Entry(item).State = EntityState.Modified;
            Contexto.SaveChanges();
        }
    }
}