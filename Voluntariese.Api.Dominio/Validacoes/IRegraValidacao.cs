namespace Voluntariese.Api.Dominio.Validacoes
{
    public interface IRegraValidacao<in TEntidade>
    {
        string CodigoErro { get; }
        bool Impeditiva { get; }
        string MensagemErro { get; }
        bool Validar(TEntidade entidade);
    }
}
