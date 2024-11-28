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

        //Paginação
        public async Task<IActionResult> Paginacao(int pageNumber = 1, int pageSize = 10)
        {
            var totalProfissionais = await _context.Profissionais.CountAsync();

            var totalPages = (int)Math.Ceiling(totalProfissionais / (double)pageSize);

            var profissionais = await _context.Profissionais
                .Skip((pageNumber - 1) * pageSize) 
                .Take(pageSize)
                .ToListAsync();

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
