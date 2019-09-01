using System;
using System.ComponentModel;
using System.Linq;

namespace Voluntariese.Api.Infraestrutura.Utilitarios.Helpers{
    public static class EnumHelper
    {
        public static string Description(this Enum enumValue)
        {
            DescriptionAttribute attribute = enumValue.GetType()
                .GetField(enumValue.ToString())
                .GetCustomAttributes(typeof(DescriptionAttribute), false)
                .SingleOrDefault() as DescriptionAttribute;
            return attribute == null ? enumValue.ToString() : attribute.Description;
        }
    }
}
