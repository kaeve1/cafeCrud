using CrudCafeteria.DTOs;
using CrudCafeteria.Models.Entidade;

namespace CrudCafeteria.Repositories
{
    public interface ISolicitacaoRepository
    {
        Task<List<SolicitacaoManutencao>> GetAll();
        Task<SolicitacaoManutencao?> GetById(int id);
        Task Add(SolicitacaoManutencao solicitacao);
        Task Update(SolicitacaoManutencao solicitacao);
        Task Delete(SolicitacaoManutencao solicitacao);
    }

}