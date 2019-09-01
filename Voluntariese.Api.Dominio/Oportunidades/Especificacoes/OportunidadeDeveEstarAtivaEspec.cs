using Voluntariese.Api.Dominio.Validacoes.Especificacoes;

namespace Voluntariese.Api.Dominio.Oportunidades.Especificacoes
{
    public class OportunidadeDeveEstarAtivaEspec : Especificacao<Oportunidade>
    {
        public override bool EstaAtendidaPor(Oportunidade oportunidade)
        {
            return oportunidade.EstaAtiva;
        }
    }
}
