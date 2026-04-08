
using System.ComponentModel;

namespace CrudCafeteria.Models.Enums
{
    public enum Prioridade
    {
        [Description("Baixa")]
        Baixa = 0,

        [Description("Média")]
        Media = 1,

        [Description("Alta")]
        Alta = 2,

        [Description("Especial")]
        Especial = 3
    }
}