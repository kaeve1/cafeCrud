using CrudCafeteria.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace CrudCafeteria.Models.Entidade
{
    public class SolicitacaoManutencao
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome da máquina é obrigatório.")]
        [MaxLength(100, ErrorMessage = "O nome da máquina deve ter no máximo 100 caracteres.")]
        public string NomeMaquina { get; set; } = string.Empty;

        [Required(ErrorMessage = "A localização é obrigatória.")]
        [MaxLength(200, ErrorMessage = "A localização deve ter no máximo 200 caracteres.")]
        public string Localizacao { get; set; } = string.Empty;

        [Required(ErrorMessage = "A descrição do problema é obrigatória.")]
        [MaxLength(1000, ErrorMessage = "A descrição deve ter no máximo 1000 caracteres.")]
        public string DescricaoProblema { get; set; } = string.Empty;


        public Prioridade Prioridade { get; set; } = Prioridade.Baixa;

        public Status Status { get; set; } = Status.Aberta;

        public DateTime DataAbertura { get; set; }
    }
}