using System;
using System.Linq;
using System.Text;

namespace AnzolinNetDevPack.Helpers
{
    public static class StringHelper
    {
        public enum MaskType
        {
            CPF,
            CNPJ,
            CEP
        }

        /// <summary>
        /// Remove todos caracteres, deixando apenas letras e números.
        /// </summary>
        /// <param name="Value">Valor com a máscara.</param>
        /// <returns>Retorna apanas números em uma String.</returns>
        public static string RemoveMask(string value)
        {
            return string.IsNullOrEmpty(value) ? string.Empty : new string(value.Where(char.IsLetterOrDigit).ToArray());
        }

        /// <summary>
        /// Aplica a máscara escolhida.
        /// </summary>
        /// <param name="type">Tipo de máscara</param>
        /// <param name="value">Valor que receberá a máscara.</param>
        /// <returns>Retorna o valor com a máscara escolhida aplicada.</returns>
        public static string AddMask(MaskType type, string value)
        {
            if (string.IsNullOrEmpty(value)) return value;
            
            switch (type)
            {
                case MaskType.CPF:
                    if (value.Length == 11)
                        value = $"{value.Substring(0, 3)}.{value.Substring(3, 3)}.{value.Substring(6, 3)}-{value.Substring(9, 2)}";
                    break;

                case MaskType.CNPJ:
                    if (value.Length == 14)
                        value = $"{value.Substring(0, 2)}.{value.Substring(2, 3)}.{value.Substring(5, 3)}/{value.Substring(8, 4)}-{value.Substring(12, 2)}";
                    break;

                case MaskType.CEP:
                    if (value.Length == 8)
                        value = $"{value.Substring(0, 5)}-{value.Substring(5, 3)}";
                    break;
            }

            return value;
        }

        /// <summary>
        /// Remove todas letras, deixando apenas números.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string OnlyNumbers(string value)
        {
            return string.IsNullOrEmpty(value) ? string.Empty : new string(value.Where(char.IsDigit).ToArray());
        }

        /// <summary>
        /// Aplica o primeiro caracter da string como maiúsculo.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string FirstChatToUpper(string value)
        {
            return string.IsNullOrEmpty(value) ? value : $"{char.ToUpper(value[0])}{value.Substring(1)}";
        }

        /// <summary>
        /// Remove acentuações.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string RemoveAccents(string value)
        {
            var bytes = Encoding.GetEncoding("Cyrillic").GetBytes(value);

            return Encoding.ASCII.GetString(bytes);
        }

        /// <summary>
        /// Converte e formata um número em tamanho de arquivo.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="decimalPlaces"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static string SizeSuffix(Int64 value, int decimalPlaces = 1)
        {
            string[] SizeSuffixes = { "bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };

            if (decimalPlaces < 0) { throw new ArgumentOutOfRangeException("decimalPlaces"); }
            if (value < 0) { return "-" + SizeSuffix(-value, decimalPlaces); }
            if (value == 0) { return string.Format("{0:n" + decimalPlaces + "} bytes", 0); }

            var mag = (int)Math.Log(value, 1024);
            var adjustedSize = (decimal)value / (1L << (mag * 10));

            if (Math.Round(adjustedSize, decimalPlaces) >= 1000)
            {
                mag += 1;
                adjustedSize /= 1024;
            }

            return string.Format("{0:n" + decimalPlaces + "} {1}", adjustedSize, SizeSuffixes[mag]);
        }
    }
}
