using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Voluntariese.Api.Aplicacao.Usuarios;
using Voluntariese.Api.Aplicacao.Usuarios.Models;
using Voluntariese.Api.Aplicacao.Usuarios.Requests;
using Voluntariese.Api.WebApi.Controllers;

namespace Labsit.Api.WebApi.Controllers
{
    [Route("api/usuarios")]
    public class UsuariosController : ApiController
    {
        private readonly IServicoUsuario _servicoUsuario;

        public UsuariosController(IServicoUsuario servicoUsuario)
        {
            _servicoUsuario = servicoUsuario;
        }
        
        /// <summary>
        /// Endpoint de cadastro de novos usuários.
        /// </summary>
        /// <param name="request"></param>
        /// <returns>O usuário cadastrado</returns>
        [HttpPost]
        public UsuarioModel Cadastrar([FromBody]CadastrarUsuarioRequest request) => _servicoUsuario.Cadastrar(request);

        /// <summary>
        /// Endpoint de atualização dos dados do usuário autenticado.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPut]
        public UsuarioModel Atualizar([FromBody]AtualizarUsuarioRequest request) => 
            _servicoUsuario.Atualizar(request, IdUsuarioAutenticado);

        /// <summary>
        /// Endpoint de atualização de senha do usuário logado.
        /// </summary>
        /// <param name="request"></param>
        [Authorize]
        [HttpPut("senha")]
        public async Task AtualizarSenha([FromBody] AtualizarSenhaRequest request) => 
            await _servicoUsuario.AtualizarSenha(request, IdUsuarioAutenticado);

        /// <summary>
        /// Endpoint para buscar voluntários.
        /// </summary>
        /// <returns>os voluntários</returns>
        [HttpGet("voluntarios")]
        public IList<UsuarioModel> ConsultarVoluntarios([FromQuery] long? idCausa) 
            =>_servicoUsuario.ConsultarVoluntarios(idCausa);
    }
}
