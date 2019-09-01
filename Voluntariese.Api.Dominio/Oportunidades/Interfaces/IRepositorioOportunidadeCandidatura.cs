using System.Collections.Generic;

namespace Voluntariese.Api.Dominio.Oportunidades.Interfaces
{
    public interface IRepositorioOportunidadeCandidatura
    {
        void Inserir(Candidatura candidatura);
        void Aprovar(Candidatura candidatura);
        void Reprovar(Candidatura candidatura);
        IList<Candidatura> Consultar(long idOportunidade);
        Candidatura Obter(long id);
    }
}
