namespace Voluntariese.Api.Dominio.Validacoes.Especificacoes
{
    public class EspecificacaoVerdadeira<TEntidade> : Especificacao<TEntidade>
    {
        public override bool EstaAtendidaPor(TEntidade entidade)
        {
            return true;
        }
    }
}
