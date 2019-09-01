using System.Collections.Generic;
using System.Linq;
using Voluntariese.Api.Aplicacao.Causas.Models;
using Voluntariese.Api.Dominio.Causas.Interfaces;

namespace Voluntariese.Api.Aplicacao.Causas
{
    public class ServicoCausa : IServicoCausa
    {
        private readonly IRepositorioCausa _repositorioCausa;

        public ServicoCausa(IRepositorioCausa repositorioCausa)
        {
            _repositorioCausa = repositorioCausa;
        }

        public IEnumerable<CausaModel> Consultar()
        {
            var causas = _repositorioCausa.Consultar();
            return causas.Select(causa => new CausaModel(causa));
        }
    }
}
