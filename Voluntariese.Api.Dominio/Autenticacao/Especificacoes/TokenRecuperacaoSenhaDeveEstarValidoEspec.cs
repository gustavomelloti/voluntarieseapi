using Voluntariese.Api.Dominio.Validacoes.Especificacoes;

namespace Voluntariese.Api.Dominio.Autenticacao.Especificacoes
{
    public class TokenRecuperacaoSenhaDeveEstarValidoEspec : Especificacao<TokenRecuperacaoSenha>
    {
        
        public override bool EstaAtendidaPor(TokenRecuperacaoSenha token)
        {
            return token?.EstaValido() ?? false;
        }
    }
}
