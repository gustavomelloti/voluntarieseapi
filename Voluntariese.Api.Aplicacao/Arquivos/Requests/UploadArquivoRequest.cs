using Microsoft.AspNetCore.Http;
using Voluntariese.Api.Aplicacao.Base;

namespace Voluntariese.Api.Aplicacao.Arquivos.Requests
{
    public class UploadArquivoRequest : BaseRequest
    {
        public string EnderecoDestino { get; set; }
        public IFormFile Arquivo { get; set; }

        protected override void ExecutarValidacoes()
        {
            if (string.IsNullOrEmpty(EnderecoDestino))
                AdicionarErroCampoObrigatorio(nameof(EnderecoDestino));

            if (Arquivo == null)
                AdicionarErroCampoObrigatorio(nameof(Arquivo));
        }
    }
}
