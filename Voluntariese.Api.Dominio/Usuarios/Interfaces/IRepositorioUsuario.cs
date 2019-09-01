using System.Collections.Generic;

namespace Voluntariese.Api.Dominio.Usuarios.Interfaces
{
    public interface IRepositorioUsuario
    {
        IList<Usuario> ConsultarVoluntarios(long? idCausa);
        Usuario Obter(string email);
        Usuario Obter(long id);
        PerfilUsuario ObterPerfil(string codigo);
        void Inserir(Usuario usuario);
        void Atualizar(Usuario usuario);
        void AtualizarSenha(Usuario usuario);
        bool EmailExiste(string email, long id = 0);
    }
}
