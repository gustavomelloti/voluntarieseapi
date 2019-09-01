namespace Voluntariese.Api.Dominio.Validacoes.Especificacoes
{
    public class EspecificacaoNegacao<TEntidade> : Especificacao<TEntidade>
    {
        private readonly Especificacao<TEntidade> _espeficacao;

        public EspecificacaoNegacao(Especificacao<TEntidade> especificacao)
        {
            _espeficacao = especificacao;
        }

        public override bool EstaAtendidaPor(TEntidade entidade)
        {
            return !_espeficacao.EstaAtendidaPor(entidade);
        }
    }
}
