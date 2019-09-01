namespace Voluntariese.Api.Dominio.Enderecos.Interfaces
{
    public interface IRepositorioEndereco
    {
        void Inserir(Endereco endereco);
        Endereco Obter(long id);
    }
}
