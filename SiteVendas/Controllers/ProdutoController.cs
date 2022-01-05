using business.classes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SiteVendas.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SiteVendas.Controllers
{
    [Authorize]
    public class ProdutoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProdutoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Produto
        [Route("Produto/Index/{id}")]
        [Route("Loja/{id}")]
        [Route("Loja/{id}/{pagina}")]
        public async Task<IActionResult> Index(int id, int? pagina)
        {
            int numeroPagina = (pagina ?? 1);
            const int TAMANHO_PAGINA = 10;

            ViewBag.pagina = numeroPagina;
            ViewBag.loja = id;
            var applicationDbContext = await _context.Produto.Include(p => p.Loja)
                .Where(l => l.LojaId == id)
                .Skip((numeroPagina - 1) * TAMANHO_PAGINA)
                .Take(TAMANHO_PAGINA).ToListAsync();
            return View(applicationDbContext);
        }

        // GET: Produto/Details/5
        [Route("Produto/Details/{id}/{pagina}")]
        public async Task<IActionResult> Details(int id, int pagina)
        {
            var applicationDbContext = await _context.Produto.Include(p => p.Loja)
                .Where(l => l.LojaId == id).ToListAsync();

            ViewBag.pagina = pagina;

            return PartialView(applicationDbContext[pagina - 1]);
        }

        [Route("Produto/Details2/{id}")]
        public async Task<IActionResult> Details2(int id)
        {
            var produto = await _context.Produto.Include(p => p.Loja)
                .FirstOrDefaultAsync(l => l.Id == id);

            var produtos = await _context.Produto.Include(p => p.Loja)
                .Where(l => l.LojaId == produto.LojaId).ToListAsync();

            ViewBag.pagina = produtos.IndexOf(produto) + 1;

            return PartialView(produto);
        }

        // GET: Produto/Create
        public IActionResult Create(int id)
        {
            ViewData["LojaId"] = id;
            return View();
        }

        // POST: Produto/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LojaId,Nome,Preco,Id,Categoria")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                produto.Id = 0;
                _context.Add(produto);
                await _context.SaveChangesAsync();
                return Redirect("/Loja/" + produto.LojaId);
            }
            ViewData["LojaId"] =  produto.LojaId;
            return View(produto);
        }

        // GET: Produto/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produto.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
            }
            ViewData["LojaId"] =  produto.LojaId;
            return View(produto);
        }

        // POST: Produto/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LojaId,Nome,Preco,Id")] Produto produto)
        {
            if (id != produto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdutoExists(produto.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["LojaId"] = produto.LojaId;
            return View(produto);
        }

        // GET: Produto/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produto
                .Include(p => p.Loja)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // POST: Produto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var produto = await _context.Produto.FindAsync(id);
            _context.Produto.Remove(produto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdutoExists(int id)
        {
            return _context.Produto.Any(e => e.Id == id);
        }
    }
}
