using Dapper;
using Voluntariese.Api.Repositorios.Contatos.Dtos;

namespace Voluntariese.Api.Repositorios.Contatos
{
    public class RepositorioContato : IRepositorioContato
    {
        private readonly IGerenciadorConexao _gerenciadorConexao;

        private const string QueryInserirContato = @"
            INSERT INTO Contato
            (
                Nome,
                Email,
                Telefone,
                Mensagem,
                DataCriacao
            )
            VALUES
            (
                @Nome,
                @Email,
                @Telefone,
                @Mensagem,
                SYSDATETIME()
            );
            SELECT SCOPE_IDENTITY();
        ";

        public RepositorioContato(IGerenciadorConexao gerenciadorConexao)
        {
            _gerenciadorConexao = gerenciadorConexao;
        }

        public void Inserir(SalvarContatoDto dto)
        {
            var conexao = _gerenciadorConexao.ObterConexao();

            var parametros = new
            {
                dto.Nome,
                dto.Email,
                dto.Telefone,
                dto.Mensagem
            };

            dto.Id = conexao.ExecuteScalar<long>(QueryInserirContato, parametros, _gerenciadorConexao.TransacaoAtiva);
        }
    }
}
