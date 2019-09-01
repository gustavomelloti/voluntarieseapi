using System.Collections.Generic;

namespace Voluntariese.Api.Dominio.Oportunidades.Interfaces
{
    public interface IRepositorioOportunidade
    {
        Oportunidade Obter(long id);
        void Inserir(Oportunidade oportunidade);
        IEnumerable<Oportunidade> Consultar(long? idCausa);
        IEnumerable<Oportunidade> ConsultarDeInstituicoes(long idUsuario);
        IEnumerable<Oportunidade> ConsultarDeVoluntarios(long idUsuario);
        void Atualizar(Oportunidade oportunidade);
    }
}