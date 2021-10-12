using AnzolinNetDevPack.Interfaces;
using AnzolinNetDevPack.Models.ConsultaCnpj;
using AnzolinNetDevPack.Resources;
using AnzolinNetDevPack.Validators;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AnzolinNetDevPack.Services
{
    public class ConsultaCnpjService : IConsultaCnpjService
    {
        private readonly HttpClient _httpClient;

        public ConsultaCnpjService()
        {
            _httpClient = new HttpClient();
        }

        public PessoaJuridica ConsultaCnpj(string cnpj)
        {
            return ConsultaCnpjAsync(cnpj).Result;
        }

        public async Task<PessoaJuridica> ConsultaCnpjAsync(string cnpj)
        {
            if (string.IsNullOrEmpty(cnpj))
                throw new ArgumentNullException(nameof(cnpj));

            if (!CpfCnpjValidator.IsValid(cnpj))
                throw new ArgumentException(ErroResources.CNPJ_INVALIDO);

            const string api = "https://www.receitaws.com.br/v1/cnpj/{0}";

            try
            {
                using var response = await _httpClient.GetAsync(string.Format(api, cnpj)).ConfigureAwait(false);

                if (!response.IsSuccessStatusCode)
                    throw new Exception(ErroResources.CNPJ_NAO_ENCONTRADO);

                var result = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<PessoaJuridica>(result);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(ErroResources.ERRO_CONSULTA_CNPJ, ex.Message));
            }
        }
    }
}
