namespace Voluntariesepi.Api.Infraestrutura.Utilitarios.Const
{
    public static class ExpressaoRegular
    {
        public const string CpfValido = @"^(\d{3}\.\d{3}\.\d{3}\-\d{2})|(\d{11})$";
        public const string CnpjValido = @"^(\d{2}\.\d{3}\.\d{3}/\d{4}\-\d{2})|(\d{14})$";
        public const string DigitosIguais = @"^(\d)\1+$";
        public const string SenhaValida = @"^(?=.*[A-Za-z])(?=.*\d)(?=.*[\\+$@$!%*#?&;=,\\._-])[A-Za-z\d\\+$@$!%*#?&;=,\\._-]{6,}$";
    }
}