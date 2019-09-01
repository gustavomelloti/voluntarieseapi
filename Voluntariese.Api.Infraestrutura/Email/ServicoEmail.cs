using System;
using System.Threading.Tasks;
using Voluntariese.Api.Dominio.Autenticacao;
using Voluntariese.Api.Dominio.Oportunidades;
using Voluntariese.Api.Dominio.Usuarios;
using Voluntariesepi.Api.Infraestrutura.Email;
using Voluntariesepi.Api.Infraestrutura.Email.Envio;

namespace Voluntariese.Api.Infraestrutura.Email
{
    public class ServicoEmail : IServicoEmail
    {        
        private readonly IEmailSender _sender;
        private readonly string _emailContato;

        private static readonly Func<TokenRecuperacaoSenha, string> TemplateEmailSolicitacaoRecuperacaoSenha = (token) => $@"
            <p>O seu código de recuperação de senha é: <strong>{token.Token}</strong>.</p>
            <p>Se você não quer redefinir sua senha, simplesmente ignore esse e-mail. Dessa maneira, sua senha não mudará.</p>";

        private static readonly Func<Usuario, string> TemplateEmailAtualizacaoSenha = (u) => $@"
            <p>A sua senha foi atualizada com sucesso e você já pode utilizá-la para acessar sua conta em nosso site.</p>
            <p>Caso você não tenha realizado esta operação, entre em contato através do e-mail <strong>contato.voluntariese@gmail.com</strong>.</p>";

        private static readonly Func<string, string, string, string, string> TemplateEmailContato = 
            (nome, email, telefone, mensagem) => $@"
                <h2>Contato realizado através do site</h2>
                <p>Nome: {nome}</p>
                <p>E-mail: {email}</p>
                <p>Telefone: {telefone}</p>
                <p>Mensagem: {mensagem}</p>
                <p>Data do contato: {DateTime.Now}</p>";

        private static readonly Func<Candidatura, string> TemplateEmailCandidatura = (candidatura) => $@"
                <p>O Voluntário <strong>{candidatura.Voluntario.Nome} </strong> quer ajudar sua instituição! Acesse o site para visualizar o perfil do candidato e entrar em contato!</p>";

        private static readonly Func<Candidatura, string> TemplateEmailCandidaturaAprovada = (candidatura) => $@"
                <p>A Instituição <strong>{candidatura.Instituicao.Nome} </strong> deseja contar com sua colaboração! Acesse o site para visualizar o perfil da instituição e entrar em contato!</p>";

        private static readonly Func<Candidatura, string> TemplateEmailCandidaturaReprovada = (candidatura) => $@"
                <p>Infelizmente a instituição <strong>{candidatura.Instituicao.Nome} </strong> recusou sua candidatura. Acesse o site para visualizar a justificativa.</p>";
        
        public ServicoEmail(IEmailSender sender, string emailContato)
        {
            _sender = sender;
            _emailContato = emailContato;
        }

        public async Task EnviarEmailSolicitacaoRecuperacaoSenha(TokenRecuperacaoSenha tokenRecuperacaoSenha)
        {
            var email = new MensagemEmail()
                .ComDestinatario(tokenRecuperacaoSenha.Usuario.Email)
                .ComAssunto("Recuperação de senha")
                .ComCorpoMensagem(TemplateEmailSolicitacaoRecuperacaoSenha(tokenRecuperacaoSenha));
  
            await _sender.Enviar(email);
        }

        public async Task EnviarEmailAtualizacaoSenha(Usuario usuario)
        {
            var email = new MensagemEmail()
                .ComDestinatario(usuario.Email)
                .ComAssunto("Atualizacão de senha")
                .ComCorpoMensagem(TemplateEmailAtualizacaoSenha(usuario));

            await _sender.Enviar(email);
        }

        public async Task EnviarEmailContato(string nome, string email, string telefone, string mensagem)
        {
            var mensagemEmail = new MensagemEmail()
                .ComDestinatario(_emailContato)
                .ComAssunto("Contato - E-commerce")
                .ComCorpoMensagem(TemplateEmailContato(nome, email, telefone, mensagem));

            await _sender.Enviar(mensagemEmail);
        }

        public async Task EnviarEmailCandidatura(Candidatura candidatura)
        {
            var mensagemEmail = new MensagemEmail()
                .ComDestinatario(candidatura.Instituicao.Email)
                .ComAssunto($"Voluntarie-se: #{candidatura.IdOportunidade} Temos um voluntário para você!")
                .ComCorpoMensagem(TemplateEmailCandidatura(candidatura));

            await _sender.Enviar(mensagemEmail);
        }

        public async Task EnviarEmailCandidaturaAprovada(Candidatura candidatura)
        {
            var mensagemEmail = new MensagemEmail()
                .ComDestinatario(candidatura.Voluntario.Email)
                .ComAssunto("Voluntarie-se: Sua candidatura foi Aprovada!")
                .ComCorpoMensagem(TemplateEmailCandidaturaAprovada(candidatura));

            await _sender.Enviar(mensagemEmail);
        }

        public async Task EnviarEmailCandidaturaReprovada(Candidatura candidatura)
        {
            var mensagemEmail = new MensagemEmail()
                .ComDestinatario(candidatura.Voluntario.Email)
                .ComAssunto("Voluntarie-se: Sua candidatura foi reprovada")
                .ComCorpoMensagem(TemplateEmailCandidaturaReprovada(candidatura));

            await _sender.Enviar(mensagemEmail);
        }
    }
}
