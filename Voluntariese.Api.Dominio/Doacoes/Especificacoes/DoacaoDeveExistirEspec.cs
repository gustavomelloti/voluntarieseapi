using Voluntariese.Api.Dominio.Validacoes.Especificacoes;

namespace Voluntariese.Api.Dominio.Doacoes.Especificacoes
{
    public class DoacaoDeveExistirEspec : Especificacao<Doacao>
    {
        public override bool EstaAtendidaPor(Doacao doacao)
        {
            return doacao != null && doacao.Id > 0;
        }
    }
}
