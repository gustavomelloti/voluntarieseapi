using Voluntariese.Api.Dominio.Usuarios.Interfaces;
using Voluntariese.Api.Dominio.Validacoes.Especificacoes;

namespace Voluntariese.Api.Dominio.Usuarios.Especificacoes
{
    public class EmailNaoDeveEstarCadastradoParaOutroUsuarioEspec : Especificacao<Usuario>
    {
        private readonly IRepositorioUsuario _repositorioUsuario;

        public EmailNaoDeveEstarCadastradoParaOutroUsuarioEspec(IRepositorioUsuario repositorioUsuario)
        {
            _repositorioUsuario = repositorioUsuario;
        }

        public override bool EstaAtendidaPor(Usuario usuario)
        {
            return !_repositorioUsuario.EmailExiste(usuario.Email, usuario.Id);
        }
    }
}
