using System;
using Voluntariese.Api.Aplicacao.Autenticacao.Requests;
using Voluntariese.Api.Aplicacao.Usuarios.Models;
using Voluntariese.Api.Dominio.Autenticacao;
using Voluntariese.Api.Dominio.Autenticacao.Interfaces;
using Voluntariese.Api.Dominio.Autenticacao.Validacoes;
using Voluntariese.Api.Dominio.Usuarios.Interfaces;
using Voluntariese.Api.Infraestrutura.Email;
using Voluntariesepi.Infraestrutura.Criptografia;

namespace Voluntariese.Api.Aplicacao.Autenticacao
{
    public class ServicoAutenticacao : IServicoAutenticacao
    {
        private readonly IRepositorioUsuario _repositorioUsuario;
        private readonly IRepositorioTokenRecuperacaoSenha _repositorioTokenRecuperacaoSenha;
        private readonly IRepositorioHistoricoLogin _repositorioHistoricoLogin;
        private readonly IServicoEmail _servicoEnvioEmail;

        public ServicoAutenticacao(
            IRepositorioUsuario repositorioUsuario, 
            IRepositorioTokenRecuperacaoSenha repositorioTokenRecuperacaoSenha,
            IRepositorioHistoricoLogin repositorioHistoricoLogin,
            IServicoEmail servicoEnvioEmail)
        {
            _repositorioUsuario = repositorioUsuario;
            _repositorioTokenRecuperacaoSenha = repositorioTokenRecuperacaoSenha;
            _repositorioHistoricoLogin = repositorioHistoricoLogin;
            _servicoEnvioEmail = servicoEnvioEmail;
        }

        public UsuarioModel Login(LoginRequest request)
        {
            request.Validar();

            var usuario = _repositorioUsuario.Obter(request.Email);
            var senhaCriptografada = CriptografiaSha512.GerarHash(request.Senha);

            new ValidacaoLogin(senhaCriptografada).Validar(usuario);

            return new UsuarioModel(usuario);
        }

        public UsuarioModel ObterUsuario(long idUsuario)
        {
            var usuario = _repositorioUsuario.Obter(idUsuario);
            return new UsuarioModel(usuario);
        }

        public void SolicitarRecuperacaoSenha(SolicitarRecuperacaoSenhaRequest request)
        {
            request.Validar();

            var usuario = _repositorioUsuario.Obter(request.Email);

            new ValidacaoUsuarioRecuperacaoSenha().Validar(usuario);
            var token = GerarTokenRecuperacaoSenhaUnico();

            var tokenRecuperacaoSenha = new TokenRecuperacaoSenha(usuario, token, 30);
            _repositorioTokenRecuperacaoSenha.Inserir(tokenRecuperacaoSenha);

            _servicoEnvioEmail.EnviarEmailSolicitacaoRecuperacaoSenha(tokenRecuperacaoSenha);
        }

        public void RecuperarSenha(string token, RecuperarSenhaRequest request)
        {
            request.Validar();

            var tokenRecuperacaoSenha = ValidarTokenRecuperacaoSenha(token);
            var novaSenha = CriptografiaSha512.GerarHash(request.Senha);
            
            tokenRecuperacaoSenha.RecuperarSenha(novaSenha);

            _repositorioUsuario.AtualizarSenha(tokenRecuperacaoSenha.Usuario);
            _repositorioTokenRecuperacaoSenha.Utilizar(tokenRecuperacaoSenha);
            _servicoEnvioEmail.EnviarEmailAtualizacaoSenha(tokenRecuperacaoSenha.Usuario);
        }

        public TokenRecuperacaoSenha ValidarTokenRecuperacaoSenha(string token)
        {
            var tokenRecuperacaoSenha = _repositorioTokenRecuperacaoSenha.Obter(token);
            new ValidacaoTokenRecuperacaoSenha().Validar(tokenRecuperacaoSenha);

            return tokenRecuperacaoSenha;
        }

        public void CriarHistoricoLogin(long idUsuario, string token, string enderecoIp)
        {
            var historicoLogin = new HistoricoLogin(idUsuario, token, enderecoIp);
            _repositorioHistoricoLogin.Inserir(historicoLogin);
        }

        private string GerarTokenRecuperacaoSenhaUnico()
        {
            string token;
            var random = new Random();
            do
            {
                token = random.Next(0, 9999).ToString("D4");
            } while (_repositorioTokenRecuperacaoSenha.TokenExiste(token));

            return token;
        }
    }
}
