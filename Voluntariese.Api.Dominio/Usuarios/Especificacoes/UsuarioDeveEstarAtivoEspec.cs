using Voluntariese.Api.Dominio.Validacoes.Especificacoes;

namespace Voluntariese.Api.Dominio.Usuarios.Especificacoes
{
    public class UsuarioDeveEstarAtivoEspec : Especificacao<Usuario>
    {
        public override bool EstaAtendidaPor(Usuario usuario)
        {
            return usuario?.Ativo ?? false;
        }
    }
}
