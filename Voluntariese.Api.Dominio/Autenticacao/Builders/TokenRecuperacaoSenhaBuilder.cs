using System;
using Voluntariese.Api.Dominio.Usuarios;

namespace Voluntariese.Api.Dominio.Autenticacao.Builders
{
    public class TokenRecuperacaoSenhaBuilder
    {
        private readonly TokenRecuperacaoSenha _tokenRecuperacaoSenha = new TokenRecuperacaoSenha();
        
        public TokenRecuperacaoSenhaBuilder APartir(TokenRecuperacaoSenha tokenRecuperacaoSenha)
        {
            _tokenRecuperacaoSenha.Id = tokenRecuperacaoSenha.Id;
            _tokenRecuperacaoSenha.Token = tokenRecuperacaoSenha.Token;
            _tokenRecuperacaoSenha.DataValidade = tokenRecuperacaoSenha.DataValidade;
            _tokenRecuperacaoSenha.DataUtilizacao = tokenRecuperacaoSenha.DataUtilizacao;
            _tokenRecuperacaoSenha.Usuario = tokenRecuperacaoSenha.Usuario;

            return this;
        }

        public TokenRecuperacaoSenhaBuilder ComUsuario(Usuario usuario)
        {
            _tokenRecuperacaoSenha.Usuario = usuario;
            return this;
        }
        
        public TokenRecuperacaoSenha Construir()
        {
            if (string.IsNullOrEmpty(_tokenRecuperacaoSenha.Token))
                throw new EntidadeEmEstadoInvalidoException(nameof(_tokenRecuperacaoSenha.Token));

            if (_tokenRecuperacaoSenha.Usuario == null)
                throw new EntidadeEmEstadoInvalidoException(nameof(_tokenRecuperacaoSenha.Usuario));

            if (_tokenRecuperacaoSenha.DataValidade == default(DateTime))
                throw new EntidadeEmEstadoInvalidoException(nameof(_tokenRecuperacaoSenha.DataValidade));

            return _tokenRecuperacaoSenha;
        }
    }
}
