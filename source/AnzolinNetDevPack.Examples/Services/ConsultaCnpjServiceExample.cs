using AnzolinNetDevPack.Services;

namespace AnzolinNetDevPack.Examples.Services
{
    public class ConsultaCnpjServiceExample
    {
        public void Main()
        {
            var service = new ConsultaCnpjService();

            var resultado = service.ConsultaCnpj("27865757000102");
        }
    }
}
