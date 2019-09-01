using Voluntariese.Api.Aplicacao.Contatos.Models;
using Voluntariese.Api.Aplicacao.Contatos.Requests;
using System.Threading.Tasks;

namespace Voluntariese.Api.Aplicacao.Contatos
{
    public interface IServicoContato
    {
        Task<ContatoModel> Cadastrar(CadastrarContatoRequest request);
    }
}
