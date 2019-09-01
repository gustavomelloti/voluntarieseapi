using Voluntariese.Api.Dominio.Validacoes.Especificacoes;
using System.Collections.Generic;
using System.Linq;

namespace Voluntariese.Api.Dominio.Validacoes
{
    public class Validacao<TEntidade> : IValidacao<TEntidade>
    {
        private readonly List<IRegraValidacao<TEntidade>> _regrasValidacao;

        public Validacao()
        {
            _regrasValidacao = new List<IRegraValidacao<TEntidade>>();
        }

        protected virtual void AdicionarRegra(IRegraValidacao<TEntidade> regraValidacao)
        {
            _regrasValidacao.Add(regraValidacao);
        }

        protected virtual void AdicionarRegra(Especificacao<TEntidade> especificacao, string mensagemErro, string codigoErro, bool impeditiva)
        {
            _regrasValidacao.Add(new RegraValidacao<TEntidade>(especificacao, mensagemErro, codigoErro, impeditiva));
        }

        protected virtual void AdicionarRegra(Especificacao<TEntidade> especificacao, string mensagemErro, string codigoErro)
        {
            AdicionarRegra(especificacao, mensagemErro, codigoErro, false);
        }

        public void Validar(TEntidade entidade)
        {
            foreach (var regra in _regrasValidacao.Where(r => r.Impeditiva))
            {
                if (regra.Validar(entidade)) continue;
                var erroValidacao = new ErroValidacao(regra.CodigoErro, regra.MensagemErro);
                DispararExcecaoValidacao(new List<ErroValidacao>() { erroValidacao });
            }

            var erros = _regrasValidacao.Where(r => !r.Impeditiva && !r.Validar(entidade))
                .Select(r => new ErroValidacao(r.CodigoErro, r.MensagemErro))
                .ToList();

            if (erros.Any())
                DispararExcecaoValidacao(erros);
        }

        protected virtual void DispararExcecaoValidacao(List<ErroValidacao> erros = null)
        {
            throw new ErroValidacaoException(erros);
        }
    }
}
