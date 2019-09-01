using Voluntariese.Api.Dominio.Usuarios;
using Voluntariese.Api.Dominio.Usuarios.Especificacoes;
using Voluntariese.Api.Dominio.Usuarios.Validacoes;
using Voluntariese.Api.Dominio.Validacoes;

namespace Voluntariese.Api.Dominio.Doacoes.Validacoes
{
    public sealed class ValidacaoAtualizarDoacaoInstituicao : Validacao<Usuario>
    {
        public ValidacaoAtualizarDoacaoInstituicao()
        {
            AdicionarRegra(new UsuarioDeveEstarCadastradoEspec(), "O usuário não foi encontrado.", CodigosErro.UsuarioNaoEncontrado, true);
            AdicionarRegra(new UsuarioDeveEstarAtivoEspec(), "O usuário está inativo.", CodigosErro.UsuarioInativo);
        }
    }
}
