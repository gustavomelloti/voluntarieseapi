using System;

namespace Voluntariese.Api.Infraestrutura.Utilitarios.Helpers
{
    public static class CartaoCreditoHelper
    {
        public static bool ValidarCodigoSeguranca(string codigoSeguranca)
        {
            return !string.IsNullOrWhiteSpace(codigoSeguranca) && codigoSeguranca.Length == 3;
        }

        public static bool ValidarDataValidade(string dataValidade)
        {
            if (string.IsNullOrWhiteSpace(dataValidade))
                return false;

            if (DateTime.TryParse(dataValidade, out DateTime dataValidadeEmDate))
                if (dataValidadeEmDate >= DateTime.Now)
                    return true;

            return false;
        }
    }
}
