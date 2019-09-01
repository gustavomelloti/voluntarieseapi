using System;
using System.Threading.Tasks;
using Voluntariese.Api.Aplicacao.Arquivos.Models;
using Voluntariese.Api.Aplicacao.Arquivos.Requests;
using Voluntariese.Api.Dominio.Arquivos;
using Voluntariese.Api.Dominio.Arquivos.Interfaces;
using Voluntariese.Api.Dominio.Arquivos.Validacoes;
using Voluntariese.Api.Infraestrutura.Arquivos;
using Voluntariese.Api.Infraestrutura.Cache;

namespace Voluntariese.Api.Aplicacao.Arquivos
{
    public class ServicoArquivo : IServicoArquivo
    {
        private readonly IRepositorioArquivo _repositorioArquivo;
        private readonly IFileManager _fileManager;

        private readonly IServicoCache _servicoCache;
        private static readonly TimeSpan TempoExpiracaoCache = TimeSpan.FromDays(7);
        private static readonly Func<long, string> ChaveCache = id => $"Arquivo_{id}";

        public ServicoArquivo(
            IRepositorioArquivo repositorioArquivo,
            IServicoCache servicoCache,
            IFileManager fileManager)
        {
            _repositorioArquivo = repositorioArquivo;
            _servicoCache = servicoCache;
            _fileManager = fileManager;
        }

        public async Task<ArquivoModel> Upload(UploadArquivoRequest request)
        {
            request.Validar();

            var arquivo =
                await _fileManager.Upload(request.EnderecoDestino, request.Arquivo);

            _repositorioArquivo.Inserir(arquivo);

            CriarCacheArquivo(arquivo);

            return new ArquivoModel(arquivo);
        }

        public async Task<DownloadArquivoModel> Download(long id)
        {
            var arquivo = await ObterArquivo(id);
            var conteudo = await _fileManager.Download(arquivo.Endereco);
            return new DownloadArquivoModel(arquivo, conteudo);
        }

        private async Task<Arquivo> ObterArquivo(long id)
        {
            if (_servicoCache.TentarObter(ChaveCache(id), out Arquivo arquivo))
                return arquivo;

            arquivo = await _repositorioArquivo.ObterAsync(id);
            new ValidacaoConsultaArquivo().Validar(arquivo);

            CriarCacheArquivo(arquivo);
            return arquivo;
        }

        private void CriarCacheArquivo(Arquivo arquivo)
        {
            _servicoCache.Criar(ChaveCache(arquivo.Id), arquivo, TempoExpiracaoCache);
        }
    }
}
