using CrudCafeteria.Models.Entidade;
using CrudCafeteria.Models.Enums;

namespace CrudCafeteria.Data;

public static class AppDbSeeder
{
    public static void Seed(AppDbContext context)
    {
        if (context.Solicitacoes.Any()) return; 

        context.Solicitacoes.AddRange(
            new SolicitacaoManutencao
            {
                NomeMaquina = "Cafeteira",
                Localizacao = "Sala de Espera",
                DescricaoProblema = "Máquina não aquece a água.",
                Prioridade = Prioridade.Baixa,
                Status = Status.Aberta,
                DataAbertura = DateTime.UtcNow
            },
            new SolicitacaoManutencao
            {
                NomeMaquina = "Ar-Condicionado",
                Localizacao = "Salão de Mesas",
                DescricaoProblema = "Só sai Ar quente",
                Prioridade = Prioridade.Baixa,
                Status = Status.EmAndamento,
                DataAbertura = DateTime.UtcNow
            },
            new SolicitacaoManutencao
            {
                NomeMaquina = "Freezer",
                Localizacao = "Entrada Cafeteria",
                DescricaoProblema = "Porta não veda corretamente",
                Prioridade = Prioridade.Baixa,
                Status = Status.Concluida,
                DataAbertura = DateTime.UtcNow
            },
            new SolicitacaoManutencao
            {
                NomeMaquina = "Forno Elétrico",
                Localizacao = "Cozinha Central",
                DescricaoProblema = "Temporizador com defeito e E luz não liga",
                Prioridade = Prioridade.Media,
                Status = Status.Aberta,
                DataAbertura = DateTime.UtcNow

            },
            new SolicitacaoManutencao
            {
                NomeMaquina = "Fogão Gás",
                Localizacao = "Cozinha Central",
                DescricaoProblema = "Gás Vazando",
                Prioridade = Prioridade.Media,
                Status = Status.EmAndamento,
                DataAbertura = DateTime.UtcNow

            },
            new SolicitacaoManutencao
            {
                NomeMaquina = "Pia",
                Localizacao = "Cozinha Central",
                DescricaoProblema = "Cano Estourado/vazando agua",
                Prioridade = Prioridade.Media,
                Status = Status.Concluida,
                DataAbertura = DateTime.UtcNow

            },
            new SolicitacaoManutencao
            {
                NomeMaquina = "Liquidificar",
                Localizacao = "Bar",
                DescricaoProblema = "Não liga, acho que queimou",
                Prioridade = Prioridade.Alta,
                Status = Status.Aberta,
                DataAbertura = DateTime.UtcNow

            },
            new SolicitacaoManutencao
            {
                NomeMaquina = "Liquidificador",
                Localizacao = "Bar",
                DescricaoProblema = "Não liga, acho que queimou",
                Prioridade = Prioridade.Alta,
                Status = Status.EmAndamento,
                DataAbertura = DateTime.UtcNow

            },
            new SolicitacaoManutencao
            {
                NomeMaquina = "Vaso",
                Localizacao = "Banheiro Masculino",
                DescricaoProblema = "Entupido",
                Prioridade = Prioridade.Alta,
                Status = Status.Concluida,
                DataAbertura = DateTime.UtcNow

            },
            new SolicitacaoManutencao
            {
                NomeMaquina = "Panificadora",
                Localizacao = "Cozinha Central",
                DescricaoProblema = "Devido a chuva não esta mais funcionando",
                Prioridade = Prioridade.Especial,
                Status = Status.EmAndamento,
                DataAbertura = DateTime.UtcNow

            }
        );

        context.SaveChanges();
    }
}