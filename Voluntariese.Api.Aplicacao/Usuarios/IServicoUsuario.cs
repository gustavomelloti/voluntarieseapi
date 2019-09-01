using Voluntariese.Api.Aplicacao.Usuarios.Models;
using Voluntariese.Api.Aplicacao.Usuarios.Requests;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Voluntariese.Api.Aplicacao.Usuarios
{
    public interface IServicoUsuario
    {
        UsuarioModel Cadastrar(CadastrarUsuarioRequest request);
        UsuarioModel Atualizar(AtualizarUsuarioRequest request, long idUsuarioAutenticado);
        Task AtualizarSenha(AtualizarSenhaRequest request, long idUsuarioAutenticado);
        IList<UsuarioModel> ConsultarVoluntarios(long? idCausa);
    }
}
