using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Voluntariese.Api.Aplicacao.Autenticacao;
using Voluntariese.Api.Aplicacao.Autenticacao.Models;
using Voluntariese.Api.Aplicacao.Autenticacao.Requests;
using Voluntariese.Api.Aplicacao.Usuarios.Models;

namespace Voluntariese.Api.WebApi.Controllers
{
    [Route("api/autenticacao")]
    public class AutenticacaoController : ApiController
    {
        private readonly IServicoAutenticacao _servicoAutenticacao;

        public AutenticacaoController(IServicoAutenticacao servicoAutenticacao)
        {
            _servicoAutenticacao = servicoAutenticacao;
        }

        /// <summary>
        /// Endpoint de login.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("token")]
        public TokenAutenticacaoModel Login([FromBody]LoginRequest request) => null;

        /// <summary>
        /// Endpoint de informações do usuário autenticado.
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet("info")]
        public UsuarioModel Info() => _servicoAutenticacao.ObterUsuario(IdUsuarioAutenticado);

        /// <summary>
        /// Endpoint de solicitação da recuperação de senha.
        /// </summary>
        /// <param name="request"></param>
        [HttpPost("esqueci-minha-senha")]
        public void SolicitarRecuperacaoSenha([FromBody] SolicitarRecuperacaoSenhaRequest request) => _servicoAutenticacao.SolicitarRecuperacaoSenha(request);

        /// <summary>
        /// Endpoint de validação do token de recuperação de senha.
        /// </summary>
        /// <param name="token"></param>
        [HttpPost("recuperacao-senha/{token}/validar")]
        public void ValidarTokenRecuperacaoSenha(string token) => _servicoAutenticacao.ValidarTokenRecuperacaoSenha(token);

        /// <summary>
        /// Endpoint de recuperação de senha.
        /// </summary>
        /// <param name="token"></param>
        /// <param name="request"></param>
        [HttpPost("recuperacao-senha/{token}")]
        public void RecuperarSenha(string token, [FromBody]RecuperarSenhaRequest request) => _servicoAutenticacao.RecuperarSenha(token, request);

    }
}
