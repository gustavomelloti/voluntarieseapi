using System.Text.RegularExpressions;
using Voluntariesepi.Api.Infraestrutura.Utilitarios.Const;

namespace Voluntariesepi.Api.Infraestrutura.Utilitarios.Helpers
{
    public static class SenhaHelper
    {
        public static bool Validar(string senha)
        {
            return Regex.IsMatch(senha, ExpressaoRegular.SenhaValida);
        }
    }
}
