using AnzolinNetDevPack.Services;

namespace AnzolinNetDevPack.Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                var service = new ConsultaCnpjService();

                var pessoaJuridica = service.ConsultaCnpj("27865757000102");
            }
        }
    }
}
