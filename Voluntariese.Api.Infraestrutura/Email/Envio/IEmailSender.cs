using System.Threading.Tasks;

namespace Voluntariesepi.Api.Infraestrutura.Email.Envio
{
    public interface IEmailSender
    {
        Task Enviar(MensagemEmail mensagem);
    }
}
