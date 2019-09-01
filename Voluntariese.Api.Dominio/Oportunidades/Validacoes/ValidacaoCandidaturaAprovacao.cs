using Voluntariese.Api.Dominio.Oportunidades.Especificacoes;
using Voluntariese.Api.Dominio.Validacoes;

namespace Voluntariese.Api.Dominio.Oportunidades.Validacoes
{
    public sealed class ValidacaoCandidaturaAprovacao : Validacao<Candidatura>
    {
        public ValidacaoCandidaturaAprovacao()
        {
            AdicionarRegra(new CandidaturaDeveEstarCadastradaEspec(), "A candidatura não foi encontrada.", CodigosErros.CandidaturaNaoEncontrada);
            AdicionarRegra(new CandidaturaNaoDeveTerSidoAtualizadaEspec(), "A candidatura já foi aprovado/reprovada.", CodigosErros.CandidaturaJaAtualizada);
        }
    }
}
