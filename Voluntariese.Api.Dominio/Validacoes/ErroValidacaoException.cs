using System;
using System.Collections.Generic;

namespace Voluntariese.Api.Dominio.Validacoes
{
    public class ErroValidacaoException : Exception
    {
        public List<ErroValidacao> Erros { get; }

        public ErroValidacaoException(string mensagem)
            : base(mensagem)
        {
            Erros = new List<ErroValidacao>() { new ErroValidacao(mensagem) };
            
        }

        public ErroValidacaoException(string codigo, string mensagem)
            : base(mensagem)
        {
            Erros = new List<ErroValidacao>() { new ErroValidacao(codigo, mensagem) };
        }

        public ErroValidacaoException(List<ErroValidacao> erros)
        {
            Erros = erros;
        }
    }
}
