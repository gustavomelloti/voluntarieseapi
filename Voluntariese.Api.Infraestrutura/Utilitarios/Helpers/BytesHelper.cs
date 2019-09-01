using System;
using System.Linq;
using System.Text;

namespace Voluntariesepi.Api.Infraestrutura.Utilitarios.Helpers
{
    public static class BytesHelper
    {
        public static byte[] DeString(string text)
        {
            return Encoding.UTF8.GetBytes(text);
        }

        public static byte[] DeBase64(string base64Text)
        {
            return Convert.FromBase64String(base64Text);
        }

        public static byte[] DeHexadecimal(string hex)
        {
            hex = hex.Replace("-", "");
            byte[] bytes = new byte[hex.Length / 2];

            for (int i = 0; i < bytes.Length; i++)
            {
                bytes[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
            }

            return bytes;
        }

        public static string ParaString(byte[] bytes)
        {
            return Encoding.UTF8.GetString(bytes);
        }

        public static string ParaBase64(byte[] bytes)
        {
            return Convert.ToBase64String(bytes);
        }

        public static string ParaHexadecimal(byte[] bytes)
        {
            var builder = new StringBuilder();
            foreach (var b in bytes)
            {
                builder.AppendFormat("{0:x2}", b);
            }
            return builder.ToString();
        }

        public static byte[] Combinar(params byte[][] arrays)
        {
            var result = new byte[arrays.Sum(a => a.Length)];

            var offset = 0;

            foreach (var array in arrays)
            {
                Buffer.BlockCopy(array, 0, result, offset, array.Length);
                offset += array.Length;
            }

            return result;
        }
    }
}