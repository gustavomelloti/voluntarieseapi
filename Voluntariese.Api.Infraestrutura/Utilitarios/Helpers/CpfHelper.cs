using System;
using System.Text.RegularExpressions;
using Voluntariesepi.Api.Infraestrutura.Utilitarios.Const;

namespace Voluntariesepi.Api.Infraestrutura.Utilitarios.Helpers
{
    public static class CpfHelper
    {
        public static bool Validar(string valor)
        {
            if (string.IsNullOrWhiteSpace(valor))
            {
                return false;
            }

            if (!Regex.IsMatch(valor, ExpressaoRegular.CpfValido))
            {
                return false;
            }

            valor = Limpar(valor);

            if (TemDigitosIguais(valor))
            {
                return false;
            }

            var inputDigit1 = Convert.ToInt32(valor.Substring(9, 1));
            var inputDigit2 = Convert.ToInt32(valor.Substring(10, 1));

            var calcDigit1 = CreateChecksum(valor.Substring(0, 9));
            var calcDigit2 = CreateChecksum(valor.Substring(0, 10));

            return inputDigit1 == calcDigit1 && inputDigit2 == calcDigit2;
        }

        private static int CreateChecksum(string texto)
        {
            var sum = 0;

            for (var i = texto.Length - 1; i > -1; i--)
            {
                sum += Convert.ToInt32(texto[i].ToString()) * (texto.Length + 1 - i);
            }

            int digit = 11 - (sum % 11);

            if (digit == 10 || digit == 11)
            {
                digit = 0;
            }

            return digit;
        }

        private static string Limpar(string valor)
        {
            return valor
                .Trim()
                .ToLowerInvariant()
                .Replace(".", string.Empty)
                .Replace("-", string.Empty);
        }

        private static bool TemDigitosIguais(string valor)
        {
            return !string.IsNullOrWhiteSpace(valor) && Regex.IsMatch(valor, ExpressaoRegular.DigitosIguais);
        }
    }
}