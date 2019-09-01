using Voluntariese.Api.Aplicacao.Contatos.Models;
using Voluntariese.Api.Aplicacao.Contatos.Requests;
using Voluntariese.Api.Infraestrutura.Email;
using Voluntariese.Api.Repositorios.Contatos;
using System.Threading.Tasks;

namespace Voluntariese.Api.Aplicacao.Contatos
{
    public class ServicoContato : IServicoContato
    {
        private readonly IRepositorioContato _repositorioContato;
        private readonly IServicoEmail _servicoEmail;

        public ServicoContato(IRepositorioContato repositorioContato, IServicoEmail servicoEmail)
        {
            _repositorioContato = repositorioContato;
            _servicoEmail = servicoEmail;
        }

        public async Task<ContatoModel> Cadastrar(CadastrarContatoRequest request)
        {
            request.Validar();
            var contato = request.ParaDto();

            _repositorioContato.Inserir(contato);
            await _servicoEmail.EnviarEmailContato(contato.Nome, contato.Email, contato.Telefone, contato.Mensagem);

            return new ContatoModel(contato);
        }
    }
}
