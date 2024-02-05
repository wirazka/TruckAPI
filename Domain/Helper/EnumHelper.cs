using System.ComponentModel.DataAnnotations;

namespace Domain.Helper
{
    public static class EnumHelper
    {
        public static string GetEnumDisplayName(this Enum value)
        {
            var type = value.GetType();
            var name = Enum.GetName(type, value);

            if (name == null) return "";
            var field = type.GetField(name);

            if (field == null) return "";
            var atr = Attribute.GetCustomAttribute(field, typeof(DisplayAttribute)) as DisplayAttribute;

            return atr != null ? atr.Name : "";
        }
    }
}
