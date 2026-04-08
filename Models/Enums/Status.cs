using System.ComponentModel;

namespace CrudCafeteria.Models.Enums
{
    public enum Status
    {
        [Description("Aberta")]
        Aberta = 0,

        [Description("Em Andamento")]
        EmAndamento = 1,

        [Description("Concluída")]
        Concluida = 2
    }
}