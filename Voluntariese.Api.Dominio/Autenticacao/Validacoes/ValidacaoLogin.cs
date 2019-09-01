using Voluntariese.Api.Dominio.Autenticacao.Especificacoes;
using Voluntariese.Api.Dominio.Usuarios;
using Voluntariese.Api.Dominio.Usuarios.Especificacoes;
using Voluntariese.Api.Dominio.Validacoes;

namespace Voluntariese.Api.Dominio.Autenticacao.Validacoes
{
    public sealed class ValidacaoLogin : Validacao<Usuario>
    {
        public ValidacaoLogin(string senha)
        {
            AdicionarRegra(new SenhaDeveSerValidaEspec(senha).E(new UsuarioDeveEstarAtivoEspec()), "As credenciais informadas são inválidas.", CodigosErro.LoginInvalido);
        }
    }
}
