using CrudCafeteria.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace CrudCafeteria.DTOs;

public class CreateSolicitacaoDto
{
    [Required]
    public string NomeMaquina { get; set; } = string.Empty;

    [Required]
    public string Localizacao { get; set; } = string.Empty;

    [Required]
    public string DescricaoProblema { get; set; } = string.Empty;

    public Prioridade Prioridade { get; set; } = Prioridade.Baixa;
}