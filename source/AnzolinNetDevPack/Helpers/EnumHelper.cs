using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AnzolinNetDevPack.Helpers
{
    public static class EnumHelper
    {
        /// <summary>
        /// Retorna o valor inteiro do objeto enum informado.
        /// </summary>
        /// <param name="aEnum"></param>
        /// <returns></returns>
        public static int GetValue(object aEnum)
        {
            return (int)aEnum;
        }

        /// <summary>
        /// Retorna o valor texto do objeto enum informado.
        /// </summary>
        /// <param name="aEnum"></param>
        /// <returns></returns>
        public static string GetText(object aEnum)
        {
            if ((object)aEnum == null) throw new ArgumentNullException("aEnum");

            var vEnumType = aEnum.GetType();

            if (!vEnumType.IsEnum)
                throw new Exception("Object is not an Enum");

            return GetText(vEnumType, aEnum.ToString());
        }

        /// <summary>
        /// Retorna o valor texto do objeto enum informado.
        /// </summary>
        /// <param name="aEnumType"></param>
        /// <param name="aKey"></param>
        /// <returns></returns>
        public static string GetText(Type aEnumType, int aKey)
        {
            if (!aEnumType.IsEnum)
                throw new Exception("Type must be an Enum type");

            var vEnumName = aEnumType.GetEnumName(aKey);

            return GetText(aEnumType, vEnumName);
        }

        /// <summary>
        /// Retorna o valor texto do objeto enum informado.
        /// </summary>
        /// <param name="aEnumType"></param>
        /// <param name="vEnumName"></param>
        /// <returns></returns>
        public static string GetText(Type aEnumType, string vEnumName)
        {
            var vMemberInfo = aEnumType.GetMember(vEnumName);
            var vAttributes = vMemberInfo[0].GetCustomAttributes(typeof(DisplayAttribute), false);

            return vAttributes.Length > 0 ? ((DisplayAttribute)vAttributes[0]).Name : vEnumName;
        }

        /// <summary>
        /// Retorna um dicionário do tipo int, string do objeto enum informado.
        /// </summary>
        /// <param name="aEnumType"></param>
        /// <returns></returns>
        public static Dictionary<int, string> GetValueDisplayDictionary(Type aEnumType)
        {
            if (((object)aEnumType) == null) throw new ArgumentNullException("aEnumType");

            if (!aEnumType.IsEnum)
                throw new Exception("Type must be an Enum");

            return Enum.GetValues(aEnumType).Cast<object>().ToDictionary(vEnumValue => (int)vEnumValue, GetText);
        }

        /// <summary>
        /// Retorna uma lista do tipo SelectListItem do objeto enum informado. Para ser utilizado em lookups.
        /// </summary>
        /// <param name="aEnumType"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static List<SelectListItem> GetSelectListItems(Type aEnumType, int? value = null)
        {
            if (((object)aEnumType) == null) throw new ArgumentNullException("aEnumType");

            if (!aEnumType.IsEnum)
                throw new Exception("Type must be an Enum");

            return (from object vEnumValue in Enum.GetValues(aEnumType)
                    select new SelectListItem { Value = ((int)vEnumValue).ToString(), Text = GetText(vEnumValue), Selected = value.HasValue && ((int)vEnumValue) == value.Value }).ToList();
        }
    }
}
