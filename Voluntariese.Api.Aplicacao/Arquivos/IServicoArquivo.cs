using Voluntariese.Api.Aplicacao.Arquivos.Models;
using Voluntariese.Api.Aplicacao.Arquivos.Requests;
using System.Threading.Tasks;

namespace Voluntariese.Api.Aplicacao.Arquivos
{
    public interface IServicoArquivo
    {
        Task<ArquivoModel> Upload(UploadArquivoRequest request);
        Task<DownloadArquivoModel> Download(long id);
    }
}
