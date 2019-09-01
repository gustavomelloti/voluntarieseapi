using Voluntariese.Api.Dominio.Causas;

namespace Voluntariese.Api.Dominio.Oportunidades.Builders
{
    public class ParametroAtualizacaoOportunidadeBuilder
    {
        private readonly ParametroAtualizacaoOportunidade _parametroAtualizacaoOportunidade = new ParametroAtualizacaoOportunidade();

        public ParametroAtualizacaoOportunidadeBuilder ComDescricao(string descricao)
        {
            _parametroAtualizacaoOportunidade.Descricao = descricao;
            return this;
        }

        public ParametroAtualizacaoOportunidadeBuilder ComCausa(Causa causa)
        {
            _parametroAtualizacaoOportunidade.Causa = causa;
            return this;
        }

        public ParametroAtualizacaoOportunidadeBuilder ComTurno(string turno)
        {
            _parametroAtualizacaoOportunidade.Turno = turno;
            return this;
        }

        public ParametroAtualizacaoOportunidadeBuilder ComQuantidadeVagas(int quantidadeVagas)
        {
            _parametroAtualizacaoOportunidade.QuantidadeVagas = quantidadeVagas;
            return this;
        }

        public ParametroAtualizacaoOportunidadeBuilder ComAtiva(bool ativa)
        {
            _parametroAtualizacaoOportunidade.Ativa = ativa;
            return this;
        }

        public ParametroAtualizacaoOportunidadeBuilder ComQualificacoes(string qualificacoes)
        {
            _parametroAtualizacaoOportunidade.Qualificacoes = qualificacoes;
            return this;
        }
        

        public ParametroAtualizacaoOportunidade Construir()
        {
            if (string.IsNullOrEmpty(_parametroAtualizacaoOportunidade.Descricao))
                throw new EntidadeEmEstadoInvalidoException(nameof(_parametroAtualizacaoOportunidade.Descricao));

            if (_parametroAtualizacaoOportunidade.Causa == null)
                throw new EntidadeEmEstadoInvalidoException(nameof(_parametroAtualizacaoOportunidade.Causa));

            if (string.IsNullOrEmpty(_parametroAtualizacaoOportunidade.Turno))
                throw new EntidadeEmEstadoInvalidoException(nameof(_parametroAtualizacaoOportunidade.Turno));

            if (_parametroAtualizacaoOportunidade.QuantidadeVagas <= 0)
                throw new EntidadeEmEstadoInvalidoException(nameof(_parametroAtualizacaoOportunidade.QuantidadeVagas));

            return _parametroAtualizacaoOportunidade;
        }
    }
}
