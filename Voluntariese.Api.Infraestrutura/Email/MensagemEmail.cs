using Voluntariese.Api.Dominio.Arquivos;
using Voluntariese.Api.Infraestrutura.Email;

namespace Voluntariesepi.Api.Infraestrutura.Email
{
    public class MensagemEmail
    {
        public string[] Destinatarios { get; set; }

        public string[] Copias { get; set; }

        public string[] CopiasOcultas { get; set; }

        public string CorpoMensagem { get; set; }

        public string Assunto { get; set; }

        public Arquivo Anexo { get; set; }
        

        public MensagemEmail ComDestinatarios(string[] destinatarios)
        {
            Destinatarios = destinatarios;
            return this;
        }

        public MensagemEmail ComDestinatario(string destinatario)
        {
            Destinatarios = new string[] { destinatario };
            return this;
        }

        public MensagemEmail ComCopias(string[] copias)
        {
            Copias = copias;
            return this;
        }

        public MensagemEmail ComCopiasOcultas(string[] copiasOcultas)
        {
            CopiasOcultas = copiasOcultas;
            return this;
        }
        
        public MensagemEmail ComCorpoMensagem(string corpoMensagem)
        {
            CorpoMensagem = corpoMensagem;
            return this;
        }

        public MensagemEmail ComAssunto(string assunto)
        {
            Assunto = assunto;
            return this;
        }

        public MensagemEmail ComAnexo(Arquivo anexo)
        {
            Anexo = anexo;
            return this;
        }

        public MensagemEmail ComTemplatePadrao(string titulo)
        {
            CorpoMensagem = TemplatePadrao.Template(titulo, CorpoMensagem);
            return this;
        }
    }
}
