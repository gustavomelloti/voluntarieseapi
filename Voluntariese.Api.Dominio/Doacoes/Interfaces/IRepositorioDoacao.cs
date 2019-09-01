using System.Collections.Generic;

namespace Voluntariese.Api.Dominio.Doacoes.Interfaces
{
    public interface IRepositorioDoacao
    {
        void Inserir(Doacao doacao);
        void Atualizar(Doacao doacao);
        IList<Doacao> Consultar(long? id, bool? ativa, long? idCausa);
        Doacao Obter(long id);
    }
}
