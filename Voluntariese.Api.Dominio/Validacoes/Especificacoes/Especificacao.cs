namespace Voluntariese.Api.Dominio.Validacoes.Especificacoes
{
    public abstract class Especificacao<TEntidade>
    {
        public abstract bool EstaAtendidaPor(TEntidade entidade);

        public Especificacao<TEntidade> Ou(Especificacao<TEntidade> especificacao)
        {
            return new EspecificacaoDisjuncao<TEntidade>(this, especificacao);
        }

        public Especificacao<TEntidade> E(Especificacao<TEntidade> especificacao)
        {
            return new EspecificacaoConjuncao<TEntidade>(this, especificacao);
        }

        public Especificacao<TEntidade> Negar()
        {
            return new EspecificacaoNegacao<TEntidade>(this);
        }

        public static Especificacao<TEntidade> operator !(Especificacao<TEntidade> especificacao)
        {
            return especificacao.Negar();
        }
    }
}
