using Voluntariese.Api.Dominio.Autenticacao;

namespace Voluntariese.Api.Dominio.Autenticacao.Interfaces
{
    public interface IRepositorioHistoricoLogin
    {
        void Inserir(HistoricoLogin historicoLogin);
    }
}
