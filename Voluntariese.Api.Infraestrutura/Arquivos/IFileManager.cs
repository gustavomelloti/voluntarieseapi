using Microsoft.AspNetCore.Http;
using Voluntariese.Api.Dominio.Arquivos;
using System.IO;
using System.Threading.Tasks;

namespace Voluntariese.Api.Infraestrutura.Arquivos
{
    public interface IFileManager
    {
        Task<Arquivo> Upload(string enderecoRelativo, IFormFile arquivo);
        Task<byte[]> Download(string enderecoArquivo);
        Task<Arquivo> Upload(string enderecoRelativo, Stream stream, string nomeArquivo, string tipoArquivo);
    }
}
