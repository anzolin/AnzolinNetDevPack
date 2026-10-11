using System.Linq;
using System.Text.RegularExpressions;

namespace AnzolinNetDevPack.Validators
{
    public static class CpfCnpjValidator
    {
        private static readonly int[] MultiplicadoresCpf1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        private static readonly int[] MultiplicadoresCpf2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        private static readonly int[] MultiplicadoresCnpj1 = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        private static readonly int[] MultiplicadoresCnpj2 = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

        private static readonly Regex FormatoCpf = new(@"^[0-9]{11}$", RegexOptions.Compiled);
        private static readonly Regex FormatoCnpj = new(@"^[A-Z0-9]{12}[0-9]{2}$", RegexOptions.Compiled);
        private static readonly Regex DigitosRepetidos = new(@"^(\d)\1+$", RegexOptions.Compiled);

        /// <summary>
        /// Valida o documento informado.
        /// </summary>
        /// <param name="cpfCnpj"></param>
        /// <returns></returns>
        public static bool IsValid(string cpfCnpj)
        {
            return IsCpf(cpfCnpj) || IsCnpj(cpfCnpj);
        }

        /// <summary>
        /// Valida se é um CPF.
        /// </summary>
        /// <param name="cpf"></param>
        /// <returns></returns>
        public static bool IsCpf(string cpf)
        {
            if (string.IsNullOrWhiteSpace(cpf))
                return false;

            cpf = cpf.Trim().Replace(".", "").Replace("-", "");

            if (!FormatoCpf.IsMatch(cpf) || DigitosRepetidos.IsMatch(cpf))
                return false;

            return cpf.EndsWith(DigitosVerificadores(cpf.Substring(0, 9), MultiplicadoresCpf1, MultiplicadoresCpf2));
        }

        /// <summary>
        /// Valida se é CNPJ, numérico ou alfanumérico (IN RFB nº 2.229/2024): 12 caracteres [A-Z0-9]
        /// seguidos de 2 dígitos verificadores. Letras minúsculas são aceitas.
        /// </summary>
        /// <param name="cnpj"></param>
        /// <returns></returns>
        public static bool IsCnpj(string cnpj)
        {
            if (string.IsNullOrWhiteSpace(cnpj))
                return false;

            cnpj = cnpj.Trim().Replace(".", "").Replace("-", "").Replace("/", "").ToUpperInvariant();

            if (!FormatoCnpj.IsMatch(cnpj) || DigitosRepetidos.IsMatch(cnpj))
                return false;

            return cnpj.EndsWith(DigitosVerificadores(cnpj.Substring(0, 12), MultiplicadoresCnpj1, MultiplicadoresCnpj2));
        }

        /// <summary>
        /// Remove a máscara do CNPJ, mantendo letras e números, e converte para maiúsculas.
        /// </summary>
        /// <param name="cnpj"></param>
        /// <returns></returns>
        public static string NormalizeCnpj(string cnpj)
        {
            return string.IsNullOrEmpty(cnpj) ? cnpj : new string(cnpj.Where(char.IsLetterOrDigit).ToArray()).ToUpperInvariant();
        }

        private static string DigitosVerificadores(string numero, int[] multiplicadores1, int[] multiplicadores2)
        {
            var primeiro = Digito(numero, multiplicadores1);
            var segundo = Digito(numero + primeiro, multiplicadores2);

            return $"{primeiro}{segundo}";
        }

        private static int Digito(string numero, int[] multiplicadores)
        {
            var soma = 0;

            // Cada caractere vale o seu código ASCII menos 48 (0-9 = 0-9, A = 17 ... Z = 42)
            for (var i = 0; i < multiplicadores.Length; i++)
                soma += (numero[i] - '0') * multiplicadores[i];

            var resto = soma % 11;

            return resto < 2 ? 0 : 11 - resto;
        }
    }
}
