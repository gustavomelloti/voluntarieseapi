using System;

namespace Voluntariese.Api.Infraestrutura.Email
{
    public class TemplatePadrao
    {
        public static readonly Func<string, string, string> Template = (nome, corpo) => $@"
            <!DOCTYPE html>
            <html lang='pt-br'>
              <head>
                <meta charset='utf-8'>
              </head>
              <body>
                
              </body>
            </html>";
    }
}