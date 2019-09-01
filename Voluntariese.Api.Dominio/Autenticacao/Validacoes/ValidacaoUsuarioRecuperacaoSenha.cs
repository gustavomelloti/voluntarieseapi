using Voluntariese.Api.Dominio.Usuarios;
using Voluntariese.Api.Dominio.Usuarios.Especificacoes;
using Voluntariese.Api.Dominio.Validacoes;
using CodigosErroUsuario = Voluntariese.Api.Dominio.Usuarios.Validacoes;

namespace Voluntariese.Api.Dominio.Autenticacao.Validacoes
{
    public sealed class ValidacaoUsuarioRecuperacaoSenha : Validacao<Usuario>
    {
        public ValidacaoUsuarioRecuperacaoSenha()
        {
            AdicionarRegra(new UsuarioDeveEstarAtivoEspec(), "Não foi encontrado um usuário para o e-mail informado.", CodigosErroUsuario.CodigosErro.UsuarioNaoEncontrado);
        }
    }
}
