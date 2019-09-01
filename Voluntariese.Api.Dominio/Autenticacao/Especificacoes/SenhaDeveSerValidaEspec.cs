using Voluntariese.Api.Dominio.Usuarios;
using Voluntariese.Api.Dominio.Validacoes.Especificacoes;

namespace Voluntariese.Api.Dominio.Autenticacao.Especificacoes
{
    public class SenhaDeveSerValidaEspec : Especificacao<Usuario>
    {
        private readonly string _senha;

        public SenhaDeveSerValidaEspec(string senha)
        {
            _senha = senha;
        }

        public override bool EstaAtendidaPor(Usuario usuario)
        {
            return usuario?.ValidarSenha(_senha) ?? false;
        }
    }
}
