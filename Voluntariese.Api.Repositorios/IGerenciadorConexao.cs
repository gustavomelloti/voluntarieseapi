using System.Data;

namespace Voluntariese.Api.Repositorios
{
    public interface IGerenciadorConexao
    {
        IDbTransaction TransacaoAtiva { get; }
        IDbConnection ObterConexao();
    }
}
