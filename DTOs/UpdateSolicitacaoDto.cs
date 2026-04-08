using CrudCafeteria.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace CrudCafeteria.DTOs;

public class UpdateSolicitacaoDto
{
    public string? NomeMaquina { get; set; } = string.Empty;

    public string? Localizacao { get; set; } = string.Empty;

    public string? DescricaoProblema { get; set; } = string.Empty;

    public Prioridade? Prioridade { get; set; }

    public Status? Status { get; set; }
}