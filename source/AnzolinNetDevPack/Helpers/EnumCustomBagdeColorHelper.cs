using AnzolinNetDevPack.CustomAttributes;
using System;

namespace AnzolinNetDevPack.Helpers
{
    public static class EnumCustomBagdeColorHelper
    {
        public static string GetBackgroundColor(object aEnum)
        {
            if (((object)aEnum) == null) throw new ArgumentNullException("aEnum");

            var vEnumType = aEnum.GetType();

            if (!vEnumType.IsEnum)
                throw new Exception("Object is not an Enum");

            var colorAttribute = (CustomBadgeColorAttribute)Attribute.GetCustomAttribute(vEnumType, typeof(CustomBadgeColorAttribute));

            return colorAttribute.BackgroundColorHexCode;
        }

        public static string GetBackgroundColor(Type type)
        {
            var colorAttribute = (CustomBadgeColorAttribute)Attribute.GetCustomAttribute(type, typeof(CustomBadgeColorAttribute));

            return colorAttribute.BackgroundColorHexCode;
        }

        public static string GetBackgroundColor(Type type, int key)
        {
            if (!type.IsEnum)
                throw new Exception("Type must be an Enum type");

            var vEnumName = type.GetEnumName(key);
            var vMemberInfo = type.GetMember(vEnumName);
            var vAttributes = (CustomBadgeColorAttribute)vMemberInfo[0].GetCustomAttributes(typeof(CustomBadgeColorAttribute), false)[0];

            return vAttributes.BackgroundColorHexCode;
        }
    }
}
