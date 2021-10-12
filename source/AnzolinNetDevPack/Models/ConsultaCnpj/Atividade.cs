using Newtonsoft.Json;

namespace AnzolinNetDevPack.Models.ConsultaCnpj
{
    public class Atividade
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }
    }
}
