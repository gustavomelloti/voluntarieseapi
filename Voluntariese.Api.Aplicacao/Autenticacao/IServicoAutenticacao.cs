using Voluntariese.Api.Aplicacao.Autenticacao.Requests;
using Voluntariese.Api.Aplicacao.Usuarios.Models;
using Voluntariese.Api.Dominio.Autenticacao;

namespace Voluntariese.Api.Aplicacao.Autenticacao
{
    public interface IServicoAutenticacao
    {
        UsuarioModel Login(LoginRequest request);
        UsuarioModel ObterUsuario(long idUsuario);
        void SolicitarRecuperacaoSenha(SolicitarRecuperacaoSenhaRequest request);
        TokenRecuperacaoSenha ValidarTokenRecuperacaoSenha(string token);
        void RecuperarSenha(string token, RecuperarSenhaRequest request);
        void CriarHistoricoLogin(long idUsuario, string token, string enderecoIp);
    }
}
