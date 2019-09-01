using System.Net.Mail;
using System.Threading.Tasks;

namespace Voluntariesepi.Api.Infraestrutura.Email.Envio
{
    public class SmtpSender : IEmailSender
    {
        private readonly SmtpClient _smtpClient;
        private readonly string _remetente;

        public SmtpSender(SmtpClient smtpClient, string remetente)
        {
            _smtpClient = smtpClient;
            _remetente = remetente;
        }

        public Task Enviar(MensagemEmail mensagem)
        {
            var email = new MailMessage();
            email.From = new MailAddress(_remetente);
            email.Body = mensagem.CorpoMensagem;
            email.Subject = mensagem.Assunto;
            email.IsBodyHtml = true;

            if (mensagem.Anexo != null)
                email.Attachments.Add(new Attachment(mensagem.Anexo.Endereco));

            if (mensagem.Destinatarios != null)
                foreach (var destinatario in mensagem.Destinatarios) email.To.Add(destinatario);

            if (mensagem.Copias != null)
                foreach (var copia in mensagem.Copias) email.CC.Add(copia);

            _smtpClient.Send(email);
            return Task.FromResult(0);
        }
    }
}
