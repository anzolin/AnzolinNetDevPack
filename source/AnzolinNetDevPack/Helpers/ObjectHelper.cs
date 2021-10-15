using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace AnzolinNetDevPack.Helpers
{
    public static class ObjectHelper
    {
        /// <summary>
        /// Verifica se o objeto é nulo.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNull(object value)
        {
            return value == null || value.GetType().Name == "DBNull";
        }

        /// <summary>
        /// Verifica se o objeto é um número
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNumber(string value)
        {
            return decimal.TryParse(value, out decimal number);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="find"></param>
        /// <param name="replace"></param>
        /// <returns></returns>
        public static string SafeExactReplace(string value, string find, string replace)
        {
            return Regex.Replace(value, string.Format(@"\b{0}\b", find), replace);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DateTime SetValueDateTime(string value)
        {
            try
            {
                return (IsNull(value) || string.IsNullOrEmpty(value)) ? new DateTime() : DateTime.Parse(value);
            }
            catch (Exception)
            {
                return new DateTime();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static decimal GetNumberString(string value)
        {
            var x = Regex.Match(value, @"\d+").Value;

            return Decimal.Parse(x, new CultureInfo("en-US"));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ExtractCharecters(string value)
        {
            return Regex.Replace(value, @"[\d-]", string.Empty);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static decimal TryDecimalParse(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                if (value.Contains(","))
                {
                    return decimal.Parse(value, new CultureInfo("pt-BR"));
                }
                else if (value.Contains("."))
                {
                    return decimal.Parse(value, new CultureInfo("en-US"));
                }
                else if (IsNumber(value))
                {
                    return decimal.Parse(value, new CultureInfo("en-US"));
                }
            }

            return 0;
        }

        public static int TryIntParse(string value)
        {
            try
            {
                if (!string.IsNullOrEmpty(value) && IsNumber(value))
                {
                    return Convert.ToInt32(value);
                }

                return 0;
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
