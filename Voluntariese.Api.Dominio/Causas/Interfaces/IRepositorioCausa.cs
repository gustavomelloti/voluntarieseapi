using System.Collections.Generic;

namespace Voluntariese.Api.Dominio.Causas.Interfaces
{
    public interface IRepositorioCausa
    {
        IEnumerable<Causa> Consultar();
    }
}
