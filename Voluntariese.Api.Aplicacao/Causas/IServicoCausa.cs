using System.Collections.Generic;
using Voluntariese.Api.Aplicacao.Causas.Models;

namespace Voluntariese.Api.Aplicacao.Causas
{
    public interface IServicoCausa
    {
        IEnumerable<CausaModel> Consultar();
    }
}
