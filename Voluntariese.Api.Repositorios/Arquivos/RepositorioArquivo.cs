using Dapper;
using Voluntariese.Api.Dominio.Arquivos;
using Voluntariese.Api.Dominio.Arquivos.Interfaces;
using System.Threading.Tasks;

namespace Voluntariese.Api.Repositorios.Arquivos
{
    public class RepositorioArquivo : IRepositorioArquivo
    {
        private readonly IGerenciadorConexao _gerenciadorConexao;

        private const string InsertArquivo = @"INSERT INTO Arquivo (Nome, Endereco, Tipo, Tamanho, DataCriacao) VALUES 
            (@Nome, @Endereco, @Tipo, @Tamanho, SYSDATETIME());

            SELECT SCOPE_IDENTITY();";

        private const string QueryObterArquivo = @"
            SELECT 
                a.Id, 
                a.Nome, 
                a.Endereco, 
                a.Tipo,
                a.Tamanho
            FROM 
                Arquivo a
            WHERE
                (@Id IS NULL OR a.Id = @Id) AND
                (@Endereco IS NULL OR a.Endereco = @Endereco)";

        public RepositorioArquivo(IGerenciadorConexao gerenciadorConexao)
        {
            _gerenciadorConexao = gerenciadorConexao;
        }

        public async Task<Arquivo> ObterAsync(long id)
        {
            var conexao = _gerenciadorConexao.ObterConexao();
            return await conexao.QueryFirstOrDefaultAsync<Arquivo>(QueryObterArquivo, new ParametroConsultaArquivo(id),
                _gerenciadorConexao.TransacaoAtiva);
        }

        public void Inserir(Arquivo arquivo)
        {
            var conexao = _gerenciadorConexao.ObterConexao();
            var id = conexao.QueryFirst<long>(InsertArquivo, arquivo, _gerenciadorConexao.TransacaoAtiva);
            arquivo.DefinirId(id);
        }

        public Arquivo Obter(long id)
        {
            var conexao = _gerenciadorConexao.ObterConexao();
            return conexao.QueryFirstOrDefault<Arquivo>(QueryObterArquivo, new ParametroConsultaArquivo(id), _gerenciadorConexao.TransacaoAtiva);
        }

        public Arquivo Obter(string endereco)
        {
            var conexao = _gerenciadorConexao.ObterConexao();
            return conexao.QueryFirstOrDefault<Arquivo>(QueryObterArquivo, new ParametroConsultaArquivo(endereco),
                _gerenciadorConexao.TransacaoAtiva);
        }

        private class ParametroConsultaArquivo
        {
            public long? Id { get; }
            public string Endereco { get; }

            public ParametroConsultaArquivo(long id)
            {
                Id = id;
            }

            public ParametroConsultaArquivo(string endereco)
            {
                Endereco = endereco;
            }
        }
    }
}
