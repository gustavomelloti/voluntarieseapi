using Voluntariese.Api.Dominio.Usuarios;
using Voluntariese.Api.Dominio.Validacoes.Especificacoes;

namespace Voluntariese.Api.Dominio.Doacoes.Especificacoes
{
    public class DoacaoDeveEstarVinculadaComInstituicaoEspec : Especificacao<Doacao>
    {
        private readonly Usuario _instituicao;

        public DoacaoDeveEstarVinculadaComInstituicaoEspec(Usuario instituicao)
        {
            _instituicao = instituicao;
        }

        public override bool EstaAtendidaPor(Doacao doacao)
        {
            return doacao.InstituicaoVinculada(_instituicao.Id);
        }
    }
}
