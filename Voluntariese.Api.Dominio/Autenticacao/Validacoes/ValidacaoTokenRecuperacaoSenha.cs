using Voluntariese.Api.Dominio.Autenticacao.Especificacoes;
using Voluntariese.Api.Dominio.Validacoes;

namespace Voluntariese.Api.Dominio.Autenticacao.Validacoes
{
    public sealed class ValidacaoTokenRecuperacaoSenha : Validacao<TokenRecuperacaoSenha>
    {
        public ValidacaoTokenRecuperacaoSenha()
        {
            AdicionarRegra(new TokenRecuperacaoSenhaDeveEstarValidoEspec(), "O código informado é inválido.", CodigosErro.TokenRecuperacaoSenhaInvalido);
        }
    }
}
