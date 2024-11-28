using GestaoProfissionais.Data;
using GestaoProfissionais.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestaoProfissionais.Controllers
{
    [Route("Professional")]
    public class ProfissionaisController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProfissionaisController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var profissionais = _context.Profissionais.AsQueryable();

            ViewBag.Especialidades = await _context.Especialidades.ToListAsync();
            return View(await profissionais.ToListAsync());
        }
        //Paginação
        public async Task<IActionResult> Paginacao(int pageNumber = 1, int pageSize = 10)
        {
            var totalProfissionais = await _context.Profissionais.CountAsync();  // Total de registros

            // Calcular o número total de páginas
            var totalPages = (int)Math.Ceiling(totalProfissionais / (double)pageSize);

            // Obter os dados da página atual
            var profissionais = await _context.Profissionais
                .Skip((pageNumber - 1) * pageSize) // Pula os registros das páginas anteriores
                .Take(pageSize) // Limita os registros a serem exibidos
                .ToListAsync();

            // Definir o ViewData com a página atual, total de páginas e tamanho da página
            ViewData["CurrentPage"] = pageNumber;
            ViewData["TotalPages"] = totalPages;
            ViewData["PageSize"] = pageSize;

            return View(profissionais);
        }

        [HttpPost("Create")]
        public IActionResult Create([FromBody] Profissional profissional)
        {
            if (ModelState.IsValid)
            {
                _context.Add(profissional);
                _context.SaveChanges();
                return Ok();
            }
            return BadRequest();
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
        [HttpGet("GetEspecialidades")]
        public IActionResult GetEspecialidades()
        {
            try
            {
                var especialidades = _context.Especialidades
                                .Select(s => new { s.Id, s.Nome })
                                .ToList();
                            return Json(especialidades);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }
    }
}
