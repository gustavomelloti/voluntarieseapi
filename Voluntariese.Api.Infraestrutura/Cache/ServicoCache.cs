using System;

using Microsoft.Extensions.Caching.Memory;

namespace Voluntariese.Api.Infraestrutura.Cache
{
    public class ServicoCache : IServicoCache
    {
        private readonly IMemoryCache _memoryCache;

        public ServicoCache(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public void Criar<TItem>(string chave, TItem item)
        {
            _memoryCache.Set(chave, item, ObterConfiguracaoPadrao());
        }

        public void Criar<TItem>(string chave, TItem item, TimeSpan tempoParaExpirar)
        {
            var config = ObterConfiguracaoPadrao();

            config.SetAbsoluteExpiration(tempoParaExpirar);

            _memoryCache.Set(chave, item, config);
        }

        public bool Existe(string chave)
        {
            return _memoryCache.TryGetValue(chave, out _);
        }

        public TItem Obter<TItem>(string chave)
        {
            return _memoryCache.Get<TItem>(chave);
        }

        public void Remover(string chave)
        {
            if (Existe(chave)) _memoryCache.Remove(chave);
        }

        public bool TentarObter<TItem>(string chave, out TItem item)
        {
            return _memoryCache.TryGetValue(chave, out item);
        }

        public bool TentarObter(string chave, out string item)
        {
            return _memoryCache.TryGetValue(chave, out item);
        }

        public void Dispose()
        {
            _memoryCache.Dispose();
        }

        private static MemoryCacheEntryOptions ObterConfiguracaoPadrao()
        {
            return new MemoryCacheEntryOptions()
            {
                Priority = CacheItemPriority.Normal
            };
        }
    }
}
