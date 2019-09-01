using Voluntariese.Api.Dominio.Validacoes.Especificacoes;

namespace Voluntariese.Api.Dominio.Usuarios.Especificacoes
{
    public class UsuarioDeveEstarCadastradoEspec : Especificacao<Usuario>
    {
        public override bool EstaAtendidaPor(Usuario usuario)
        {
            return usuario != null && usuario.Id != 0;
        }
    }
}
