using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Voluntariese.Api.Aplicacao.Causas;
using Voluntariese.Api.Aplicacao.Causas.Models;

namespace Voluntariese.Api.WebApi.Controllers
{
    [Route("api/causas")]
    public class CausasController : ApiController
    {
        private readonly IServicoCausa _servicoCausa;

        public CausasController(IServicoCausa servicoCausa)
        {
            _servicoCausa = servicoCausa;
        }

        /// <summary>
        /// Endpoint para consultar as causas atendidas.
        /// </summary>
        /// <returns>as causas</returns>
        [HttpGet]
        public IEnumerable<CausaModel> Consultar() => _servicoCausa.Consultar();
    }
}
