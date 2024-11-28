using GestaoProfissionais.Data;
using GestaoProfissionais.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class HomeController : Controller
{
    private readonly ApplicationDbContext _context;

    public HomeController(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<IActionResult> Index()
     {
        ViewBag.Especialidades = await _context.Especialidades.ToListAsync();
        var profissionais = await _context.Profissionais.ToListAsync();

        return View("~/Views/Index.cshtml",profissionais);
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
