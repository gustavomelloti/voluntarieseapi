using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Voluntariese.Api.Aplicacao.Arquivos;
using Voluntariese.Api.Aplicacao.Arquivos.Models;
using Voluntariese.Api.Aplicacao.Arquivos.Requests;
using System.Threading.Tasks;

namespace Voluntariese.Api.WebApi.Controllers
{
    [Route("api/arquivos")]
    public class ArquivosController : ApiController
    {
        private readonly IServicoArquivo _servicoArquivo;

        public ArquivosController(IServicoArquivo servicoArquivo)
        {
            _servicoArquivo = servicoArquivo;
        }

        /// <summary>
        /// Endpoint de upload de arquivos.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ArquivoModel> Upload([FromForm]UploadArquivoRequest request) => await _servicoArquivo.Upload(request);

        /// <summary>
        /// Endpoint de download de arquivos.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>O Arquivo</returns>
        [HttpGet("{id}")]
        public async Task<FileResult> Download(long id)
        {
            var arquivoDownload = await _servicoArquivo.Download(id);
            return File(arquivoDownload.Conteudo, arquivoDownload.Tipo, arquivoDownload.Nome);
        }
    }
}
