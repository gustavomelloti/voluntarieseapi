using System.Collections.Generic;
using System.Linq;
using Voluntariese.Api.Dominio.Validacoes;

namespace Voluntariese.Api.Aplicacao.Base
{
    public abstract class BaseRequest
    {
        public const string CampoObrigatorio = "CAMPO_OBRIGATORIO";
        public const string CampoInvalido = "CAMPO_INVALIDO";

        protected List<ErroValidacao> Erros { get; set; }

        protected bool EstaValido => !Erros.Any();

        protected BaseRequest()
        {
            Erros = new List<ErroValidacao>();
        }

        protected abstract void ExecutarValidacoes();

        public void AdicionarErroCampoObrigatorio(string nomeCampo)
        {
            AdicionarErro(CampoObrigatorio, $"O campo {nomeCampo} é obrigatório.");
        }

        public void AdicionarErroCampoInvalido(string mensagem)
        {
            AdicionarErro(CampoInvalido, mensagem);
        }

        public void AdicionarErro(string codigo, string mensagemErro)
        {
            Erros.Add(new ErroValidacao(codigo, mensagemErro));
        }

        public void Validar()
        {
            ExecutarValidacoes();
            if (!EstaValido)
            {
                throw new ErroValidacaoException(Erros);
            }
        }
    }
}
