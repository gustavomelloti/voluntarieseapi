using System;
using System.Text.RegularExpressions;
using Voluntariesepi.Api.Infraestrutura.Utilitarios.Const;

namespace Voluntariesepi.Api.Infraestrutura.Utilitarios.Helpers
{
    public static class CnpjHelper
    {
        private static readonly int[] Multiplier1 = {5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2};

        private static readonly int[] Multiplier2 = {6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2};

        public static bool Validar(string valor)
        {
            if (string.IsNullOrWhiteSpace(valor))
            {
                return false;
            }

            if (!Regex.IsMatch(valor, ExpressaoRegular.CnpjValido))
            {
                return false;
            }

            valor = Limpar(valor);

            if (TemDigitosIguais(valor))
            {
                return false;
            }

            var inputDigit1 = Convert.ToInt32(valor.Substring(12, 1));
            var inputDigit2 = Convert.ToInt32(valor.Substring(13, 1));

            var calcDigit1 = CreateChecksum(valor.Substring(0, 12), Multiplier1);
            var calcDigit2 = CreateChecksum(valor.Substring(0, 13), Multiplier2);

            return inputDigit1 == calcDigit1 && inputDigit2 == calcDigit2;
        }

        private static int CreateChecksum(string texto, int[] multiplier)
        {
            var sum = 0;

            for (var i = texto.Length - 1; i > -1; i--)
            {
                sum += Convert.ToInt32(texto[i].ToString()) * multiplier[i];
            }

            var remainder = sum % 11;
            var digit = (remainder < 2) ? 0 : 11 - remainder;

            return digit;
        }

        private static string Limpar(string valor)
        {
            return valor
                .Trim()
                .ToLowerInvariant()
                .Replace(".", string.Empty)
                .Replace("-", string.Empty)
                .Replace("/", string.Empty);
        }

        private static bool TemDigitosIguais(string valor)
        {
            return !string.IsNullOrWhiteSpace(valor) && Regex.IsMatch(valor, ExpressaoRegular.DigitosIguais);
        }
    }
}