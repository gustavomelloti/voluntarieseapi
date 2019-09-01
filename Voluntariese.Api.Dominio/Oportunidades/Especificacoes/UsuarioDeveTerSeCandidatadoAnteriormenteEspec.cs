using Voluntariese.Api.Dominio.Validacoes.Especificacoes;

namespace Voluntariese.Api.Dominio.Oportunidades.Especificacoes
{
    public class UsuarioDeveTerSeCandidatadoAnteriormenteEspec : Especificacao<Oportunidade>
    {
        private readonly Candidatura _candidatura;

        public UsuarioDeveTerSeCandidatadoAnteriormenteEspec(Candidatura candidatura)
        {
            _candidatura = candidatura;
        }

        public override bool EstaAtendidaPor(Oportunidade oportunidade)
        {
            return oportunidade.CandidatoVinculado(_candidatura.Voluntario.Id);
        }
    }
}
