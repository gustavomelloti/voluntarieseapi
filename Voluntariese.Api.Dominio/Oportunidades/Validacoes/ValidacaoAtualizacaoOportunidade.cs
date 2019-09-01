using Voluntariese.Api.Dominio.Oportunidades.Especificacoes;
using Voluntariese.Api.Dominio.Validacoes;

namespace Voluntariese.Api.Dominio.Oportunidades.Validacoes
{
    public sealed class ValidacaoAtualizacaoOportunidade : Validacao<Oportunidade>
    {
        public ValidacaoAtualizacaoOportunidade(long idUsuarioAutenticado)
        {
            AdicionarRegra(new OportunidadeDeveEstarVinculadaComInstituicaoEspec(idUsuarioAutenticado), "A oportunidade deve estar vínculada com sua instituição.", CodigosErros.OportunidadeDeveEstarVinculadaComInstituicao);
        }
    }
}
