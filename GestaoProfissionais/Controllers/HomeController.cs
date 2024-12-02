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
    public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 10, string mensagemTipo = null, string mensagemTexto = null)
     {
        ViewBag.Especialidades = await _context.Especialidades.ToListAsync();
        ViewBag.MensagemTipo = mensagemTipo;
        ViewBag.MensagemTexto = mensagemTexto;
        var totalProfissionais = await _context.Profissionais.CountAsync();

        var totalPages = (int)Math.Ceiling(totalProfissionais / (double)pageSize);

        var profissionais = await _context.Profissionais
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        ViewData["CurrentPage"] = pageNumber;
        ViewData["TotalPages"] = totalPages;
        ViewData["PageSize"] = pageSize;

        return View("~/Views/Index.cshtml",profissionais);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var profissional = await _context.Profissionais.FindAsync(id);
        if (profissional == null) return NotFound();

        return View(profissional);
    }

    [HttpPost("Edit")]
    public async Task<IActionResult> Edit(int Id, string Nome, string Especialidade, string TipoDocumento, string NumeroDocumento)
    {
        var profissionalExistente = await _context.Profissionais.FindAsync(Id);
        string mensagemTipo;
        string mensagemTexto;
        if (profissionalExistente != null)
        {
            profissionalExistente.Nome = Nome;
            profissionalExistente.Especialidade = Especialidade;
            profissionalExistente.TipoDocumento = TipoDocumento;
            profissionalExistente.NumeroDocumento = NumeroDocumento;

            await _context.SaveChangesAsync();
            mensagemTipo = "sucess";
            mensagemTexto = "Profissional editado com sucesso!";
        } else
        {
            mensagemTipo = "danger";
            mensagemTexto = "Erro ao editar profissional.";
        }
        return RedirectToAction(nameof(Index), new { mensagemTipo, mensagemTexto });
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        var profissional = await _context.Profissionais.FindAsync(id);
        string mensagemTipo;
        string mensagemTexto;

        if (profissional != null)
        {
            _context.Profissionais.Remove(profissional);
            await _context.SaveChangesAsync();
            mensagemTipo = "success";
            mensagemTexto = "Profissional excluído com sucesso!";
        }
        else
        {
            mensagemTipo = "danger";
            mensagemTexto = "Erro ao excluir profissional.";
        }
        return RedirectToAction(nameof(Index), new { mensagemTipo, mensagemTexto });
    }
}
