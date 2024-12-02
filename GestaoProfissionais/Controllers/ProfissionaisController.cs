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
