using Voluntariese.Api.Dominio.Usuarios.Especificacoes;
using Voluntariese.Api.Dominio.Validacoes;

namespace Voluntariese.Api.Dominio.Usuarios.Validacoes
{
    public sealed class ValidacaoConsultaUsuario : Validacao<Usuario>
    {
        public ValidacaoConsultaUsuario()
        {
            AdicionarRegra(new UsuarioDeveEstarCadastradoEspec(), "O usuário não foi encontrado.", CodigosErro.UsuarioNaoEncontrado);
        }
    }
}
