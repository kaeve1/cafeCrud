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
            var lista = await _repository.GetAll();

            if (!string.IsNullOrWhiteSpace(status))
            {
                var statusConvertido = ConverterStatus(status);
                if (statusConvertido.HasValue)
                    lista = lista.Where(s => s.Status == statusConvertido.Value).ToList();
            }

            if (!string.IsNullOrWhiteSpace(prioridade))
            {
                var prioridadeConvertida = ConverterPrioridade(prioridade);
                if (prioridadeConvertida.HasValue)
                    lista = lista.Where(s => s.Prioridade == prioridadeConvertida.Value).ToList();
            }

            return lista.Select(s => new ResponseSolicitacaoDto
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

            return await GetById(solicitacao.Id);
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
            var normalizado = valor.ToLower().Trim();

            return normalizado switch
            {
                "aberta" => Status.Aberta,
                "aberto" => Status.Aberta,
                "em andamento" => Status.EmAndamento,
                "emandamento" => Status.EmAndamento,
                "concluida" => Status.Concluida,
                "concluido" => Status.Concluida,
                "concluída" => Status.Concluida,
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
                "baixo" => Prioridade.Baixa,
                "media" => Prioridade.Media,
                "medio" => Prioridade.Media,
                "média" => Prioridade.Media,
                "médio" => Prioridade.Media,
                "alta" => Prioridade.Alta,
                "alto" => Prioridade.Alta,
                "especial" => Prioridade.Especial,
                _ => null
            };
        }
    }
}