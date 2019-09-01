using Voluntariese.Api.Dominio.Usuarios;
using System;

namespace Voluntariese.Api.Dominio.Autenticacao
{
    public class TokenRecuperacaoSenha
    {

        public long Id { get; internal set; }
        public Usuario Usuario { get; internal set; }
        public string Token { get; internal set; }
        public DateTime DataValidade { get; internal set; }
        public DateTime? DataUtilizacao { get; internal set; }
        
        internal TokenRecuperacaoSenha() { }

        public TokenRecuperacaoSenha(Usuario usuario, string token, int minutosValidade)
        {
            Usuario = usuario;
            DataValidade = DateTime.Now.AddMinutes(minutosValidade);
            Token = token;
        }

        public void RecuperarSenha(string senha)
        {
            DataUtilizacao = DateTime.Now;
            Usuario.AtualizarSenha(senha);
        }

        public bool EstaValido()
        {
            return DataValidade >= DateTime.Now && 
                !DataUtilizacao.HasValue &&
                Usuario.Ativo;
        }
    }
}
