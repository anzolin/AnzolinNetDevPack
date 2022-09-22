using AnzolinNetDevPack.CustomAttributes;
using System;

namespace AnzolinNetDevPack.Helpers
{
    public static class EnumBackgroundColorHelper
    {
        public static string GetBackgroundColor(object aEnum)
        {
            if (((object)aEnum) == null) throw new ArgumentNullException("aEnum");

            var vEnumType = aEnum.GetType();

            if (!vEnumType.IsEnum)
                throw new Exception("Object is not an Enum");

            var colorAttribute = (BackgroundColorAttribute)Attribute.GetCustomAttribute(vEnumType, typeof(BackgroundColorAttribute));

            return colorAttribute.BackgroundColorHexCode;
        }

        public static string GetBackgroundColor(Type type)
        {
            var colorAttribute = (BackgroundColorAttribute)Attribute.GetCustomAttribute(type, typeof(BackgroundColorAttribute));

            return colorAttribute.BackgroundColorHexCode;
        }

        public static string GetBackgroundColor(Type type, int key)
        {
            if (!type.IsEnum)
                throw new Exception("Type must be an Enum type");

            var vEnumName = type.GetEnumName(key);
            var vMemberInfo = type.GetMember(vEnumName);
            var vAttributes = (BackgroundColorAttribute)vMemberInfo[0].GetCustomAttributes(typeof(BackgroundColorAttribute), false)[0];

            return vAttributes.BackgroundColorHexCode;
        }
    }
}
