using System;

namespace Voluntariese.Api.Infraestrutura.Cache
{
    public interface IServicoCache : IDisposable
    {
        void Remover(string chave);

        void Criar<TItem>(string chave, TItem item);

        void Criar<TItem>(string chave, TItem item, TimeSpan tempoParaExpirar);

        T Obter<T>(string chave);

        bool Existe(string chave);

        bool TentarObter<TItem>(string chave, out TItem item);

        bool TentarObter(string chave, out string item);
    }
}
