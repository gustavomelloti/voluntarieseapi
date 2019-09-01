using Voluntariese.Api.Repositorios.Contatos.Dtos;

namespace Voluntariese.Api.Repositorios.Contatos
{
    public interface IRepositorioContato
    {
        void Inserir(SalvarContatoDto dto);
    }
}
