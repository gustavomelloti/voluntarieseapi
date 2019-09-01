using Dapper;
using Voluntariese.Api.Dominio.Enderecos;
using Voluntariese.Api.Dominio.Enderecos.Interfaces;

namespace Voluntariese.Api.Repositorios.Enderecos
{
    public class RepositorioEndereco : IRepositorioEndereco
    {
        private readonly IGerenciadorConexao _gerenciadorConexao;

        private const string QueryInserirEndereco = @"
            INSERT INTO Endereco
            (
                Cep,
                Estado,
                Cidade,
                Bairro,
                Logradouro,
                Numero,
                Complemento
            )
            VALUES
            (
                @Cep,
                @Estado,
                @Cidade,
                @Bairro,
                @Logradouro,
                @Numero,
                @Complemento
            );
            SELECT SCOPE_IDENTITY();
        ";

        private const string QueryObterEndereco = @"
            SELECT
                Id,
                Cep,
                Estado,
                Cidade,
                Bairro,
                Logradouro,
                Numero,
                Complemento
            FROM 
                Endereco
            WHERE
                Id = @Id
        ";

        public RepositorioEndereco(IGerenciadorConexao gerenciadorConexao)
        {
            _gerenciadorConexao = gerenciadorConexao;
        }

        public void Inserir(Endereco endereco)
        {
            var conexao = _gerenciadorConexao.ObterConexao();
            var parametros = new
            {
                endereco.Cep,
                endereco.Estado,
                endereco.Cidade,
                endereco.Bairro,
                endereco.Logradouro,
                endereco.Numero,
                endereco.Complemento
            };
            var id = conexao.QueryFirst<long>(QueryInserirEndereco, parametros, _gerenciadorConexao.TransacaoAtiva);
            endereco.DefinirId(id);
        }

        public Endereco Obter(long id)
        {
            var conexao = _gerenciadorConexao.ObterConexao();
            return conexao.QueryFirstOrDefault<Endereco>(QueryObterEndereco, 
                new { Id = id }, 
                _gerenciadorConexao.TransacaoAtiva);
        }
    }
}
