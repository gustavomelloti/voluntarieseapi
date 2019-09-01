using System;
using System.Linq;

namespace Voluntariesepi.Api.Infraestrutura.Utilitarios.Helpers
{
    public static class RandomHelper
    {
        private const string Chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        private static readonly Random Random = new Random();

        public static string GerarTexto(int tamanhoMinimo, int tamanhoMaximo)
        {
            int tamanho = Random.Next(tamanhoMinimo, tamanhoMaximo);
            return GerarTexto(tamanho);
        }

        public static string GerarTexto(int tamanho)
        {
            return new string(Enumerable.Repeat(Chars, tamanho)
                .Select(s => s[Random.Next(s.Length)]).ToArray());
        }
    }
}