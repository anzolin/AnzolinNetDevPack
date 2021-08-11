﻿using System.Linq;

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
            if (!string.IsNullOrEmpty(value))
                switch (type)
                {
                    case MaskType.CPF:
                        if (value.Length == 11)
                            value = string.Format("{0}.{1}.{2}-{3}", value.Substring(0, 3), value.Substring(3, 3), value.Substring(6, 3), value.Substring(9, 2));
                        break;

                    case MaskType.CNPJ:
                        if (value.Length == 14)
                            value = string.Format("{0}.{1}.{2}/{3}-{4}", value.Substring(0, 2), value.Substring(2, 3), value.Substring(5, 3), value.Substring(8, 4), value.Substring(12, 2));
                        break;

                    case MaskType.CEP:
                        if (value.Length == 8)
                            value = string.Format("{0}-{1}", value.Substring(0, 5), value.Substring(5, 3));
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
    }
}
