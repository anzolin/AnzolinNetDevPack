using AnzolinNetDevPack.Models.ConsultaCnpj;
using System.Threading.Tasks;

namespace AnzolinNetDevPack.Interfaces
{
    public interface IConsultaCnpjService
    {
        /// <summary>
        /// Consulta os dados da pessoa jurídica através do Cnpj informado.
        /// </summary>
        /// <param name="cnpj"></param>
        /// <returns></returns>
        PessoaJuridica ConsultaCnpj(string cnpj);

        /// <summary>
        /// Consulta os dados da pessoa jurídica através do Cnpj informado.
        /// </summary>
        /// <param name="cnpj"></param>
        /// <returns></returns>
        Task<PessoaJuridica> ConsultaCnpjAsync(string cnpj);
    }
}
