using Voluntariese.Api.Dominio.Validacoes.Especificacoes;

namespace Voluntariese.Api.Dominio.Oportunidades.Especificacoes
{
    public class CandidaturaDeveEstarCadastradaEspec : Especificacao<Candidatura>
    {
        public override bool EstaAtendidaPor(Candidatura candidatura)
        {
            return candidatura != null && candidatura.Id > 0;
        }
    }
}
