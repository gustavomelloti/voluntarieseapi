using System.Threading.Tasks;
using Voluntariese.Api.Dominio.Autenticacao;
using Voluntariese.Api.Dominio.Oportunidades;
using Voluntariese.Api.Dominio.Usuarios;

namespace Voluntariese.Api.Infraestrutura.Email
{
    public interface IServicoEmail
    {
        Task EnviarEmailSolicitacaoRecuperacaoSenha(TokenRecuperacaoSenha tokenRecuperacaoSenha);
        Task EnviarEmailAtualizacaoSenha(Usuario usuario);
        Task EnviarEmailContato(string nome, string email, string telefone, string mensagem);
        Task EnviarEmailCandidatura(Candidatura candidatura);
        Task EnviarEmailCandidaturaAprovada(Candidatura candidatura);
        Task EnviarEmailCandidaturaReprovada(Candidatura candidatura);
    }
}
