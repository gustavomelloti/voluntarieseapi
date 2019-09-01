using System.Collections.Generic;
using Voluntariese.Api.Dominio.Causas;

namespace Voluntariese.Api.Dominio.Usuarios.Interfaces
{
    public interface IRepositorioUsuarioCausa
    {
        void Inserir(Usuario usuario);
        void Atualizar(Usuario usuario);
        IList<Causa> Consultar(long idUsuario);
    }
}
