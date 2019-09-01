using Microsoft.AspNetCore.Http;
using Voluntariese.Api.Dominio.Arquivos;
using System.IO;
using System.Threading.Tasks;

namespace Voluntariese.Api.Infraestrutura.Utilitarios
{
    public static class UtilitarioUpload
    {

        public static async Task<Arquivo> SalvarArquivo(string enderecoAbsolutoUpload, string enderecoRelativo, IFormFile arquivo)
        {
            var enderecoCompleto = Path.Combine(enderecoAbsolutoUpload, enderecoRelativo);

            CriarDiretorioDestino(enderecoCompleto);

            using (var stream = new FileStream(Path.Combine(enderecoCompleto, arquivo.FileName), FileMode.Create))
            {
                await arquivo.CopyToAsync(stream);
            }

            return new Arquivo(arquivo.FileName, Path.Combine(enderecoRelativo, arquivo.FileName), arquivo.ContentType, arquivo.Length);
        }

        public static async Task<Arquivo> SalvarArquivo(string enderecoAbsolutoUpload, string enderecoRelativo, Stream stream, string nomeArquivo, string tipoArquivo)
        {
            var enderecoCompleto = Path.Combine(enderecoAbsolutoUpload, enderecoRelativo);

            CriarDiretorioDestino(enderecoCompleto);

            using (var streamDestino = new FileStream(Path.Combine(enderecoCompleto, nomeArquivo), FileMode.Create))
            {
                await stream.CopyToAsync(streamDestino);
            }

            return new Arquivo(nomeArquivo, Path.Combine(enderecoRelativo, nomeArquivo), tipoArquivo, stream.Length);
        }

        private static void CriarDiretorioDestino(string enderecoCompleto)
        {
            if (!Directory.Exists(enderecoCompleto))
                Directory.CreateDirectory(enderecoCompleto);
        }
    }
}
