namespace Voluntariese.Api.Dominio
{
    public interface IUnitOfWork
    {
        void IniciarTransacao();
        void ExecutarCommit();
        void ExecutarRollback();
    }
}
