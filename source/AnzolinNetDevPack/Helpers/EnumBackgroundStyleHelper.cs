using AnzolinNetDevPack.CustomAttributes;
using System;

namespace AnzolinNetDevPack.Helpers
{
    public static class EnumBackgroundStyleHelper
    {
        public static string GetBackgroundStyle(object aEnum)
        {
            if (((object)aEnum) == null) throw new ArgumentNullException("aEnum");

            var vEnumType = aEnum.GetType();

            if (!vEnumType.IsEnum)
                throw new Exception("Object is not an Enum");

            var badgeStyleAttribute = (BackgroundStyleAttribute)Attribute.GetCustomAttribute(vEnumType, typeof(BackgroundStyleAttribute));

            return badgeStyleAttribute.BackgroundColorClass;
        }

        public static string GetBackgroundStyle(Type type)
        {
            var badgeStyleAttribute = (BackgroundStyleAttribute)Attribute.GetCustomAttribute(type, typeof(BackgroundStyleAttribute));

            return badgeStyleAttribute.BackgroundColorClass;
        }

        public static string GetBackgroundStyle(Type type, int key)
        {
            if (!type.IsEnum)
                throw new Exception("Type must be an Enum type");

            var vEnumName = type.GetEnumName(key);
            var vMemberInfo = type.GetMember(vEnumName);
            var vAttributes = (BackgroundStyleAttribute)vMemberInfo[0].GetCustomAttributes(typeof(BackgroundStyleAttribute), false)[0];

            return vAttributes.BackgroundColorClass;
        }
    }
}
