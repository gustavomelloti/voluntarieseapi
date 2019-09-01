using Voluntariese.Api.Dominio.Validacoes.Especificacoes;

namespace Voluntariese.Api.Dominio.Usuarios.Especificacoes
{
    public class SenhaDeveSerDiferenteDaCadastradaParaUsuarioEspec : Especificacao<Usuario>
    {
        private readonly string _novaSenha;

        public SenhaDeveSerDiferenteDaCadastradaParaUsuarioEspec(string novaSenha)
        {
            _novaSenha = novaSenha;
        }

        public override bool EstaAtendidaPor(Usuario usuario)
        {
            return !usuario.ValidarSenha(_novaSenha);
        }
    }
}
