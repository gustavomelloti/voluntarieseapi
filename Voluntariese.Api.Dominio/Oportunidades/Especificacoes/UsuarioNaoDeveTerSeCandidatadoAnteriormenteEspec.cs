using Voluntariese.Api.Dominio.Usuarios;
using Voluntariese.Api.Dominio.Validacoes.Especificacoes;

namespace Voluntariese.Api.Dominio.Oportunidades.Especificacoes
{
    public class UsuarioNaoDeveTerSeCandidatadoAnteriormenteEspec : Especificacao<Usuario>
    {
        private readonly Oportunidade _oportunidade;

        public UsuarioNaoDeveTerSeCandidatadoAnteriormenteEspec(Oportunidade oportunidade)
        {
            _oportunidade = oportunidade;
        }

        public override bool EstaAtendidaPor(Usuario usuario)
        {
            return !_oportunidade.CandidatoVinculado(usuario.Id);
        }
    }
}
