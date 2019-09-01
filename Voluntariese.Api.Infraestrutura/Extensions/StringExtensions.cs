using System.Text.RegularExpressions;

namespace Voluntariesepi.Api.Infraestrutura.Extensions
{
    public static class StringExtensions
    {
        private static readonly Regex _somenteNumeros = new Regex(@"[^\d]");
        
        private static readonly Regex _semPreposicoes = new Regex(@"\s(e|d(a|e|i|o|u)s?)\s");

        public static string SomenteNumeros(this string valor)
        {
            return _somenteNumeros.Replace(valor, string.Empty);
        }

        public static string SemPreposicoes(this string valor)
        {
            return  _semPreposicoes.Replace(valor, " ");
        }
    }
}
