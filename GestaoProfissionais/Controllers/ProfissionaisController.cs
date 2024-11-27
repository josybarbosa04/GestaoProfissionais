using GestaoProfissionais.Data;
using GestaoProfissionais.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestaoProfissionais.Controllers
{
    public class ProfissionaisController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProfissionaisController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string filtroEspecialidade = null)
        {
            var profissionais = _context.Profissionais.AsQueryable();

            if (!string.IsNullOrEmpty(filtroEspecialidade))
                profissionais = profissionais.Where(p => p.Especialidade == filtroEspecialidade);

            ViewBag.Especialidades = await _context.Especialidades.ToListAsync();
            return View(await profissionais.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Profissional profissional)
        {
            if (ModelState.IsValid)
            {
                _context.Add(profissional);
                await _context.SaveChangesAsync();
                TempData["Mensagem"] = "Profissional cadastrado com sucesso!";
                return RedirectToAction(nameof(Index));
            }
            return View(profissional);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var profissional = await _context.Profissionais.FindAsync(id);
            if (profissional == null) return NotFound();

            ViewBag.Especialidades = await _context.Especialidades.ToListAsync();
            return View(profissional);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Profissional profissional)
        {
            if (ModelState.IsValid)
            {
                _context.Update(profissional);
                await _context.SaveChangesAsync();
                TempData["Mensagem"] = "Profissional atualizado com sucesso!";
                return RedirectToAction(nameof(Index));
            }
            return View(profissional);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var profissional = await _context.Profissionais.FindAsync(id);
            if (profissional != null)
            {
                _context.Profissionais.Remove(profissional);
                await _context.SaveChangesAsync();
                TempData["Mensagem"] = "Profissional excluído com sucesso!";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
