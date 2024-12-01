using GestaoProfissionais.Data;
using GestaoProfissionais.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestaoProfissionais.Controllers
{
    [Route("Profissional")]
    public class ProfissionaisController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProfissionaisController(ApplicationDbContext context)
        {
            _context = context;
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
        public async Task<IActionResult> Edit(int Id, string Nome, string Especialidade, string TipoDocumento, string NumeroDocumento)
        {
            if (ModelState.IsValid)
            {
                var profissionalExistente = await _context.Profissionais.FindAsync(Id);
                if (profissionalExistente != null)
                {
                    profissionalExistente.Nome = Nome;
                    profissionalExistente.Especialidade = Especialidade;
                    profissionalExistente.TipoDocumento = TipoDocumento;
                    profissionalExistente.NumeroDocumento = NumeroDocumento;

                    await _context.SaveChangesAsync();
                    TempData["Mensagem"] = "Profissional atualizado com sucesso!";
                    return RedirectToAction(nameof(Index));
                }
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet("GetEspecialidades")]
        public IActionResult GetEspecialidades()
        {
            var especialidades = _context.Especialidades
                            .Select(s => new { s.Id, s.Nome, s.TipoDocumento })
                            .ToList();
                        return Json(especialidades);
        }
    }
}
