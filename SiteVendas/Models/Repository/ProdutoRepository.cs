﻿using business;
using business.classes;
using Microsoft.EntityFrameworkCore;
using SiteVendas.Data;
using SiteVendas.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteVendas.Models.Repository
{
    public interface IProdutoRepository
    {
        IEnumerable<Produto> GetAll();
        Produto Get(int id);
        void Add(Produto item);
        void Update(Produto item);
        bool Delete(int id);
        Task<BuscaProdutosViewModel> GetProdutosAsync(string pesquisa);
    }

    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(ApplicationDbContext contexto) : base(contexto)
        {
            Contexto = contexto;
        }

        public ApplicationDbContext Contexto { get; }

        public void Add(Produto item)
        {
            dbSet.Add(item);
            Contexto.SaveChanges();
        }

        public bool Delete(int id)
        {
            var prod = dbSet.FirstOrDefault(p => p.Id == id);

            if(prod != null)
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

        public Produto Get(int id)
        {
            return dbSet.First(p => p.Id == id);
        }

        public IEnumerable<Produto> GetAll()
        {
            return dbSet.ToList();
        }

        public async Task<BuscaProdutosViewModel> GetProdutosAsync(string pesquisa)
        {
            IQueryable<Produto> query = dbSet;

            if (!string.IsNullOrEmpty(pesquisa))
            {
                query = query.Where(q => q.Nome.Contains(pesquisa));
            }

            return new BuscaProdutosViewModel(await query.ToListAsync(), pesquisa);
        }

        public void Update(Produto item)
        {
            Contexto.Entry(item).State = EntityState.Modified;
            Contexto.SaveChanges();
        }
        
    }
}