using CrudCafeteria.DTOs;
using CrudCafeteria.Services;
using Microsoft.AspNetCore.Mvc;

namespace CrudCafeteria.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SolicitacoesController : ControllerBase
{
    private readonly SolicitacaoService _service;
    private readonly ILogger<SolicitacoesController> _logger;

    public SolicitacoesController(
        SolicitacaoService service,
        ILogger<SolicitacoesController> logger)
    {
        _service = service;
        _logger = logger;
    }


    private ObjectResult ErroInterno(string operacao, Exception ex)
    {
        _logger.LogError(ex, "Erro ao {Operacao}: {Mensagem}", operacao, ex.Message);

        return StatusCode(500, new
        {
            erro = "Erro interno no servidor.",
            detalhe = ex.Message,
            operacao
        });
    }

    // GET: api/solicitacoes ou status
    [HttpGet]
    public async Task<IActionResult> GetAll(
    [FromQuery] string? status,
    [FromQuery] string? prioridade)
    {
        try
        {
            var lista = await _service.GetAll(status, prioridade);

            if (lista.Count == 0)
                return Ok(new { mensagem = "Nenhuma solicitação encontrada.", dados = lista });

            return Ok(lista);
        }
        catch (Exception ex)
        {
            return ErroInterno("listar solicitações", ex);
        }
    }

    // GET: api/solicitacoes/{id}
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        if (id <= 0)
            return BadRequest(new { erro = "ID inválido." });

        try
        {
            var solicitacao = await _service.GetById(id);

            if (solicitacao == null)
            {
                _logger.LogInformation("Solicitação {Id} não encontrada.", id);
                return NotFound(new { erro = $"Solicitação com o id {id} Não encontrada." });
            }

            return Ok(solicitacao);
        }
        catch (Exception ex)
        {
            return ErroInterno($"buscar solicitação {id}", ex);
        }
    }

    // POST: api/solicitacoes
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateSolicitacaoDto dto)
    {
        if (!ModelState.IsValid)
        {
            var erros = ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage);

            return BadRequest(new { erro = "Dados inválidos.", detalhe = erros });
        }

        try
        {
            var result = await _service.Create(dto);

            _logger.LogInformation("Solicitação {Id} criada.", result.Id);

            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }
        catch (Exception ex)
        {
            return ErroInterno("criar solicitação", ex);
        }
    }

    // PUT: api/solicitacoes/{id}
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateSolicitacaoDto dto)
    {
        if (id <= 0)
            return BadRequest(new { erro = "ID inválido." });

        if (!ModelState.IsValid)
        {
            var erros = ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage);

            return BadRequest(new { erro = "Dados inválidos.", detalhe = erros });
        }

        try
        {
            var atualizado = await _service.Update(id, dto);

            if (!atualizado)
            {
                _logger.LogInformation("Solicitação {Id} não encontrada para atualização.", id);
                return NotFound(new { erro = $"Solicitação com o id {id} Não encontrada." });
            }

            _logger.LogInformation("Solicitação {Id} atualizada.", id);
            Response.Headers.Add("X-Mensagem", "Registro atualizado com sucesso");
            Response.Headers.Add("X-Id", id.ToString());
            return NoContent();
        }
        catch (Exception ex)
        {
            return ErroInterno($"atualizar solicitação {id}", ex);
        }
    }

    // DELETE: api/solicitacoes/{id}
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        if (id <= 0)
            return BadRequest(new { erro = "ID inválido." });

        try
        {
            var deletado = await _service.Delete(id);

            if (!deletado)
            {
                _logger.LogInformation("Solicitação {Id} não encontrada para exclusão.", id);
                return NotFound(new { erro = $"Solicitação com o id {id} Não encontrada." });
            }

            _logger.LogInformation("Solicitação {Id} excluída.", id);
            Response.Headers.Add("X-Mensagem", "Registro deletado com sucesso");
            Response.Headers.Add("X-Id", id.ToString());
            return NoContent();
        }
        catch (Exception ex)
        {
            return ErroInterno($"excluir solicitação {id}", ex);
        }
    }
}