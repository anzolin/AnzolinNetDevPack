namespace AnzolinNetDevPack.Validators
{
    public static class CpfCnpjValidator
    {
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
        private static bool IsCpf(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            cpf = cpf.Trim().Replace(".", "").Replace("-", "");

            if (cpf.Length != 11)
                return false;

            for (int j = 0; j < 10; j++)
                if (j.ToString().PadLeft(11, char.Parse(j.ToString())) == cpf)
                    return false;

            string tempCpf = cpf.Substring(0, 9);
            int soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            int resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            string digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            return cpf.EndsWith(digito);
        }

        /// <summary>
        /// Valida se é CNPJ.
        /// </summary>
        /// <param name="cnpj"></param>
        /// <returns></returns>
        private static bool IsCnpj(string cnpj)
        {
            var multiplicador1 = new int[] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            var multiplicador2 = new int[] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            cnpj = cnpj.Trim().Replace(".", "").Replace("-", "").Replace("/", "");
            if (cnpj.Length != 14)
                return false;

            var tempCnpj = cnpj.Substring(0, 12);
            var soma = 0;

            for (var i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

            var resto = (soma % 11);
            
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            var digito = resto.ToString();
            tempCnpj += digito;
            soma = 0;
            
            for (var i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];

            resto = (soma % 11);
            
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito += resto.ToString();

            return cnpj.EndsWith(digito);
        }
    }
}
