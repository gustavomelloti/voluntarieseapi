using System.Threading.Tasks;

namespace Voluntariese.Api.Dominio.Arquivos.Interfaces
{
    public interface IRepositorioArquivo
    {
        Arquivo Obter(long id);
        Task<Arquivo> ObterAsync(long id);
        void Inserir(Arquivo arquivo);
        Arquivo Obter(string endereco);
    }
}
