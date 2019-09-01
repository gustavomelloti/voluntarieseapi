using System.Text.RegularExpressions;

namespace Voluntariese.Api.Infraestrutura.Utilitarios.Helpers
{
    public static class EmailHelper
    {
        public static bool Validar(string email)
        {
            return Regex.IsMatch(email, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }
    }
}
