using Voluntariese.Api.Dominio.Validacoes.Especificacoes;

namespace Voluntariese.Api.Dominio.Oportunidades.Especificacoes
{
    public class CandidaturaNaoDeveTerSidoAtualizadaEspec : Especificacao<Candidatura>
    {
        public override bool EstaAtendidaPor(Candidatura candidatura)
        {
            return candidatura.Aprovada == null;
        }
    }
}
