using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Voluntariese.Api.Aplicacao.Doacoes;
using Voluntariese.Api.Aplicacao.Doacoes.Models;
using Voluntariese.Api.Aplicacao.Doacoes.Requests;

namespace Voluntariese.Api.WebApi.Controllers
{
    [Route("api/doacoes")]
    public class DoacoesController : ApiController
    {
        private readonly IServicoDoacao _servicoDoacao;

        public DoacoesController(IServicoDoacao servicoDoacao)
        {
            _servicoDoacao = servicoDoacao;
        }

        /// <summary>
        /// Endpoint para cadastrar doa��es.
        /// </summary>
        /// <param name="request"></param>
        /// <returns>A doa��o</returns>
        [HttpPost]
        [Authorize]
        public DoacaoModel Cadastrar([FromBody]CadastrarDoacaoRequest request) 
            => _servicoDoacao.Cadastrar(request, IdUsuarioAutenticado);

        /// <summary>
        /// Endpoint para consultar doa��es.
        /// </summary>
        /// <returns>as Doa��es</returns>
        [HttpGet]
        public IList<DoacaoModel> Consultar([FromQuery] long? idCausa) 
            => _servicoDoacao.Consultar(null, true, idCausa);

        /// <summary>
        /// Endpoint para consultar doa��es de uma institui��o.
        /// </summary>
        /// <returns>as Doa��es</returns>
        [HttpGet("instituicao")]
        [Authorize]
        public IList<DoacaoModel> ConsultarInsituicoes() => _servicoDoacao.Consultar(IdUsuarioAutenticado, null, null);

        /// <summary>
        /// Endpoint para atualizar doa��es.
        /// </summary>
        /// <returns>a doa��o</returns>
        [HttpPut("{id}")]
        [Authorize]
        public DoacaoModel Atualizar(long id, [FromBody] AtualizarDoacaoRequest request)
            => _servicoDoacao.Atualizar(id, request, IdUsuarioAutenticado);
    }
}