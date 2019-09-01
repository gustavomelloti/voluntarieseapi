namespace Voluntariese.Api.Dominio.Validacoes
{
    public interface IValidacao<in TEntidade>
    {
        void Validar(TEntidade entidade);
    }
}
