using AnzolinNetDevPack.CustomAttributes;
using System;

namespace AnzolinNetDevPack.Helpers
{
    public static class EnumBadgeStyleHelper
    {
        public static string GetBadge(object aEnum)
        {
            if (((object)aEnum) == null) throw new ArgumentNullException("aEnum");

            var vEnumType = aEnum.GetType();

            if (!vEnumType.IsEnum)
                throw new Exception("Object is not an Enum");

            var label = EnumHelper.GetText(vEnumType, aEnum.ToString());
            var badgeStyleAttribute = (BadgeStyleAttribute)Attribute.GetCustomAttribute(vEnumType, typeof(BadgeStyleAttribute));

            return $"<div class='badge badge-pill {badgeStyleAttribute.BackgroundColorClass}'>{label}</div>";
        }

        public static string GetBadge(Type type)
        {
            var label = EnumHelper.GetText(type);
            var badgeStyleAttribute = (BadgeStyleAttribute)Attribute.GetCustomAttribute(type, typeof(BadgeStyleAttribute));

            return $"<div class='badge badge-pill {badgeStyleAttribute.BackgroundColorClass}'>{label}</div>";
        }

        public static string GetBadge(Type type, int key)
        {
            if (!type.IsEnum)
                throw new Exception("Type must be an Enum type");

            var vEnumName = type.GetEnumName(key);
            var label = EnumHelper.GetText(type, vEnumName);
            var vMemberInfo = type.GetMember(vEnumName);
            var vAttributes = (BadgeStyleAttribute)vMemberInfo[0].GetCustomAttributes(typeof(BadgeStyleAttribute), false)[0];

            return $"<div class='badge badge-pill {vAttributes.BackgroundColorClass}'>{label}</div>";
        }

        public static string GetBadgeTextColorClass(Type type, int key)
        {
            if (!type.IsEnum)
                throw new Exception("Type must be an Enum type");

            var vEnumName = type.GetEnumName(key);
            var label = EnumHelper.GetText(type, vEnumName);
            var vMemberInfo = type.GetMember(vEnumName);
            var vAttributes = (BadgeStyleAttribute)vMemberInfo[0].GetCustomAttributes(typeof(BadgeStyleAttribute), false)[0];

            return vAttributes.TextColorClass;
        }

        public static string GetBadgeBackgroundColorClass(Type type, int key)
        {
            if (!type.IsEnum)
                throw new Exception("Type must be an Enum type");

            var vEnumName = type.GetEnumName(key);
            var label = EnumHelper.GetText(type, vEnumName);
            var vMemberInfo = type.GetMember(vEnumName);
            var vAttributes = (BadgeStyleAttribute)vMemberInfo[0].GetCustomAttributes(typeof(BadgeStyleAttribute), false)[0];

            return vAttributes.BackgroundColorClass;
        }
    }
}
