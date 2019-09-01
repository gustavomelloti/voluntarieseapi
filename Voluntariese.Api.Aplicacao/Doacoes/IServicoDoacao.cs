using System.Collections.Generic;
using Voluntariese.Api.Aplicacao.Doacoes.Models;
using Voluntariese.Api.Aplicacao.Doacoes.Requests;

namespace Voluntariese.Api.Aplicacao.Doacoes
{
    public interface IServicoDoacao
    {
        DoacaoModel Cadastrar(CadastrarDoacaoRequest descricao, long idUsuarioAutenticado);
        DoacaoModel Atualizar(long id, AtualizarDoacaoRequest request, long idUsuarioAutenticado);
        IList<DoacaoModel> Consultar(long? id, bool? ativa, long? idCausa);
    }
}
