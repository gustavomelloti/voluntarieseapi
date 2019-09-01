namespace Voluntariese.Api.Dominio.Autenticacao.Interfaces
{
    public interface IRepositorioTokenRecuperacaoSenha
    {
        void Inserir(TokenRecuperacaoSenha tokenRecuperacaoSenha);
        void Utilizar(TokenRecuperacaoSenha tokenRecuperacaoSenha);
        TokenRecuperacaoSenha Obter(string token);
        bool TokenExiste(string token);
    }
}
