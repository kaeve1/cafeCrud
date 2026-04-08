using CrudCafeteria.Models;
using CrudCafeteria.Models.Entidade;
using Microsoft.EntityFrameworkCore;

namespace CrudCafeteria.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<SolicitacaoManutencao> Solicitacoes { get; set; }
}