using CrudCafeteria.Models.Enums;

namespace CrudCafeteria.DTOs;

public class ResponseSolicitacaoDto
{
    public int Id { get; set; }
    public string NomeMaquina { get; set; }
    public string Localizacao { get; set; }
    public string DescricaoProblema { get; set; }
    public Prioridade Prioridade { get; set; }
    public Status Status { get; set; }
    public string DataAbertura { get; set; }
}