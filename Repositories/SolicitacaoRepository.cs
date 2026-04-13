using CrudCafeteria.Data;
using CrudCafeteria.Models.Entidade;
using CrudCafeteria.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CrudCafeteria.Repositories;
public class SolicitacaoRepository : ISolicitacaoRepository
{
    private readonly AppDbContext _context;

    public SolicitacaoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<SolicitacaoManutencao>> GetAll()
    {
        return await _context.Solicitacoes.ToListAsync();
    }

    public async Task<SolicitacaoManutencao?> GetById(int id)
    {
        return await _context.Solicitacoes.FindAsync(id);
    }

    public async Task Add(SolicitacaoManutencao solicitacao)
    {
        await _context.Solicitacoes.AddAsync(solicitacao);
        await _context.SaveChangesAsync();
    }

    public async Task Update(SolicitacaoManutencao solicitacao)
    {
        _context.Solicitacoes.Update(solicitacao);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(SolicitacaoManutencao solicitacao)
    {
        _context.Solicitacoes.Remove(solicitacao);
        await _context.SaveChangesAsync();
    }
}