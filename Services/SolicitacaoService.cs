using CrudCafeteria.Data;
using CrudCafeteria.DTOs;
using CrudCafeteria.Models.Entidade;
using CrudCafeteria.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace CrudCafeteria.Services
{
    public class SolicitacaoService : ISolicitacaoService
    {
        private readonly AppDbContext _context;

        public SolicitacaoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ResponseSolicitacaoDto>> GetAll(string? status, string? prioridade)
        {
            var query = _context.Solicitacoes.AsQueryable();

            if (!string.IsNullOrWhiteSpace(status))
            {
                var statusConvertido = ConverterStatus(status);
                if (statusConvertido.HasValue)
                    query = query.Where(s => s.Status == statusConvertido.Value);
            }

            if (!string.IsNullOrWhiteSpace(prioridade))
            {
                var prioridadeConvertida = ConverterPrioridade(prioridade);
                if (prioridadeConvertida.HasValue)
                    query = query.Where(s => s.Prioridade == prioridadeConvertida.Value);
            }

            return await query
                .Select(s => new ResponseSolicitacaoDto
                {
                    Id = s.Id,
                    NomeMaquina = s.NomeMaquina,
                    Localizacao = s.Localizacao,
                    DescricaoProblema = s.DescricaoProblema,
                    Prioridade = s.Prioridade,
                    Status = s.Status,
                    DataAbertura = s.DataAbertura
                        .ToLocalTime()
                        .ToString("dd/MM/yyyy HH:mm")
                })
                .ToListAsync();
        }

        public async Task<ResponseSolicitacaoDto?> GetById(int id)
        {
            var s = await _context.Solicitacoes.FindAsync(id);

            if (s == null)
                return null;

            return new ResponseSolicitacaoDto
            {
                Id = s.Id,
                NomeMaquina = s.NomeMaquina,
                Localizacao = s.Localizacao,
                DescricaoProblema = s.DescricaoProblema,
                Prioridade = s.Prioridade,
                Status = s.Status,
                DataAbertura = s.DataAbertura
                    .ToLocalTime()
                    .ToString("dd/MM/yyyy HH:mm")
            };
        }

        public async Task<ResponseSolicitacaoDto> Create(CreateSolicitacaoDto dto)
        {
            var solicitacao = new SolicitacaoManutencao
            {
                NomeMaquina = dto.NomeMaquina,
                Localizacao = dto.Localizacao,
                DescricaoProblema = dto.DescricaoProblema,
                Prioridade = dto.Prioridade,
                Status = Status.Aberta,
                DataAbertura = DateTime.UtcNow
            };

            _context.Solicitacoes.Add(solicitacao);
            await _context.SaveChangesAsync();

            return await GetById(solicitacao.Id);
        }

        public async Task<bool> Update(int id, UpdateSolicitacaoDto dto)
        {
            var existente = await _context.Solicitacoes.FindAsync(id);

            if (existente == null)
                return false;

            if (!string.IsNullOrWhiteSpace(dto.NomeMaquina))
                existente.NomeMaquina = dto.NomeMaquina;

            if (!string.IsNullOrWhiteSpace(dto.Localizacao))
                existente.Localizacao = dto.Localizacao;

            if (!string.IsNullOrWhiteSpace(dto.DescricaoProblema))
                existente.DescricaoProblema = dto.DescricaoProblema;

            if (dto.Prioridade.HasValue)
                existente.Prioridade = dto.Prioridade.Value;

            if (dto.Status.HasValue)
                existente.Status = dto.Status.Value;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var solicitacao = await _context.Solicitacoes.FindAsync(id);

            if (solicitacao == null)
                return false;

            _context.Solicitacoes.Remove(solicitacao);
            await _context.SaveChangesAsync();

            return true;
        }

        private Status? ConverterStatus(string valor)
        {
            var normalizado = valor.ToLower().Trim();

            return normalizado switch
            {
                "aberta" => Status.Aberta,
                "em andamento" => Status.EmAndamento,
                "emandamento" => Status.EmAndamento,
                "concluida" => Status.Concluida,
                "concluido" => Status.Concluida,
                "concluído" => Status.Concluida,
                _ => null
            };
        }

        private Prioridade? ConverterPrioridade(string valor)
        {
            var normalizado = valor.ToLower().Trim();

            return normalizado switch
            {
                "baixa" => Prioridade.Baixa,
                "media" => Prioridade.Media,
                "média" => Prioridade.Media,
                "alta" => Prioridade.Alta,
                _ => null
            };
        }
    }
}