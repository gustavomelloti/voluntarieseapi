using Voluntariese.Api.Dominio.Validacoes.Especificacoes;

namespace Voluntariese.Api.Dominio.Validacoes
{
    public class RegraValidacao<TEntidade> : IRegraValidacao<TEntidade>
    {
        private readonly Especificacao<TEntidade> _especificacao;

        public string MensagemErro { get; }
        public string CodigoErro { get; }
        public bool Impeditiva { get; }

        public RegraValidacao(Especificacao<TEntidade> especificacao, string mensagemErro)
        {
            _especificacao = especificacao;
            MensagemErro = mensagemErro;
        }

        public RegraValidacao(Especificacao<TEntidade> especificacao, string mensagemErro, bool impeditiva)
            : this(especificacao, mensagemErro)
        {
            Impeditiva = impeditiva;
        }

        public RegraValidacao(Especificacao<TEntidade> especificacao, string mensagemErro, string codigoErro)
            : this(especificacao, mensagemErro)
        {
            CodigoErro = codigoErro;
        }

        public RegraValidacao(Especificacao<TEntidade> especificacao, string mensagemErro, string codigoErro,
            bool impeditiva)
            : this(especificacao, mensagemErro, codigoErro)
        {
            Impeditiva = impeditiva;
        }

        public bool Validar(TEntidade entidade)
        {
            return _especificacao.EstaAtendidaPor(entidade);
        }
    }
}
