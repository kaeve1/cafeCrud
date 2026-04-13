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
                NomeMaquina = "Cafeteira Nespresso",
                Localizacao = "Recepção - Térreo",
                DescricaoProblema = "Máquina não aquece a água. Sai café frio.",
                Prioridade = Prioridade.Baixa,
                Status = Status.Aberta,
                DataAbertura = DateTime.UtcNow
            },
            new SolicitacaoManutencao
            {
                NomeMaquina = "Cafeteira Expresso",
                Localizacao = "Copa - 1º Andar",
                DescricaoProblema = "Máquina está vazando água pela base.",
                Prioridade = Prioridade.Baixa,
                Status = Status.EmAndamento,
                DataAbertura = DateTime.UtcNow
            },
            new SolicitacaoManutencao
            {
                NomeMaquina = "Cafeteira Automática",
                Localizacao = "Sala de Reunião - 2º Andar",
                DescricaoProblema = "Bandeja de resíduos travada, não abre para limpeza.",
                Prioridade = Prioridade.Baixa,
                Status = Status.Concluida,
                DataAbertura = DateTime.UtcNow
            },
            new SolicitacaoManutencao
            {
                NomeMaquina = "Cafeteira Nespresso",
                Localizacao = "Copa - 2º Andar",
                DescricaoProblema = "Visor apagado, máquina não responde aos comandos.",
                Prioridade = Prioridade.Media,
                Status = Status.Aberta,
                DataAbertura = DateTime.UtcNow
            },
            new SolicitacaoManutencao
            {
                NomeMaquina = "Cafeteira Expresso",
                Localizacao = "Copa - 3º Andar",
                DescricaoProblema = "Café saindo com gosto de queimado, possível problema no aquecedor.",
                Prioridade = Prioridade.Media,
                Status = Status.EmAndamento,
                DataAbertura = DateTime.UtcNow
            },
            new SolicitacaoManutencao
            {
                NomeMaquina = "Cafeteira Automática",
                Localizacao = "Sala de Descanso - Térreo",
                DescricaoProblema = "Moedor de grãos fazendo barulho excessivo.",
                Prioridade = Prioridade.Media,
                Status = Status.Concluida,
                DataAbertura = DateTime.UtcNow
            },
            new SolicitacaoManutencao
            {
                NomeMaquina = "Cafeteira Nespresso",
                Localizacao = "Diretoria - 4º Andar",
                DescricaoProblema = "Máquina não reconhece as cápsulas, trava no ciclo de preparo.",
                Prioridade = Prioridade.Alta,
                Status = Status.Aberta,
                DataAbertura = DateTime.UtcNow
            },
            new SolicitacaoManutencao
            {
                NomeMaquina = "Cafeteira Expresso",
                Localizacao = "Copa - 4º Andar",
                DescricaoProblema = "Bomba de pressão com defeito, café sai sem pressão.",
                Prioridade = Prioridade.Alta,
                Status = Status.EmAndamento,
                DataAbertura = DateTime.UtcNow
            },
            new SolicitacaoManutencao
            {
                NomeMaquina = "Cafeteira Automática",
                Localizacao = "Sala de Reunião - 1º Andar",
                DescricaoProblema = "Painel eletrônico com erro E04, máquina fora de operação.",
                Prioridade = Prioridade.Alta,
                Status = Status.Concluida,
                DataAbertura = DateTime.UtcNow
            },
            new SolicitacaoManutencao
            {
                NomeMaquina = "Cafeteira Industrial",
                Localizacao = "Refeitório - Térreo",
                DescricaoProblema = "Curto circuito no painel elétrico, risco de incêndio. Máquina desligada.",
                Prioridade = Prioridade.Especial,
                Status = Status.EmAndamento,
                DataAbertura = DateTime.UtcNow
            }
        );

        context.SaveChanges();
    }
}