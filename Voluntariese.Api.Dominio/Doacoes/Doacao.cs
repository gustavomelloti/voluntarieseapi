using System;
using Voluntariese.Api.Dominio.Usuarios;

namespace Voluntariese.Api.Dominio.Doacoes
{
    public class Doacao
    {
        public long Id { get; internal set; }
        public string Descricao { get; internal set; }
        public Usuario Instituicao { get; internal set; }
        public DateTime DataCadastro { get; internal set; }
        public DateTime DataAtualizacao { get; internal set; }
        public bool Ativa { get; internal set; }

        public Doacao(string descricao, long idInstituicao)
        {
            Descricao = descricao;
            Instituicao = new Usuario(idInstituicao);
            DataCadastro = DateTime.Now;
            Ativa = true;
        }

        public Doacao() { }

        public void DefinirId(long id)
        {
            Id = id;
        }

        public void DefinirInstituicao(Usuario instituicao)
        {
            Instituicao = instituicao;
        }

        public void Atualizar(string descricao, bool ativa)
        {
            Descricao = descricao;
            Ativa = ativa;
        }

        public bool InstituicaoVinculada(long idInstituicao)
        {
            return idInstituicao == Instituicao.Id;
        }
    }
}