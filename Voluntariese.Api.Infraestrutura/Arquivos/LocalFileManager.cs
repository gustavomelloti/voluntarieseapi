using Microsoft.AspNetCore.Http;
using Voluntariese.Api.Dominio.Arquivos;
using Voluntariese.Api.Infraestrutura.Utilitarios;
using System.IO;
using System.Threading.Tasks;

namespace Voluntariese.Api.Infraestrutura.Arquivos
{
public class LocalFileManager : IFileManager
    {
        private readonly string _enderecoAbsolutoUpload;

        public LocalFileManager(string enderecoAbsolutoUpload)
        {
            _enderecoAbsolutoUpload = enderecoAbsolutoUpload;
        }

        public async Task<Arquivo> Upload(string enderecoRelativo, IFormFile arquivo)
        {
            return await UtilitarioUpload.SalvarArquivo(_enderecoAbsolutoUpload, enderecoRelativo, arquivo);
        }

        public async Task<byte[]> Download(string enderecoArquivo)
        {
            using (var fs = File.OpenRead(Path.Combine(_enderecoAbsolutoUpload, enderecoArquivo)))
            {
                var bytes = new byte[fs.Length];
                await fs.ReadAsync(bytes, 0, bytes.Length);
                return bytes;
            }
        }

        public async Task<Arquivo> Upload(string enderecoRelativo, Stream stream, string nomeArquivo, string tipoArquivo)
        {
            return await UtilitarioUpload.SalvarArquivo(_enderecoAbsolutoUpload, enderecoRelativo, stream, nomeArquivo, tipoArquivo);
        }
    }
}
