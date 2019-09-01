using Voluntariese.Api.Dominio.Validacoes.Especificacoes;

namespace Voluntariese.Api.Dominio.Oportunidades.Especificacoes
{
    public class OportunidadeDeveEstarVinculadaComInstituicaoEspec : Especificacao<Oportunidade>
    {
        private readonly long _idUsuarioAutenticado;

        public OportunidadeDeveEstarVinculadaComInstituicaoEspec(long idUsuarioAutenticado)
        {
            _idUsuarioAutenticado = idUsuarioAutenticado;
        }

        public override bool EstaAtendidaPor(Oportunidade oportunidade)
        {
            return oportunidade.InstituicaoVinculada(_idUsuarioAutenticado);
        }
    }
}
