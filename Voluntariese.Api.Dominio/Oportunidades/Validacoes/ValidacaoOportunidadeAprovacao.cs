using Voluntariese.Api.Dominio.Oportunidades.Especificacoes;
using Voluntariese.Api.Dominio.Validacoes;

namespace Voluntariese.Api.Dominio.Oportunidades.Validacoes
{
    public sealed class ValidacaoOportunidadeAprovacao : Validacao<Oportunidade>
    {
        public ValidacaoOportunidadeAprovacao(Candidatura candidatura)
        {
            AdicionarRegra(new OportunidadeDeveEstarAtivaEspec(), "A oportunidade deve estar ativa.", CodigosErros.OportunidadeDeveEstarAtiva);
            AdicionarRegra(new OportunidadeDevePossuirQuantidadeVagasMaiorQueZeroEspec(), "A oportunidade deve ter a quantidade de vagas maior do que 0.", CodigosErros.OportunidadeDeveTerVagasPositivas);
            AdicionarRegra(new UsuarioDeveTerSeCandidatadoAnteriormenteEspec(candidatura), "Candido não está vinculado nessa oportunidade.", CodigosErros.VoluntarioNaoSeCandidatou);
        }
    }
}
