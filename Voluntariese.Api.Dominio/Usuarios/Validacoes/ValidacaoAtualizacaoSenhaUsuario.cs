using Voluntariese.Api.Dominio.Usuarios.Especificacoes;
using Voluntariese.Api.Dominio.Validacoes;

namespace Voluntariese.Api.Dominio.Usuarios.Validacoes
{
    public sealed class ValidacaoAtualizacaoSenhaUsuario : Validacao<Usuario>
    {
        public ValidacaoAtualizacaoSenhaUsuario(string novaSenha)
        {
            AdicionarRegra(new UsuarioDeveEstarAtivoEspec(), "O usuário está inativo.", CodigosErro.UsuarioInativo);
            AdicionarRegra(new SenhaDeveSerDiferenteDaCadastradaParaUsuarioEspec(novaSenha), "A senha informada deve ser diferente da cadastrada atualmente.", CodigosErro.SenhaInvalida);
        }
    }
}
