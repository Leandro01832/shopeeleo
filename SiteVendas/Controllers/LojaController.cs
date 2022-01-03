using business.classes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SiteVendas.Data;
using SiteVendas.Models.Repository;
using System.Linq;
using System.Threading.Tasks;

namespace SiteVendas.Controllers
{
    public class LojaController : Controller
    {
        private readonly ApplicationDbContext _context;
        public UserManager<IdentityUser> UserManager { get; }
        public IClienteRepository ClienteRepository { get; }

        public LojaController(ApplicationDbContext context, UserManager<IdentityUser> userManager,
            IClienteRepository clienteRepository)
        {
            _context = context;
            UserManager = userManager;
            ClienteRepository = clienteRepository;
        }

        // GET: Loja
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var usuario = await UserManager.GetUserAsync(this.User);
            var applicationDbContext = _context.Loja.Include(l => l.Pessoa).Where(p => p.Pessoa.Email == usuario.Email);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Loja/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loja = await _context.Loja
                .Include(l => l.Pessoa)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (loja == null)
            {
                return NotFound();
            }

            return View(loja);
        }

        public async Task<JsonResult> BuscarLoja(int id)
        {            
            var loja = await _context.Loja.FirstOrDefaultAsync(m => m.Id == id);
            if (loja == null)            
                return Json(null); 

            return Json(loja);
        }
        
        // GET: Loja/Create
        [Authorize]
        public async Task< IActionResult> Create()
        {
            var usuario = await UserManager.GetUserAsync(this.User);
            Cliente cli = await ClienteRepository.Get(usuario.Email);
            ViewData["PessoaId"] = cli.Id;
            return View();
        }

        // POST: Loja/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("PessoaId,NomeFantasia,Cnpj,Id")] Loja loja)
        {
            if (ModelState.IsValid)
            {
                _context.Add(loja);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            var usuario = await UserManager.GetUserAsync(this.User);
            Cliente cli = await ClienteRepository.Get(usuario.Email);
            ViewData["PessoaId"] = cli.Id;
            return View(loja);
        }

        // GET: Loja/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loja = await _context.Loja.FindAsync(id);
            if (loja == null)
            {
                return NotFound();
            }
            var usuario = await UserManager.GetUserAsync(this.User);
            Cliente cli = await ClienteRepository.Get(usuario.Email);
            ViewData["PessoaId"] = cli.Id;
            return View(loja);
        }

        // POST: Loja/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("PessoaId,NomeFantasia,Cnpj,Id")] Loja loja)
        {
            if (id != loja.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(loja);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LojaExists(loja.Id))
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
            var usuario = await UserManager.GetUserAsync(this.User);
            Cliente cli = await ClienteRepository.Get(usuario.Email);
            ViewData["PessoaId"] = cli.Id;
            return View(loja);
        }

        // GET: Loja/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loja = await _context.Loja
                .Include(l => l.Pessoa)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (loja == null)
            {
                return NotFound();
            }

            return View(loja);
        }

        // POST: Loja/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var loja = await _context.Loja.FindAsync(id);
            _context.Loja.Remove(loja);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LojaExists(int id)
        {
            return _context.Loja.Any(e => e.Id == id);
        }
    }
}
