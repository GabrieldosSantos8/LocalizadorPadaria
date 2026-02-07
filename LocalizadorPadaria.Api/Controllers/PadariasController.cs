using Microsoft.AspNetCore.Mvc;
using LocalizadorPadaria.Api.Data;
using LocalizadorPadaria.Api.Services;
using Microsoft.EntityFrameworkCore;

namespace LocalizadorPadaria.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PadariasController : ControllerBase {
    private readonly AppDbContext _context;
    private readonly IViaCepService _viaCepService;

    public PadariasController(AppDbContext context, IViaCepService viaCepService) {
        _context = context;
        _viaCepService = viaCepService;
    }

    [HttpPost]
    public async Task<IActionResult> Criar(string nome, string cep) {
        var padaria = await _viaCepService.PreencherEndereco(nome, cep);
        
        if (padaria == null) return BadRequest("CEP inválido ou serviço indisponível.");

        _context.Padarias.Add(padaria);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(Listar), new { id = padaria.Id }, padaria);
    }

    [HttpGet]
    public async Task<IActionResult> Listar() => Ok(await _context.Padarias.ToListAsync());
}