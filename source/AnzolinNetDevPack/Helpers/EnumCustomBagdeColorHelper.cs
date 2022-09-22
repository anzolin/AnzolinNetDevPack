using AnzolinNetDevPack.CustomAttributes;
using System;

namespace AnzolinNetDevPack.Helpers
{
    public static class EnumCustomBagdeColorHelper
    {
        public static string GetBadge(object aEnum)
        {
            if (((object)aEnum) == null) throw new ArgumentNullException("aEnum");

            var vEnumType = aEnum.GetType();

            if (!vEnumType.IsEnum)
                throw new Exception("Object is not an Enum");

            var label = EnumHelper.GetText(vEnumType, aEnum.ToString());
            var colors = (CustomBadgeColorAttribute)Attribute.GetCustomAttribute(vEnumType, typeof(CustomBadgeColorAttribute));

            return $"<div class='badge' style='color: {colors.TextColorHexCode}; background-color: {colors.BackgroundColorHexCode}'>{label}</div>";
        }

        public static string GetBadge(Type type)
        {
            var label = EnumHelper.GetText(type);
            var colors = (CustomBadgeColorAttribute)Attribute.GetCustomAttribute(type, typeof(CustomBadgeColorAttribute));

            return $"<div class='badge' style='color: {colors.TextColorHexCode}; background-color: {colors.BackgroundColorHexCode}'>{label}</div>";
        }

        public static string GetBadge(Type type, int key)
        {
            if (!type.IsEnum)
                throw new Exception("Type must be an Enum type");

            var vEnumName = type.GetEnumName(key);
            var label = EnumHelper.GetText(type, vEnumName);
            var vMemberInfo = type.GetMember(vEnumName);
            var vAttributes = (CustomBadgeColorAttribute)vMemberInfo[0].GetCustomAttributes(typeof(CustomBadgeColorAttribute), false)[0];

            return $"<div class='badge' style='color: {vAttributes.TextColorHexCode}; background-color: {vAttributes.BackgroundColorHexCode}'>{label}</div>";
        }

        public static string GetBadgeTextColorClass(Type type, int key)
        {
            if (!type.IsEnum)
                throw new Exception("Type must be an Enum type");

            var vEnumName = type.GetEnumName(key);
            var label = EnumHelper.GetText(type, vEnumName);
            var vMemberInfo = type.GetMember(vEnumName);
            var vAttributes = (CustomBadgeColorAttribute)vMemberInfo[0].GetCustomAttributes(typeof(CustomBadgeColorAttribute), false)[0];

            return vAttributes.TextColorHexCode;
        }

        public static string GetBadgeBackgroundColorClass(Type type, int key)
        {
            if (!type.IsEnum)
                throw new Exception("Type must be an Enum type");

            var vEnumName = type.GetEnumName(key);
            var label = EnumHelper.GetText(type, vEnumName);
            var vMemberInfo = type.GetMember(vEnumName);
            var vAttributes = (CustomBadgeColorAttribute)vMemberInfo[0].GetCustomAttributes(typeof(CustomBadgeColorAttribute), false)[0];

            return vAttributes.BackgroundColorHexCode;
        }
    }
}
