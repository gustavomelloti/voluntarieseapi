using System;

namespace Voluntariese.Api.Dominio.Autenticacao
{
    public class AcessoNegadoException : Exception
    {
        public AcessoNegadoException()
            : base("O seu acesso expirou, por favor realize o login novamente.")
        {
        }
    }
}
