using CrudCafeteria.DTOs;
using CrudCafeteria.Models.Entidade;
using CrudCafeteria.Models.Enums;
using CrudCafeteria.Repositories;

namespace CrudCafeteria.Services
{
    public class SolicitacaoService
    {
        private readonly ISolicitacaoRepository _repository;

        public SolicitacaoService(ISolicitacaoRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ResponseSolicitacaoDto>> GetAll(string? status, string? prioridade)
        {
            var query = await _repository.GetAll();

            if (!string.IsNullOrWhiteSpace(status))
            {
                var statusConvertido = ConverterStatus(status);
                if (statusConvertido.HasValue)
                    query = query.Where(s => s.Status == statusConvertido.Value).ToList();
            }

            if (!string.IsNullOrWhiteSpace(prioridade))
            {
                var prioridadeConvertida = ConverterPrioridade(prioridade);
                if (prioridadeConvertida.HasValue)
                    query = query.Where(s => s.Prioridade == prioridadeConvertida.Value).ToList();
            }

            return query.Select(s => new ResponseSolicitacaoDto
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
            }).ToList();
        }

        public async Task<ResponseSolicitacaoDto?> GetById(int id)
        {
            var s = await _repository.GetById(id);

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

            await _repository.Add(solicitacao);

            return await GetById(solicitacao.Id); // *
        }

        public async Task<bool> Update(int id, UpdateSolicitacaoDto dto)
        {
            var existente = await _repository.GetById(id);

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

            await _repository.Update(existente);
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var solicitacao = await _repository.GetById(id);

            if (solicitacao == null)
                return false;

            await _repository.Delete(solicitacao);
            return true;
        }


        private Status? ConverterStatus(string valor)
        {
            if (Enum.TryParse<Status>(valor, ignoreCase: true, out var resultado))
                return resultado;

            return null;
        }

        private Prioridade? ConverterPrioridade(string valor)
        {
            if (Enum.TryParse<Prioridade>(valor, ignoreCase: true, out var resultado))
                return resultado;

            return null;
        }
    }
}