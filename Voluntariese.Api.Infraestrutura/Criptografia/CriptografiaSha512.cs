using System.Security.Cryptography;
using System.Text;

namespace Voluntariesepi.Infraestrutura.Criptografia
{
    public static class CriptografiaSha512
    {
        public static string GerarHash(string entrada)
        {
            using (var sha = new SHA512Managed())
            {
                var data = Encoding.UTF8.GetBytes(entrada);
                var bytesCriptografados = sha.ComputeHash(data);
                var stringBuilderRetorno = new StringBuilder(128);

                foreach (var b in bytesCriptografados)
                    stringBuilderRetorno.Append(b.ToString("X2"));

                return stringBuilderRetorno.ToString();
            }
        }
    }
}
