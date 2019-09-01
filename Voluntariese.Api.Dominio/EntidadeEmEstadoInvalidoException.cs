using System;

namespace Voluntariese.Api.Dominio
{
    public class EntidadeEmEstadoInvalidoException : Exception
    {
        public EntidadeEmEstadoInvalidoException(string nomePropriedade)
            : base($"A propriedade {nomePropriedade} é obrigatória para o objeto estar em um estado válido.")
        {
        }
    }
}
