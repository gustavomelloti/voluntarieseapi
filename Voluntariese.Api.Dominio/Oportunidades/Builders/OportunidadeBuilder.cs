using System.Collections;
using System.Collections.Generic;
using Voluntariese.Api.Dominio.Causas;
using Voluntariese.Api.Dominio.Enderecos;
using Voluntariese.Api.Dominio.Usuarios;

namespace Voluntariese.Api.Dominio.Oportunidades.Builders
{
    public class OportunidadeBuilder
    {
        private readonly Oportunidade _oportunidade = new Oportunidade();
        
        public OportunidadeBuilder APartir(Oportunidade oportunidade)
        {
            _oportunidade.Descricao = oportunidade.Descricao;
            _oportunidade.Qualificacoes = oportunidade.Qualificacoes;
            _oportunidade.Ativa = oportunidade.Ativa;
            _oportunidade.Causa = oportunidade.Causa;
            _oportunidade.Id = oportunidade.Id;
            _oportunidade.QuantidadeVagas = oportunidade.QuantidadeVagas;
            _oportunidade.DataAtualizacao = oportunidade.DataAtualizacao;
            _oportunidade.DataCriacao = oportunidade.DataCriacao;
            _oportunidade.Turno = oportunidade.Turno;
            return this;
        }
        
        public OportunidadeBuilder ComInstituicaoEndereco(Endereco endereco)
        {
            if (_oportunidade.Instituicao != null)
                _oportunidade.Instituicao.DefinirEndereco(endereco);
 
            return this;
        }

        public OportunidadeBuilder ComDescricao(string descricao)
        {
            _oportunidade.Descricao = descricao;
            return this;
        }

        public OportunidadeBuilder ComCausa(Causa causa)
        {
            _oportunidade.Causa = causa;
            return this;
        }

        public OportunidadeBuilder ComTurno(string turno)
        {
            _oportunidade.Turno = turno;
            return this;
        }

        public OportunidadeBuilder ComQuantidadeVagas(int quantidadeVagas)
        {
            _oportunidade.QuantidadeVagas = quantidadeVagas;
            return this;
        }

        public OportunidadeBuilder ComId(long id)
        {
            _oportunidade.Id = id;
            return this;
        }

        public OportunidadeBuilder ComQualificacoes(string qualificacacoes)
        {
            _oportunidade.Qualificacoes = qualificacacoes;
            return this;
        }

        public OportunidadeBuilder ComInstituicao(Usuario instituicao)
        {
            _oportunidade.Instituicao = instituicao;
            return this;
        }

        public OportunidadeBuilder ComCandidatos(IList<Candidatura> candidatos)
        {
            _oportunidade.Candidatos = candidatos;
            return this;
        }

        public Oportunidade Construir()
        {
            if (string.IsNullOrEmpty(_oportunidade.Descricao))
                throw new EntidadeEmEstadoInvalidoException(nameof(_oportunidade.Descricao));

            if (_oportunidade.Causa == null)
                throw new EntidadeEmEstadoInvalidoException(nameof(_oportunidade.Causa));

            if (string.IsNullOrEmpty(_oportunidade.Turno))
                throw new EntidadeEmEstadoInvalidoException(nameof(_oportunidade.Turno));

            if (_oportunidade.QuantidadeVagas <= 0)
                throw new EntidadeEmEstadoInvalidoException(nameof(_oportunidade.QuantidadeVagas));

            return _oportunidade;
        }
    }
}
