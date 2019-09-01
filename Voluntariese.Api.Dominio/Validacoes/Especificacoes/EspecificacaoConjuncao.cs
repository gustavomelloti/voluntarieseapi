namespace Voluntariese.Api.Dominio.Validacoes.Especificacoes
{
    public class EspecificacaoConjuncao<TEntidade> : Especificacao<TEntidade>
    {
        private readonly Especificacao<TEntidade> _direita;
        private readonly Especificacao<TEntidade> _esquerda;

        public EspecificacaoConjuncao(Especificacao<TEntidade> esquerda, Especificacao<TEntidade> direita)
        {
            _esquerda = esquerda;
            _direita = direita;
        }

        public override bool EstaAtendidaPor(TEntidade entidade)
        {
            return _esquerda.EstaAtendidaPor(entidade)
                && _direita.EstaAtendidaPor(entidade);
        }
    }
}
